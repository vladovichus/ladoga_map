using System.Linq;
using UnityEngine;

public class FrozenLake : MonoBehaviour
{
	public WeatherFrost Frost;
	
	public FrozenLakeIce[] Ices;

	public bool Visible;

	private void Awake()
	{
		Ices = GetComponentsInChildren<FrozenLakeIce>();
	}

	public float GetProgress()
	{
		float sum = 0;
		foreach (var ice in Ices)
		{
			sum += ice.Progress;
		}
		return sum / Ices.Length;
	}
}
