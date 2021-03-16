using UnityEngine;

public class ShipEntity : Entity
{
	private ShipGroup _group;

	private int _variant = 0;
	
	private float _posFactor;
	private Vector2 _posFactorRange = new Vector2(40f, 90f);
	private float _posProgress = 0;
	private float _posDuration = 3.5f;
	private Vector2 _posDurationRange = new Vector2(1.5f, 4.5f);
	
	private float _rotFactor;
	private Vector2 _rotFactorRange = new Vector2(45f, 170f);
	private float _rotProgress = 0;
	private float _rotDuration = 1.9f; 
	private Vector2 _rotDurationRange = new Vector2(1.5f, 3f);

	protected override void Start()
	{
		base.Start();
		
		_group = Group as ShipGroup;

		_variant = Random.Range(0, 2);

		_posFactor = UniMath.Range(_posFactorRange, false);
		_posDuration = UniMath.Range(_posDurationRange, false);
		
		_rotFactor = UniMath.Range(_rotFactorRange, false);
		_rotDuration = UniMath.Range(_rotDurationRange, false);
	}

	protected override void Update()
	{
		base.Update();
	}
	
	protected override void UpdatePivot() 
	{
		if (CurrIsWhole)
		{
			Pivot.transform.position = CurrPos;
			Pivot.transform.rotation = Quaternion.Euler(CurrRot);
		}
		else
		{
			if (PrevIsWhole)
			{
				LastPosDelta = CurrPos - PrevPos;
				LastRotDelta = CurrRot - PrevRot;

				CanBeWhole = false;
			}
			
			if (GetProgress() >= 1f - 5f * Mathf.Epsilon)
				CanBeWhole = true;

			LastPosDelta = Vector3.Lerp(LastPosDelta, Vector3.zero, Time.deltaTime);
			
			Pivot.transform.position += LastPosDelta;
//			Pivot.transform.rotation = Quaternion.Euler(_lastRotation);
		}

		UpdateAnimation();
	}

	private void UpdateAnimation()
	{
		_posProgress += UniMath.Sign(!CurrIsWhole) * Time.deltaTime / _posDuration;
		_posProgress = Mathf.Clamp01(_posProgress);
		
		_rotProgress += UniMath.Sign(!CurrIsWhole) * Time.deltaTime / _rotDuration;
		_rotProgress = Mathf.Clamp01(_rotProgress);
		
		var pos = Render.transform.localPosition;
		var rot = Render.transform.localRotation.eulerAngles;

		var p = _posProgress;
		p = Easef.EaseInOut3(p);

		var r = _rotProgress;
		r = Easef.EaseInOut2(r);
		
		pos = -60f * p * _group.ShipwreckPosition;
		
		rot = UniMath.Sign(_variant == 0) * 135f * r * _group.ShipwreckRotation;
		
		Render.transform.localPosition = pos;
		Render.transform.localRotation = Quaternion.Euler(rot);
	}

	private float GetProgress()
	{
		return 0.5f * _posProgress + 0.5f * _rotProgress;
	}
}