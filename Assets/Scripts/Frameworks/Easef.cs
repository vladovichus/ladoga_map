using UnityEngine;


public static class Easef
{
	public const float ApproxFactor = 0.1316701294f;

	
	public enum EaseCurve
	{
		Linear, 
		
		Ease, 
		
		EaseIn, 
		EaseIn2, 
		EaseIn3, 
		
		EaseOut, 
		EaseOut2, 
		EaseOut3, 
		
		EaseInOut, 
		EaseInOut2, 
		EaseInOut3, 
		EaseInOut4, 
		EaseInOut5
	}


	/// <summary>
	/// Fast 3 bezier by x Э [0,1] and EaseCurve preset
	/// </summary>
	/// <param name="x">x Э [0,1]</param>
	/// <param name="curve">EaseCurve preset</param>
	/// <returns>result</returns>
	public static float Solve(float x, EaseCurve curve)
	{
		float y = 0;
		switch (curve)
		{
			case EaseCurve.Linear: 
				y = Linear(x); 
				break; 

			case EaseCurve.Ease: 
				y = Ease(x);
				break; 

				
				
			case EaseCurve.EaseIn: 
				y = EaseIn(x); 
				break; 
				
			case EaseCurve.EaseIn2: 
				y = EaseIn2(x); 
				break; 
				
			case EaseCurve.EaseIn3: 
				y = EaseIn3(x); 
				break; 

				
				
			case EaseCurve.EaseOut: 
				y = EaseOut(x); 
				break; 
				
			case EaseCurve.EaseOut2: 
				y = EaseOut2(x); 
				break; 
				
			case EaseCurve.EaseOut3: 
				y = EaseOut3(x); 
				break; 
				
				

			case EaseCurve.EaseInOut: 
				y = EaseInOut(x); 
				break; 
				
			case EaseCurve.EaseInOut2: 
				y = EaseInOut2(x); 
				break; 
				
			case EaseCurve.EaseInOut3: 
				y = EaseInOut3(x); 
				break; 
				
			case EaseCurve.EaseInOut4: 
				y = EaseInOut4(x); 
				break; 
				
			case EaseCurve.EaseInOut5: 
				y = EaseInOut5(x); 
				break;				
		}
		return y;
	}
	
	
	
	/// <summary>
	/// linear curve
	/// </summary>
	/// <param name="x">the value of x along the curve. x Э [0,1] </param>
	/// <returns>the y value along the curve</returns>
	public static float Linear(float x)
	{
		return x;
	}

	/// <summary>
	/// find fast approximations
	/// </summary>
	/// <param name="x">the value of x along the curve. x Э [0,1] </param>
	/// <returns>the y value along the curve</returns>
	public static float Ease(float x)
	{
		return 
			x <= 0f ? 0f :
			x >= 1f ? 1f :
			1.0042954579734844f * Mathf.Exp( -6.4041738958415664f * Mathf.Exp( -7.2908241330981340f * x));
	}

	/// <summary>
	/// very close approximation to 3-bezier(0.42, 0, 1.0, 1.0)
	/// </summary>
	/// <param name="x">the value of x along the curve. x Э [0,1] </param>
	/// <returns>the y value along the curve</returns>
	public static float EaseIn(float x)
	{
		return Mathf.Pow(x, 1.685f);
	}

	/// <summary>
	/// find fast approximations
	/// </summary>
	/// <param name="x">the value of x along the curve. x Э [0,1] </param>
	/// <returns>the y value along the curve</returns>
	public static float EaseIn2(float x)
	{
		return x * x;
	}

	/// <summary>
	/// find fast approximations
	/// </summary>
	/// <param name="x">the value of x along the curve. x Э [0,1] </param>
	/// <returns>the y value along the curve</returns>
	public static float EaseIn3(float x)
	{
		return x * x * x;
	}

	/// <summary>
	/// very close approximation to 3-bezier(0, 0, 0.58, 1.0)
	/// </summary>
	/// <param name="x">the value of x along the curve. x Э [0,1] </param>
	/// <returns>the y value along the curve</returns>
	public static float EaseOut(float x)
	{
		return 1f - Mathf.Pow(1 - x, 1.685f);
	}

	/// <summary>
	/// find fast approximations
	/// </summary>
	/// <param name="x">the value of x along the curve. x Э [0,1] </param>
	/// <returns>the y value along the curve</returns>
	public static float EaseOut2(float x)
	{
		x -= 1f;
		return 1f + x * x;
	}

	/// <summary>
	/// find fast approximations
	/// </summary>
	/// <param name="x">the value of x along the curve. x Э [0,1] </param>
	/// <returns>the y value along the curve</returns>
	public static float EaseOut3(float x)
	{
		x -= 1f;
		return 1f + x * x * x;
	}

	/// <summary>
	/// find fast approximations
	/// </summary>
	/// <param name="x">the value of x along the curve. x Э [0,1] </param>
	/// <returns>the y value along the curve</returns>
	public static float EaseInOut(float x)
	{
		return 
			x < 0.5 
			? ApproxFactor * Mathf.Pow(x, 1.925f)
			: 1f - ApproxFactor * Mathf.Pow(1 - x, 1.925f);
	}

	/// <summary>
	/// find fast approximations
	/// </summary>
	/// <param name="x">the value of x along the curve. x Э [0,1] </param>
	/// <returns>the y value along the curve</returns>
	public static float EaseInOut2(float x)
	{
		if (x < 0.5f)
			return 2f * x * x;
		
		x -= 1f;
		return 1f - 2f * x * x;
	}

	/// <summary>
	/// find fast approximations
	/// </summary>
	/// <param name="x">the value of x along the curve. x Э [0,1] </param>
	/// <returns>the y value along the curve</returns>
	public static float EaseInOut3(float x)
	{
		if (x < 0.5f)
			return 4f * x * x * x;

		x -= 1f;
		return 1f + 4f * x * x * x;
	}

	
	/// <summary>
	/// find fast approximations
	/// </summary>
	/// <param name="x">the value of x along the curve. x Э [0,1] </param>
	/// <returns>the y value along the curve</returns>
	public static float EaseInOut4(float x)
	{
		if (x < 0.5f)
			return 8f * x * x * x * x;
		
		x -= 1f;
		return 1f + 8f * x * x * x * x;
	}

	/// <summary>
	/// find fast approximations
	/// </summary>
	/// <param name="x">the value of x along the curve. x Э [0,1] </param>
	/// <returns>the y value along the curve</returns>
	public static float EaseInOut5(float x)
	{
		if (x < 0.5) 
			return 16f * x * x * x * x * x;
		
		x -= 1;
		return 1 + 16f * x * x * x * x * x;
	}
	
	
}
