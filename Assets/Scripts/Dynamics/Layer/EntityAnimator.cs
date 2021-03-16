using UnityEngine;
using UnityEngine.Playables;

public class EntityAnimator : MonoBehaviour
{
	public Entity Entity;
	public EntityOrigin Origin;
	
	public Animator Animator;

	public AnimatorStateInfo AnimatorStateInfo;

	public float Duration = 0;
	public float Progress = 0;
	
	private void Start() 
	{
		
	}
	
	private void Update()
	{
		AnimatorStateInfo = Animator.GetCurrentAnimatorStateInfo(0);
		Progress = AnimatorStateInfo.normalizedTime;
		Duration = AnimatorStateInfo.length;
	}
	
	public static EntityAnimator Generate(Entity entity, GameObject sourceObject)
	{
		var animator = 
			sourceObject.GetComponent<EntityAnimator>()
			?? sourceObject.AddComponent<EntityAnimator>();
		animator.Animator = animator.gameObject.GetComponent<Animator>();
			
		entity.Animator = animator;
		animator.Entity = entity;

		return animator;
	}
}
