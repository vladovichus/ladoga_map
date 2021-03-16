using UnityEngine;

public class MapWater : MonoBehaviour
{
	public Renderer Renderer;
	
	public Vector2 Offset;

	public Transform Flow;

	public float Height;
	
	private void Start()
	{
	}
	
	private void Update() 
	{
		Renderer.material.SetTextureOffset("_DetailAlbedoMap", Offset);
		
		Flow.localPosition = new Vector3(Flow.localPosition.x, Height, Flow.localPosition.z); 
	}
}
