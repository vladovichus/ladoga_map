using UnityEngine;

public class CanvasGroupHelper : MonoBehaviour 
{
	private CanvasGroup _canvasGroup;
	public CanvasGroup CanvasGroup => _canvasGroup ?? (_canvasGroup = GetComponent<CanvasGroup>());

	private float _alpha;
	public float Alpha
	{
		get
		{
			return _alpha; 
		}
		
		set 
		{
			_alpha = Mathf.Clamp01(value);
			CanvasGroup.alpha = _alpha;
		}
	}
}
