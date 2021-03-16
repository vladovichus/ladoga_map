using UnityEngine;

namespace Сonvertrator
{

    public static class Сonvert
    {
        
        public static float ByteToFloat01(byte byteValue)
        {
            return ByteToFloat01((int) byteValue);
        }
	
        public static float ByteToFloat01(int intValue)
        {
            return Mathf.Clamp01(intValue / 255f);
        }

        public static Color NormalizeColor(Color color)
        {
            for (int i = 0; i < 4; ++i)
                color[i] = Mathf.Clamp01(color[i]);
            return color;
        }
        
    }

}