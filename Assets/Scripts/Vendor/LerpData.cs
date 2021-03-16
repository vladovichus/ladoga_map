using UnityEngine;

[System.Serializable]
public class LerpData
{
	public float Ratio;
	
	private float _value = 0;
	public float Value => _value;

	public LerpData(float ratio = 0)
	{
		Ratio = Mathf.Max(ratio, 0f);
		Update();
	}

	public void Update()
	{
		_value = Ratio > 0 ? Ratio * Time.deltaTime : 1f;
	}
	
	
	
	
	public float Calc(float src, float dst)
	{
		return Mathf.Lerp(src, dst, _value);
	}

	public Vector3 Calc(Vector3 src, Vector3 dst)
	{
		return Vector3.Lerp(src, dst, _value);
	}
	
	public Quaternion Calc(Quaternion src, Quaternion dst)
	{
		return Quaternion.Slerp(src, dst, _value);
	}


	public static float Valid(float lerp)
	{
		return lerp > 0 ? lerp * Time.deltaTime : 1f;
	}
}
