using UnityEngine;

public class EntityPivot : MonoBehaviour
{
	public Entity Entity;
	public EntityRender Render;
	
	
	public static EntityPivot Generate(Entity entity)
	{
		var go = new GameObject(entity.gameObject.name + "_Transform");
		go.transform.parent = entity.transform;
			
		var pivot = go.AddComponent<EntityPivot>();
		
		CopyLocalTransform(pivot.transform, entity.Origin.transform);
		
		entity.Pivot = pivot;
		pivot.Entity = entity;

		return pivot;
	}
	
	private static void CopyLocalTransform(Transform dst, Transform src)
	{
		dst.localPosition = src.localPosition;
		dst.localRotation = src.localRotation;
		dst.localScale = src.localScale;
	}
}
