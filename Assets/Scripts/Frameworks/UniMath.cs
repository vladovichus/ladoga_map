using UnityEngine;

public static class UniMath 
{
    public static float Sign(bool boolVal)
    {
        return boolVal ? 1f : -1f;
    }
    
    public static float Sign01(bool boolVal)
    {
        return boolVal ? 1f : 0;
    }


    public static bool DeltaEquals05(float value, float delta)
    {
        return Mathf.Abs(value - 0.5f) < delta;
    }


    public static bool Equals(float val1, float val2)
    {
        return Mathf.Abs(val1 - val2) < Mathf.Epsilon;
    }
    
    public static bool Equals(Vector3 val1, Vector3 val2)
    {
        for (int i = 0; i < 3; ++i)
        {
            if (!Equals(val1[i], val2[i]))
                return false;
        }
        return true;
    }
    
    

    public static Color ColorOpacity(Color c, float a)
    {
        c.a = a;
        return c;
    }



    public static float TimeSin(float period)
    {
        return Mathf.Sin(2f * Mathf.PI * (Time.time % period) / period);
    }
    
    public static float TimeSin01(float period)
    {
        return 0.5f + 0.5f * TimeSin(period);
    }
    


    public static float Hypotenuse(float a, float b)
    {
        return Hypotenuse(a, b, true);
    }
    
    public static float Hypotenuse(float a, float b, bool sqrt)
    {
        return sqrt ? Mathf.Sqrt(a * a + b * b) : a * a + b * b;
    }



    public static float Range(Vector2 rangeVector)
    {
        return Range(rangeVector, true);
    }
    
    public static float Range(Vector2 rangeVector, bool yValueIsAdditiveToX)
    {
        return Random.Range(rangeVector.x, rangeVector.y + (yValueIsAdditiveToX ? rangeVector.x : 0));
    }




    public static Vector3 Multiply(Vector3 a, Vector3 b)
    {
        a.x *= b.x;
        a.y *= b.y;
        a.z *= b.z;
        return a;
    }

    public static Vector3 Multiply(params Vector3[] vecs)
    {
        if (vecs.Length >= 2)
        {
            for (int i = 1; i < vecs.Length; ++i)
            {
                vecs[0] = Multiply(vecs[0], vecs[i]);
            }
            return vecs[0];
        }
        
        return vecs.Length > 0 ? vecs[0] : Vector3.zero;
    }

    private static float _screenDiag = -1;
    public static float ScreenDiag => _screenDiag < 0 ? (_screenDiag = Hypotenuse(Screen.width, Screen.height)) : _screenDiag;
}
