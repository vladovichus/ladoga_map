using UnityEngine;
using UnityEngine.UI;

public class SwitcherButton : MonoBehaviour
{
	private SwitcherGroup _group;
	
	private Button _button;

	public Image Image;
	
	public WeatherState TargetState;
	
	private void Awake()
	{
		_group = GetComponentInParent<SwitcherGroup>();

		Image = GetComponent<Image>();
		
		_button = GetComponent<Button>();
		_button.onClick.AddListener(OnClick);
	}

	private void OnClick()
	{
		_group.OnClickSwitcherButton(this);
	}
}
