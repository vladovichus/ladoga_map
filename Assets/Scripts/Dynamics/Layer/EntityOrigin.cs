using UnityEngine;

public class EntityOrigin : MonoBehaviour 
{
    public Entity Entity;
    public EntityAnimator Animator;
    
    
    public static EntityOrigin Generate(EntityAnimator animator, GameObject originGameObject)
    {
        var origin = originGameObject.AddComponent<EntityOrigin>();
		
        animator.Entity.gameObject.name = origin.gameObject.name;
        animator.gameObject.name = animator.Entity.gameObject.name + "_Animator";

        animator.Entity.Origin = origin;
        origin.Entity = animator.Entity;
		
        animator.Origin = origin;
        origin.Animator = animator;
		
        return origin;
    }
}
