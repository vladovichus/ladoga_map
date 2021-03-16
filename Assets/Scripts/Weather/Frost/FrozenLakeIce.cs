using UnityEngine;

public class FrozenLakeIce : MonoBehaviour
{
	public FrozenLake Lake;
	
	public float MinPos;
	public float MaxPos;

	public float Progress;

	public float Duration;
	
	public bool IsHide => Progress < Mathf.Epsilon;

	private Renderer _renderer;

	private Color _defaultColor;
		
	private void Start()
	{
		_renderer = GetComponent<Renderer>();
		_defaultColor = _renderer.sharedMaterial.color;
		_renderer.material.color = _defaultColor;
	}
	
	private void Update()
	{
		Progress = Mathf.Clamp01(Progress + UniMath.Sign(Lake.Visible) * Time.deltaTime / Duration);
		
		_defaultColor.a = Easef.EaseInOut2(Progress);
		
		Setup();
	}
	

	private void Setup()
	{
		Vector3 pos = transform.localPosition;

		var y = MinPos + Progress * (MaxPos - MinPos);
		pos.y = MinPos + Easef.EaseInOut2(Progress) * (MaxPos - MinPos);
		pos.y = (pos.y + y) * 0.5f;
		
		transform.localPosition = pos;
		
		_renderer.material.color = _defaultColor;

		_renderer.enabled = !IsHide;
	}
}
