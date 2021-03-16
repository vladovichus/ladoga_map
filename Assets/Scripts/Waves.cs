using UnityEngine;

public class Waves : MonoBehaviour
{
	public float Speed = 1f;
    public float Duration = 2f;
	
	public float Progress;
	public float BezierProgress;
	
	public float BlendShapeLength = 100;

	private SkinnedMeshRenderer _renderer;
	
	private void Start()
	{
		_renderer = GetComponent<SkinnedMeshRenderer>();
	}
	
	private void Update() 
	{
		Progress += Speed * Time.deltaTime / Duration;
		while (Progress > 1f)
			Progress -= 1f;

		BezierProgress = 2f * Mathf.Abs(Progress - 0.5f);
		BezierProgress = 0.5f * BezierProgress + 0.5f * Easef.EaseInOut2(BezierProgress); 
		
		
		_renderer.SetBlendShapeWeight(0, BezierProgress * BlendShapeLength);
	}
}
