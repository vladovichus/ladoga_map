using UnityEngine;
using UnityEngine.UI;

public class SwitcherButtonGroup : MonoBehaviour
{
	public ButtonController Controller;

	public Transform Icon;

	private WeatherController _weather;
	public Weather Weather;
	
	public Button Disable;
	public Button Low;
	public Button High;
	
	private void Start()
	{
		_weather = FindObjectOfType<WeatherController>();
		
		Disable.onClick.AddListener(OnDisableClick);
		Low.onClick.AddListener(OnLowClick);
		High.onClick.AddListener(OnHighClick);

		if (Icon == Controller.WindPlane)
			Weather = _weather.Wind;
		else if (Icon == Controller.RainPlane)
			Weather = _weather.Rain;
		else
			Weather = _weather.Frost;
	}
	
	private void Update() 
	{
		
	}

	private void OnDisableClick()
	{
		Weather.ChangeState(WeatherState.Disabled);
	}
	private void OnLowClick()
	{
		Weather.ChangeState(WeatherState.Low);
	}
	private void OnHighClick()
	{
		Weather.ChangeState(WeatherState.High);
	}
}
