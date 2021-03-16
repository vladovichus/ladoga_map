using UnityEngine;

public class BigShipTween : TweenPath
{
	public BigShipsTweenController ShipsController;

	public Transform ShipObject;
	
	
	protected override void UpdateTimeScale()
	{
		LocalTimeScale = ShipsController.GetTimeScale(Target.position);

		if (_weather.Frost.State != WeatherState.Disabled || _weather.Wind.IsHigh)
		{
			LocalTimeScale = 0;
		}
		
		base.UpdateTimeScale();
	}

	protected override void UpdateRotation()
	{
		base.UpdateRotation();
		
		ShipObject.localRotation = Quaternion.Slerp(
			ShipObject.localRotation,
			_weather.Wind.IsHigh ? Quaternion.Euler(0, 0, 180f) : Quaternion.identity,
			1.5f * Time.deltaTime
			);
	}

	private WeatherController _weather => ShipsController.Weather;
}
