using System;
using UnityEngine;

public class EntityController : MonoBehaviour
{
	public static EntityController Instance = null;
	
	public WeatherController Weather;

	[SerializeField]
	public EntityList Groups;

	public BigShipsTweenController BigShipsTweenController;
	
	private void Awake()
	{
		Instance = this;
		
		Groups = new EntityList();
		
		Animator[] animators = GetComponentsInChildren<Animator>();
		foreach (var animator in animators)
		{
			GenerateDynamics(animator);
		}
		
		Groups.BigShips.ShipwreckRotation = Vector3.forward;
		Groups.BigShips.gameObject.SetActive(false);
		Groups.MediumShips.ShipwreckPosition = Vector3.forward;
//		SmallCargoShips.ShipwreckRotation = Vector3.right;
//		SmallCargoShips.ShipwreckRotation = Vector3.right;

	}
	
	private void Start()
	{
		foreach (var entityGroup in Groups.All)
		{
			entityGroup.Setup();
		}
	}

	
	private void Update()
	{
	}

	private void GenerateDynamics(Animator animator)
	{
		//Create EntityGroup object
		var charGroup = GenerateEntityGroup(animator.transform);
		
		for (int i = 0; i < charGroup.Entities.Length; ++i)
		{
			var go = animator.gameObject;
			if (i > 0)
			{
				go = Instantiate(animator.gameObject);
				go.transform.parent = charGroup.transform;
			}
			
			//Create Entity
			var entity = GenerateEntity(charGroup, go, i);
			
		}

		foreach (var controller in charGroup.Entities)
		{
			DisableOriginClones(controller.Animator);
		}
	}

	private void DisableOriginClones(EntityAnimator animator)
	{
		for (int j = 0; j < animator.transform.childCount; ++j)
		{
			var go = animator.transform.GetChild(j).gameObject;
			if (go != animator.Origin.gameObject)
			{
				go.SetActive(false);
				go.hideFlags = HideFlags.HideInHierarchy;
					
				Destroy(go.GetComponent<Renderer>());
				Destroy(go.GetComponent<MeshFilter>());
			}
		}
		
	}

	private EntityGroup GenerateEntityGroup(Transform animatorTransform)
	{
		var go = new GameObject(animatorTransform.gameObject.name);
		go.transform.parent = transform;
		animatorTransform.transform.parent = go.transform;
		
		var charGroup = SetupEntityGroupClass(go);
		charGroup.Controller = this;
		charGroup.Entities = new Entity[animatorTransform.childCount];

		return charGroup;
	}

	private EntityGroup SetupEntityGroupClass(GameObject go)
	{
		switch (go.name)
		{
			case "Clouds":
				return Groups.Clouds = go.AddComponent<CloudGroup>();
				break;
			case "Birds":
				return Groups.Birds = go.AddComponent<BirdGroup>();
				break;
			case "Cargo":
				return Groups.Cargo = go.AddComponent<CargoGroup>();
				break;
			case "BigShips":
				return Groups.BigShips = go.AddComponent<ShipGroup>();
				break;
			case "MediumShips":
				return Groups.MediumShips = go.AddComponent<ShipGroup>();
				break;
			case "SmallCargoShips":
				return Groups.SmallCargoShips = go.AddComponent<ShipGroup>();
				break;
			case "SmallSailShips":
				return Groups.SmallSailShips = go.AddComponent<ShipGroup>();
				break;
			default:
				Debug.LogError("ErrorName: " + go.name);
				return go.AddComponent<EntityGroup>();
				break;
		}
	}

	private Entity GenerateEntity(EntityGroup group, GameObject source, int index)
	{
		var go = new GameObject(source.name);
		go.transform.parent = source.transform.parent;
		source.transform.parent = go.transform;

		var entity = SetupEntityClass(group, go);

		entity.Group = group;
		group.Entities[index] = entity;
		
		//Create EntityAnimator
		var entityAnimator = EntityAnimator.Generate(entity, source);
			
		//Setup EntityOrigin
		var entityOrigin = EntityOrigin.Generate(
			entityAnimator, source.transform.GetChild(index).gameObject);
			
		
		//Create EntityPivot
		var entityPivot = EntityPivot.Generate(entity);
			
		// Create EntityRender
		var entityRender = EntityRender.Generate(entityPivot, entityOrigin);			
			
		
		//Clear renders in EntityOrigin
		Destroy(entityOrigin.GetComponent<Renderer>());
		Destroy(entityOrigin.GetComponent<MeshFilter>());
		
		
		return entity;
	}

	private Entity SetupEntityClass(EntityGroup group, GameObject go)
	{
		if (group is ShipGroup)
			return go.AddComponent<ShipEntity>();
		
		if (group is CargoGroup)
			return go.AddComponent<CargoEntity>();
		
		return go.AddComponent<Entity>();
	}

}
