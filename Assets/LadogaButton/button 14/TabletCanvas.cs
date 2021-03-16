using UnityEngine;
using UnityEngine.UI;

public class TabletCanvas : MonoBehaviour
{
	public ButtonController Controller;
	
	public RectTransform Sliders;
	public ArrowSlider OriginSlider;

	public ArrowSlider WindSlider;
	public ArrowSlider RainSlider;
	public ArrowSlider FrostSlider;
	
	private void Start()
	{
		Controller.Initialize();
		
		WindSlider = OriginSlider;
		WindSlider.gameObject.name = "WindSlider";
		WindSlider.Arrow = Controller.WindArrowTransform;
		WindSlider.Arrow.Slider = WindSlider;
		
		RainSlider = ArrowSliderInstatiate(OriginSlider);
		RainSlider.gameObject.name = "RainSlider";
		RainSlider.Arrow = Controller.RainArrowTransform;
		RainSlider.Arrow.Slider = RainSlider;
		
		FrostSlider = ArrowSliderInstatiate(OriginSlider);
		FrostSlider.gameObject.name = "FrostSlider";
		FrostSlider.Arrow = Controller.FrostArrowTransform;
		FrostSlider.Arrow.Slider = FrostSlider;

		WindSlider.Pivot.eulerAngles = Vector3.forward * GetAngle(Controller.Button, Controller.WindPlane);
		RainSlider.Pivot.eulerAngles = Vector3.forward * GetAngle(Controller.Button, Controller.RainPlane);
		FrostSlider.Pivot.eulerAngles = Vector3.forward * GetAngle(Controller.Button, Controller.FrostPlane);

		
	}
	
	private void Update() 
	{
		
	}

	private ArrowSlider ArrowSliderInstatiate(ArrowSlider origin)
	{
		var go = Instantiate(origin.gameObject);

		var t = (RectTransform) go.transform;
		t.SetParent(origin.transform.parent);
		
		var o = (RectTransform) origin.transform;
		t.anchoredPosition = o.anchoredPosition;
		t.sizeDelta = o.sizeDelta;
		
		return go.GetComponent<ArrowSlider>();
	}

	private float GetAngle(Transform origin, Transform plane)
	{
		if (plane.position.z < origin.position.z)
		{
			return 0f;
		}
		else
		{
			if (plane.position.x < origin.position.x)
			{
				return -120f;
			}
			else
			{
				return 120f;
			}
		}
	}
}
