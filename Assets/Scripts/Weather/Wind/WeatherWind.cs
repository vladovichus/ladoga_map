using UnityEngine;

public class WeatherWind : Weather
{
	public MapWater Water;

	public WindLeaves Leaves;
	
	public float Speed = 0.02f;
	public float Angle = 185f;
	public Vector2 Direction;
	
	public Transform BeachSafeLine;
	
	public float Progress;
	
	public float WaterNormalHeight = 0f;
	public float WaterLowHeight = 0.0119f;
	public float WaterHighHeight = 0.0135f;

	public float Duration = 0.9f;
	
	protected override void Start()
	{
		base.Start();
		Progress = 0;

		Leaves = GetComponentInChildren<WindLeaves>();
	}
	
	protected override void Update()
	{
		base.Update();

		UpdateWater();
		
		if (Controller.Frost.IsDisabled)
		{
			CalcSmallSailShips();
			CalcSmallCargoShips();
			CalcMediumShips();
			CalcBigShips();
		}
		
	}

	private void CalcSmallSailShips()
	{
		foreach (var ship in Entities.SmallSailShips.Entities)
		{
			float x = ship.Origin.transform.position.x;
			ship.IsWhole = IsDisabled || IsLow && x > BeachSafeLine.position.x;

		}
	}

	private void CalcSmallCargoShips()
	{
		foreach (var ship in Entities.SmallCargoShips.Entities)
		{
			ship.IsWhole = !IsHigh;
		}
	}

	private void CalcMediumShips()
	{
		foreach (var ship in Entities.MediumShips.Entities)
		{
			ship.IsWhole = IsDisabled;
		}
	}

	private void CalcBigShips()
	{
		foreach (var ship in Entities.BigShips.Entities)
		{
			ship.IsWhole = !IsHigh;
		}
	}

	private void UpdateWater()
	{
		Direction = new Vector2(Mathf.Cos(Angle * Mathf.Deg2Rad), Mathf.Sin(Angle * Mathf.Deg2Rad));
		Water.Offset += Speed * Direction * Time.deltaTime;
		

		var p = 0f;

		if (Controller.Frost.State != WeatherState.Disabled)
		{
			Progress = Mathf.Clamp01(Progress - 2f * Time.deltaTime / Duration);
		}
		
		if (Progress > 0.5f)
		{
			p = Mathf.Clamp01((Progress - 0.5f) / 0.5f);
			p = 0.5f * p + 0.5f * Easef.EaseIn2(p);

			Water.Height = WaterLowHeight + p * (WaterHighHeight - WaterLowHeight);
		}
		else
		{
			p = Mathf.Clamp01(Progress / 0.5f);
			p = 0.5f * p + 0.5f * Easef.EaseIn2(p);

			Water.Height = WaterNormalHeight + p * (WaterLowHeight - WaterNormalHeight);
		}
	}

	protected override void OnDisabledState()
	{
		Progress = Mathf.Clamp01(Progress - Time.deltaTime / Duration);
	}

	protected override void OnLowState()
	{
		if (Progress < 0.5f)
			Progress = Mathf.Clamp(Progress + Time.deltaTime / Duration, 0, 0.5f);
		else if (Progress > 0.5f)
			Progress = Mathf.Clamp(Progress - Time.deltaTime / Duration, 0.5f, 1f);
		else
			Progress = 0.5f;
	}

	protected override void OnHighState()
	{
		Progress = Mathf.Clamp01(Progress + Time.deltaTime / Duration);
	}
	
}
