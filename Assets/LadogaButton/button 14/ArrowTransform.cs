using UnityEngine;

public class ArrowTransform : MonoBehaviour 
{
	public static bool Invert = false;
	
	public string Name;
	public Transform Arrow;
	public Transform Parent;

	public Weather Weather;

	private Transform _pivot;

	public float Rotation;
	public float TargetRotation;

	public bool IsDrag = false;

	public ArrowSlider Slider;

	public float AngleProgress => Invert ? (Rotation / 80f) : (1f - Rotation / 80f);
	
	private void Start() 
	{
	}
	
	public void Update()
	{
		UpdateTargetRotation();
		UpdateTransform();
	}

	public void UpdateTargetRotation()
	{
		if (!IsDrag)
		{
			if (Weather.State == WeatherState.High && !Invert || Weather.State == WeatherState.Disabled && Invert)
			{
				TargetRotation = 0f;
			}
			else if (Weather.State == WeatherState.Low)
			{
				TargetRotation = 40f;
			}
			else
			{
				TargetRotation = 80f;
			}
		}
		else
		{
			if (Invert)
				TargetRotation = Slider.Slider.value * 80f;
			else
				TargetRotation = (1f - Slider.Slider.value) * 80f;
			
			CheckWeatherStateFromRotation();
		}
	}

	public void OnDragEnd()
	{
		CheckWeatherStateFromRotation();
	}

	private void CheckWeatherStateFromRotation()
	{
		float target = TargetRotation;

		if (target < 20f)
		{
			Weather.State = Invert ? WeatherState.Disabled : WeatherState.High;
		}
		else if (target < 60f)
		{
			Weather.State = WeatherState.Low;
		}
		else
		{
			Weather.State = !Invert ? WeatherState.Disabled : WeatherState.High;
		}
	}

	private void UpdateTransform()
	{
		Rotation = Mathf.Lerp(Rotation, TargetRotation, 4f * Time.deltaTime);
		_pivot.eulerAngles = Rotation * Vector3.down;
	}

	public static ArrowTransform CreateArrowTransform(string arrowName, Transform arrow, Transform parent, Weather weather)
	{
		var pivotObject = new GameObject(arrowName + " Arrow Pivot");
		var arrowTransform = pivotObject.AddComponent<ArrowTransform>();
		
		arrowTransform._pivot = pivotObject.transform;
		
		arrowTransform.Name = arrowName;
		arrowTransform.Arrow = arrow;
		arrowTransform.Parent = parent;
		arrowTransform.Weather = weather;
		
		
		arrowTransform._pivot.SetParent(parent);
		arrowTransform._pivot.localPosition = Vector3.zero;
		arrowTransform._pivot.localScale = Vector3.one;
		arrowTransform._pivot.localRotation = Quaternion.identity;
		
		arrow.SetParent(arrowTransform._pivot, true);
		arrow.gameObject.name = arrowTransform.Name + " Arrow";

		arrowTransform.UpdateTargetRotation();
		
		return arrowTransform;
	}
}
