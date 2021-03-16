using UnityEngine;

public class BigShipsTweenController : TweenController
{
	public ShipGroup Group; 
	
	public BigShipTween[] Ships;
	
	public Transform SlowPoint;
	public float Range = 1f;
	
	[Range(0f, 1f)]
	public float MinTimeScale = 0.2f; 

	private void OnDrawGizmosSelected()
	{
		Gizmos.matrix = SlowPoint.localToWorldMatrix;
		Gizmos.color = Color.red;
		Gizmos.DrawSphere(Vector3.zero, Range);
	}
	
	public float GetTimeScale(Vector3 pos)
	{
		var val = Vector3.Distance(pos, SlowPoint.position);

		return val > Range ? 1f : (MinTimeScale + val / Range * (1f - MinTimeScale));

//		var dist = pos - SlowPoint.position;
//		var val = dist.x * dist.x + dist.z * dist.z;
//		
//		if (val > Range * Range) return 1f;
//		
//		return MinTimeScale + val / (Range * Range) * (1f - MinTimeScale);
	}

	protected override void Initialize()
	{
		base.Initialize();

		Ships = new BigShipTween[Tweens.Length];
		for (int i = 0; i < Ships.Length; i++)
		{
			Ships[i] = (BigShipTween) Tweens[i];
			Ships[i].ShipsController = this;
		}

		Group = EntityController.Instance.Groups.BigShips;
	}
}
