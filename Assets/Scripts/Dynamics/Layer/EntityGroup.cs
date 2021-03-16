using UnityEngine;

public class EntityGroup : MonoBehaviour
{
	public EntityController Controller;
	
    public Entity[] Entities;

	public float Speed = 1f;

	public bool IsInit = false;

	public virtual void Setup()
	{
		IsInit = true;
	}
}
