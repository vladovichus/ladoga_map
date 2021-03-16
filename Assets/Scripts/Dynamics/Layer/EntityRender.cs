using UnityEngine;

public class EntityRender : MonoBehaviour 
{
	public Entity Entity;
	public EntityPivot Pivot;

	private Renderer _renderer;
	public Renderer Renderer => _renderer ?? (_renderer = GetComponent<Renderer>());  
	
	public static EntityRender Generate(EntityPivot pivot, EntityOrigin origin)
	{
		var go = Instantiate(origin.gameObject);
		go.transform.parent = pivot.transform;
		go.name = pivot.Entity.gameObject.name + "_Renderer";
			
		var render = go.AddComponent<EntityRender>();

		ResetLocalTransform(render.transform);
		
		pivot.Entity.Render = render;
		render.Entity = pivot.Entity;
		
		pivot.Render = render;
		render.Pivot = pivot;
		
		Destroy(render.GetComponent<EntityOrigin>());

		return render;
	}

	private static void ResetLocalTransform(Transform dst)
	{
		dst.localPosition = Vector3.zero;
		dst.localRotation = Quaternion.identity;
		dst.localScale = Vector3.one;
	}

}
