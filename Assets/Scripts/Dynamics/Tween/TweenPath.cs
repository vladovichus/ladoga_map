using DG.Tweening;
using UnityEngine;

public class TweenPath : MonoBehaviour
{
	public TweenController Controller;
	
	public DOTweenPath Path;
	public Tween Tween;

	public float LocalTimeScale = 1f;
	
	public Transform Target;

	public Vector3 AddPos;

	protected virtual void Awake()
	{
		if (Path == null)
			Path = GetComponentInChildren<DOTweenPath>();
	}

	protected virtual void Start()
	{
		Tween = Path.GetTween();
		
		if (Controller == null)
			Controller = GetComponentInParent<TweenController>();
	}

	protected virtual void Update()
	{
		if (Controller == null) return;
		
		UpdatePosition();
		UpdateRotation();

		UpdateTimeScale();
	}
	
	protected virtual void UpdateTimeScale()
	{
		Tween.timeScale = LocalTimeScale * Controller.TimeScale;
	}

	protected virtual void UpdatePosition()
	{
		Target.position = Vector3.Lerp(Target.position, Source.position + AddPos, MoveLerp);
	}

	protected virtual void UpdateRotation()
	{
		Target.rotation = Quaternion.Slerp(Target.rotation, Source.rotation, RotateLerp);
	}

	public float MoveLerp => LerpData.Valid(Controller.MoveLerp);
	public float RotateLerp => LerpData.Valid(Controller.RotateLerp);
	
	public Transform Source => Path.transform;

}
