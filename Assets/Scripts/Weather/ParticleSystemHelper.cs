using UnityEngine;

public class ParticleSystemHelper : MonoBehaviour 
{
	private ParticleSystem _particles;
	private ParticleSystem.EmissionModule _emission;
	
	private float _rateOverTime = 0;

	private bool _isInited = false;
	
	private void Initilize()
	{
		_particles = GetComponent<ParticleSystem>();
		_emission = _particles.emission;
		_rateOverTime = 0;
		_isInited = true;
	}
	
	public void SetRateOverTime(float rateOverTime)
	{
		if (!_isInited)
			Initilize();
				
		if (UniMath.Equals(rateOverTime, _rateOverTime))
			return;

		_rateOverTime = rateOverTime;
		_emission.rateOverTime = new ParticleSystem.MinMaxCurve(_rateOverTime);
	}
}
