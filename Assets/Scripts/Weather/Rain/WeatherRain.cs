using UnityEngine;

public class WeatherRain : Weather
{	
	public ParticleSystemHelper Particles;

	public MapGround Ground;
	
	public EntityController EntityController;

	public float CargoSpeedDuration = 0.8f;
	public float WetGroundDuration = 0.8f;
	
	protected override void Start()
	{
	}

	protected override void Update()
	{
		base.Update();

		CalcCargoSpeed();
		CalcGroundWet();
	}

	private void CalcCargoSpeed()
	{
		float cargoSpeed = Entities.Cargo.Speed;
		float dt = Time.deltaTime / CargoSpeedDuration;
		           
		if (Controller.Frost.IsDisabled && !IsDisabled)
		{
			if (IsLow)
			{       
				if (UniMath.DeltaEquals05(cargoSpeed, dt))
					cargoSpeed = 0.5f;
				else
					cargoSpeed += UniMath.Sign(cargoSpeed < 0.5f) * dt;
			}
			else if (IsHigh)
			{
				cargoSpeed -= dt;
			}
		}
		else
		{
			cargoSpeed += dt;
		}
		
		Entities.Cargo.Speed = Mathf.Clamp01(cargoSpeed);
	}

	private void CalcGroundWet()
	{
		float wet = Ground.Wet;
		float dt = Time.deltaTime / WetGroundDuration;
		
		if (Controller.Frost.IsDisabled && !IsDisabled)
		{
			if (IsLow)
			{
				if (UniMath.DeltaEquals05(wet, dt))
					wet = 0.5f;
				else
					wet += UniMath.Sign(wet < 0.5f) * dt;
			}
			else if (IsHigh)
			{
				wet += dt;
			}
		}
		else
		{
			wet -= dt;
		}
		
		Ground.Wet = Mathf.Clamp01(wet);
	}


	protected override void OnDisabledState()
	{
		SetRateOverTime(0);
	}

	protected override void OnLowState()
	{
		SetRateOverTime(100);
	}

	protected override void OnHighState()
	{
		SetRateOverTime(300);
	}

	private void SetRateOverTime(float val)
	{
		if (Controller.Frost.IsDisabled)
			Particles.SetRateOverTime(val);
		else
			Particles.SetRateOverTime(0);
	}
}
