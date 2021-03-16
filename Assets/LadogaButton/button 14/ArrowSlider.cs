using UnityEngine;
using UnityEngine.UI;

public class ArrowSlider : MonoBehaviour
{
	public RectTransform Pivot;
	
	public RectTransform Transform;
	
	public Slider Slider;

	public ArrowTransform Arrow;

	public bool IsDrag = false;
	
	private void Start() 
	{
		
	}
	
	private void Update() 
	{
		if (!IsDrag)
		{
			Slider.value = Arrow.AngleProgress;
		}
	}

	public void OnBeginDrag()
	{
		IsDrag = true;
		Arrow.IsDrag = true;
	}

	public void OnEndDrag()
	{
		IsDrag = false;
		Arrow.IsDrag = false;
		Arrow.OnDragEnd();
	}
}
