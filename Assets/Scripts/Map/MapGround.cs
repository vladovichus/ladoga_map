using UnityEngine;

public class MapGround : MonoBehaviour
{
	
	private Renderer _renderer;
	private Color _defaultColor;

	public float Wet = 0f;
	private float Metallic = 0.96f;
	private float Smoothness = 0.43f;
		
	private void Start()
	{
		_renderer = GetComponent<Renderer>();
		_defaultColor = _renderer.sharedMaterial.color;
		_renderer.material.color = _defaultColor;
	}
	
	private void Update()
	{
		_renderer.material.color = _color;
		
		
		_renderer.material.SetFloat("_Metallic", Wet * Metallic);
		_renderer.material.SetFloat("_Glossiness", Wet * Smoothness);
	}

	private Color _color;
	public Color CurrentColor
	{
		get { return _color; }
		set { _color = value; }
	}
}
