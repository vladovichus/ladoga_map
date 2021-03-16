using UnityEngine;

public class ButtonController : MonoBehaviour
{
	public Camera Viewport;
	
	private WeatherController _weather;
	
	public Transform Button;
	
	public Transform WindArrow;
	public Transform RainArrow;
	public Transform FrostArrow;

	private Transform[] _planes;
	public Transform WindPlane;
	public Transform RainPlane;
	public Transform FrostPlane;
	
	private ArrowTransform _windArrow;
	public ArrowTransform WindArrowTransform => _windArrow;
	
	private ArrowTransform _rainArrow;
	public ArrowTransform RainArrowTransform => _rainArrow;
	
	private ArrowTransform _frostArrow;
	public ArrowTransform FrostArrowTransform => _frostArrow;
	
	private ArrowTransform[] _arrows => new[] {_windArrow, _rainArrow, _frostArrow};

	private bool _isInited = false;

	public Transform RainParticles;	
	public Transform WindParticles;	
	public Transform SnowParticles;

	private ParticleSystem _rainParticles;
	private ParticleSystem.EmissionModule _rainParticlesEmission;
	
	private ParticleSystem _windParticles;
	private ParticleSystem.EmissionModule _windParticlesEmission;
	
	private ParticleSystem _snowParticles;
	private ParticleSystem.EmissionModule _snowParticlesEmission;
		
	private void Awake()
	{
		Debug.Log("displays connected: " + Display.displays.Length);
        // Display.displays[0] is the primary, default display and is always ON.
        // Check if additional displays are available and activate each.
        if (Display.displays.Length > 1)
            Display.displays[1].Activate();
            
		Initialize();
	}

	public void Initialize()
	{
		if (_isInited)
			return;
		
		_weather = FindObjectOfType<WeatherController>();
		
		_windArrow = ArrowTransform.CreateArrowTransform("Wind", WindArrow, Button, _weather.Wind);
		_rainArrow = ArrowTransform.CreateArrowTransform("Rain", RainArrow, Button, _weather.Rain);
		_frostArrow = ArrowTransform.CreateArrowTransform("Frost", FrostArrow, Button, _weather.Frost);

		_planes = FindPlanes();

		WindPlane = GetPlane(WindArrow, _planes);
		WindPlane.gameObject.name = "WindPlane";
		CopyTransform(WindPlane, WindParticles);
		_windParticles = WindParticles.GetComponentInChildren<ParticleSystem>();
		_windParticlesEmission = _windParticles.emission;
		
		RainPlane = GetPlane(RainArrow, _planes);
		RainPlane.gameObject.name = "RainPlane";
		CopyTransform(RainPlane, RainParticles);
		_rainParticles = RainParticles.GetComponentInChildren<ParticleSystem>();
		_rainParticlesEmission = _rainParticles.emission;

		
		FrostPlane = GetPlane(FrostArrow, _planes);
		FrostPlane.gameObject.name = "FrostPlane";
		CopyTransform(FrostPlane, SnowParticles);
		_snowParticles = SnowParticles.GetComponentInChildren<ParticleSystem>();
		_snowParticlesEmission = _snowParticles.emission;
		
		_isInited = true;
	}

	private void CopyTransform(Transform origin, Transform dest)
	{
		dest.position = origin.position;
		dest.rotation = origin.rotation;
		dest.localScale = origin.localScale;
	}

	private Transform[] FindPlanes()
	{
		var index = 0;
		_planes = new Transform[3];
		for (int i = 0; i < Button.childCount; ++i)
		{
			var go = Button.GetChild(i).gameObject;
			if (go.name.ToLower().IndexOf("plane") >= 0)
			{
				_planes[index] = go.transform;
				index += 1;
			}
		}
		return _planes;
	}

	private Transform GetPlane(Transform arrow, Transform[] planes)
	{
		var cur = planes[0];
		var min = Vector3.Distance(arrow.position, planes[0].position);
		foreach (var plane in planes)
		{
			if (Vector3.Distance(arrow.position, plane.position) < min)
			{
				cur = plane;
				min = Vector3.Distance(arrow.position, plane.position);
			}
		}
		return cur;
	}
	
	private void Update()
	{
		UpdateParticles(_rainParticlesEmission, _weather.Rain, 2f, 5f, 10f);
		UpdateParticles(_snowParticlesEmission, _weather.Frost, 1f, 3f, 6f);
		UpdateParticles(_windParticlesEmission, _weather.Wind, 1f, 3f, 5f);
	}

	private void UpdateParticles(ParticleSystem.EmissionModule emissionModule, Weather weather, float min, float low, float max)
	{
		var str = 0f;
		if (weather.State == WeatherState.Disabled)
			str = min;
		else if (weather.State == WeatherState.Low)
			str = low;
		else
			str = max;
		emissionModule.rateOverTimeMultiplier = str;
	}
	
}
