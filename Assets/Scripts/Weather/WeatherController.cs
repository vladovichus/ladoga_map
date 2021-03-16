using UnityEngine;

public class WeatherController : MonoBehaviour
{
	public Weather[] Weathers => new Weather[] {Rain, Wind, Frost};
	
	public WeatherRain Rain;
	public WeatherWind Wind;
	public WeatherFrost Frost;
	
	public float Downtime = 0; 
	public float DowntimeMax = 120; 

	
	private void Start() 
	{
		
	}
	
	private void Update() 
	{
		Downtime += Time.deltaTime;

		if (Input.anyKeyDown)
		{
			Downtime = 0;
		}
		else if (Downtime > DowntimeMax)
		{
			Downtime = 0;
			WeathersReset();
		}
	}

	public void WeathersReset()
	{
		foreach (var w in Weathers)
		{
			w.ChangeState(WeatherState.Disabled);
		}
	}
	
	
}
