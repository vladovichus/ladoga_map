using UnityEngine;

public class Entity : MonoBehaviour
{
	public EntityGroup Group;

	public EntityAnimator Animator;
	public EntityOrigin Origin;

	public EntityPivot Pivot;
	public EntityRender Render;

	protected Vector3 PrevPos;
	protected Vector3 CurrPos;
	protected Vector3 LastPosDelta;
	
	protected Vector3 PrevRot;
	protected Vector3 CurrRot;
	protected Vector3 LastRotDelta;
	
	protected bool PrevIsWhole;
	protected bool CurrIsWhole;
	protected bool CanBeWhole = true;

	public bool IsWhole = true;

	public float Progress;
	public float Duration;
	
	protected virtual void Start()
	{
		
	}
	
	protected virtual void Update()
	{
		Progress = Animator.Progress;
		Duration = Animator.Duration;
		UpdateMoveData();
		UpdatePivot();
		UpdateAnimator();
	}

	protected virtual void UpdateMoveData()
	{
		PrevIsWhole = CurrIsWhole;
		CurrIsWhole = IsWhole && CanBeWhole;
		
		PrevPos = CurrPos;
		CurrPos = Origin.transform.position;

		PrevRot = CurrRot;
		CurrRot = Origin.transform.rotation.eulerAngles;
	}

	protected virtual void UpdatePivot()
	{
		Pivot.transform.position = CurrPos;
		Pivot.transform.rotation = Quaternion.Euler(CurrRot);
	}

	protected virtual void UpdateAnimator()
	{
		Animator.Animator.speed = Group.Speed;
	}
}
