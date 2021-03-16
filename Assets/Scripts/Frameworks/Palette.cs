using UnityEngine;

public static class Palette
{
	static Palette()
	{
	}

	public static Color Chestnut
	{
		get { return Color(187, 77, 77); }
	}

	
	
	
	private static Color Color(byte white)
	{
		return Color(white, white, white, byte.MaxValue);
	}
	
	private static Color Color(byte white, byte alpha)
	{
		return Color(white, white, white, alpha);
	}
	
	private static Color Color(byte red, byte green, byte blue)
	{
		return Color(red, green, blue, byte.MaxValue);
	}
	
	private static Color Color(byte red, byte green, byte blue, byte alpha)
	{
		return new Color(red.ToFloat01(), green.ToFloat01(), blue.ToFloat01(), alpha.ToFloat01());
	}

	
	
	/// <summary>
	/// Gets or add a component. Usage example:
	/// BoxCollider boxCollider = transform.GetOrAddComponent<BoxCollider>();
	/// </summary>
	private static float ToFloat01 (this byte byteValue)
	{
		return Mathf.Clamp01(byteValue / 255f);
	}
}