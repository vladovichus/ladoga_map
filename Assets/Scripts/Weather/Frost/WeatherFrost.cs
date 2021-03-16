using System;
using UnityEngine;

public class WeatherFrost : Weather
{
	public FrozenLake LakeMin;
	public FrozenLake LakeMax;

	public MapGround Ground;

	private Color _color;
	public Color NormalColor = new Color(0.652f, 0.613f, 0.543f);
	public Color LowColor = new Color(0.7f, 0.7f, 0.7f); //160 169 180 A4A9B4FF
	public Color HighColor = new Color(0.793f, 0.843f, 0.871f); //171 185 214 ABB9D6FF

	public ParticleSystemHelper Particles;

	public EntityController EntityController;
	
	
	protected override void Start()
	{
		_color = NormalColor;
		Ground.CurrentColor = _color;
		
	}
	
	protected override void Update()
	{
		base.Update();

		Ground.CurrentColor = Color.Lerp(Ground.CurrentColor, _color, 0.45f * Time.deltaTime);
		
		foreach (var ship in Entities.Ships)
		{
			ship.Speed = Mathf.Clamp01(ship.Speed + 1.25f * Time.deltaTime * UniMath.Sign(State == WeatherState.Disabled));
		}

		CalcCargo();
	}

	private void CalcCargo()
	{
		var cargo = Entities.Cargo;
		
		cargo.Winter = State != WeatherState.Disabled;

		var speed = cargo.WinterSpeed;
		var dt = Time.deltaTime / 0.6f;
		
		if (IsHigh)
		{
			speed += dt;
		}
		else if (IsLow)
		{
			if (UniMath.DeltaEquals05(speed, dt))
				speed = 0.5f;
			else
				speed += UniMath.Sign(speed < 0.5f) * dt;
		}
		else
		{
			speed -= dt;
		}
		
		cargo.WinterSpeed = Mathf.Clamp01(speed);
	}
	
	
	

	protected override void OnDisabledState()
	{
		LakeMax.Visible = false;
		if (LakeMax.GetProgress() < 0.5f)
		{
			LakeMin.Visible = false;
		}
		_color = NormalColor;
		
		SetRateOverTime(0);

	}

	protected override void OnLowState()
	{
		LakeMax.Visible = false;
		LakeMin.Visible = true;
		_color = LowColor;
		
		SetRateOverTime(25);
	}

	protected override void OnHighState()
	{
		LakeMin.Visible = true;
		if (LakeMin.GetProgress() > 0.5f)
		{
			LakeMax.Visible = true;
		}
		_color = HighColor;
		
		SetRateOverTime(70);
	}
	
	
	
	
	private void SetRateOverTime(float val)
	{
		if (val > 0)
		{
			if (Controller.Rain.State == WeatherState.Low)
				val += 20f;

			if (Controller.Rain.State == WeatherState.High)
				val += 60f;
		}
		
		Particles.SetRateOverTime(val);
	}
}
