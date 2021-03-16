using UnityEngine;

public abstract class Weather : MonoBehaviour
{	
	public WeatherController Controller;

	private WeatherState _prevState = WeatherState.Disabled;
	public WeatherState State = WeatherState.Disabled;

	public bool IsDisabled => State == WeatherState.Disabled;
	public bool IsLow => State == WeatherState.Low;
	public bool IsHigh => State == WeatherState.High;
	
	protected virtual void Awake()
	{
	}
	
	protected virtual void Start()
	{
	}

	protected virtual void Update()
	{
		switch (State)
		{
			case WeatherState.Disabled:
				OnDisabledState();
				break;
				
			case WeatherState.Low:
				OnLowState();
				break;
				
			case WeatherState.High:
				OnHighState();
				break;
		}
	}
	
	public void ChangeState(WeatherState state)
	{
		_prevState = State;
		State = state;
	}

	protected abstract void OnDisabledState();

	protected abstract void OnLowState();
	
	protected abstract void OnHighState();

	public EntityList Entities => EntityController.Instance.Groups;
}
