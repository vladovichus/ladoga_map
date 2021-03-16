using UnityEngine;

public class CargoEntity : Entity
{
	private CargoGroup _group;
	
	public Renderer WinterRenderer;


	protected override void Start()
	{
		base.Start();

		_group = (CargoGroup) Group;
		
		var t = Render.transform.GetChild(0);
		if (t != null)
		{
			t.gameObject.SetActive(true);
			WinterRenderer = t.GetComponent<Renderer>();
		}
	}
	
	protected override void Update()
	{
		base.Update();

		Render.Renderer.enabled = !_group.Winter;
		WinterRenderer.enabled = _group.Winter;
	}

	protected override void UpdateAnimator()
	{
		var speed = 1f + 0.66f * _group.WinterSpeed;
		Animator.Animator.speed = _group.Speed * speed;
	}
}
