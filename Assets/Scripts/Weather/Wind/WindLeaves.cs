using UnityEngine;

public class WindLeaves : MonoBehaviour
{
	public WeatherWind Wind;
	
	private ParticleSystemHelper[] _particles;

	private float _rateOverTime = 0;
	
	private void Awake()
	{
		Wind = GetComponentInParent<WeatherWind>();
		_particles = GetComponentsInChildren<ParticleSystemHelper>();
	}
	
	private void Update() 
	{
		if (Wind.State == WeatherState.Disabled || Wind.Controller.Frost.State != WeatherState.Disabled)
		{
			SetRateOverTime(0);
		}
		else
		{
			if (Wind.State == WeatherState.Low)
			{
				SetRateOverTime(1);
			}
			else
			{
				SetRateOverTime(4);
			}
		}
	}
	
	
	private void SetRateOverTime(float val)
	{
		if (UniMath.Equals(_rateOverTime, val))
			return;

		_rateOverTime = val;

		foreach (var ps in _particles)
		{
			ps.SetRateOverTime(val);
		}
	}
}
