using System.Linq;
using UnityEngine;

public class SwitcherGroup : MonoBehaviour
{
	public Switchers Controller;
	
	public Weather Weather;

	public SwitcherButton Current;
	private SwitcherButton[] _buttons;

	public bool Log = false;
	
	private void Start() 
	{
//		if (_buttons == null || _buttons.Length == 0)
//			_button

		_buttons = GetComponentsInChildren<SwitcherButton>();

		_buttons[0].TargetState = WeatherState.Disabled;
		_buttons[1].TargetState = WeatherState.Low;
		_buttons[2].TargetState = WeatherState.High;
	}
	
	private void Update()
	{
		Current = GetCurrentButton();
		foreach (var b in _buttons)
		{
			var c = b.Image.color;
			c = Color.Lerp( c, b == GetCurrentButton() ? Controller.ActiveSwitcher : Controller.NormalSwitcher, 10f * Time.deltaTime );
			b.Image.color = c;
		}
	}

	public void OnClickSwitcherButton(SwitcherButton button)
	{
		Weather.ChangeState(button.TargetState);
	}

	public SwitcherButton GetCurrentButton()
	{
		return _buttons.FirstOrDefault(b => b.TargetState == Weather.State);
	}

	private void DoLog(object s)
	{
		if (Log)
			Debug.Log(s);
	}
}
