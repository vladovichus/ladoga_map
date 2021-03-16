using UnityEngine;

public static class Easing
{
    public static float Linear(float x)
    {
        return Curve.Linear.Bezier(x);
    }

    public static float Ease(float x)
    {
        return Curve.Ease.Bezier(x);
    }

    public static float EaseIn(float x)
    {
        return Curve.EaseIn.Bezier(x);
    }

    public static float EaseOut(float x)
    {
        return Curve.EaseOut.Bezier(x);
    }

    public static float EaseInOut(float x)
    {
        return Curve.EaseInOut.Bezier(x);
    }


    
    
    public struct Curve
    {
        public Vector2[] Points;

        public Curve(params Vector2[] p)
        {
            Points = p;
        }
        
        public Curve(Preset p)
        {
            switch (p)
            {
                case Preset.Linear:
                    Points = Linear.Points;
                    break;
                case Preset.Ease:
                    Points = Ease.Points;
                    break;
                case Preset.EaseIn:
                    Points = EaseIn.Points;
                    break;
                case Preset.EaseOut:
                    Points = EaseOut.Points;
                    break;
                case Preset.EaseInOut:
                    Points = EaseInOut.Points;
                    break;
                default:
                    Points = Linear.Points;
                    break;
            }
        }
        
        public float Bezier(float progress)
        {
            float a = Mathf.Clamp01(progress);
            float b = 1f - a;
            
            if (Points.Length == 2)
                return (Vector2.zero * b * b * b + 3f * a * b * (Points[0] * b + Points[1] * a) + Vector2.one * a * a * a).y;
            
            return (Points[0] * b * b * b + 3f * a * b * (Points[1] * b + Points[2] * a) + Points[3] * a * a * a).y;
        }
        
        public enum Preset { Linear, Ease, EaseIn, EaseOut, EaseInOut }
        
        public static Curve Linear => new Curve(Vector2.zero, Vector2.one);

        public static Curve Ease => new Curve(new Vector2(0.25f, 0.1f), new Vector2(0.25f, 1f));

        public static Curve EaseIn => new Curve(new Vector2(0.42f, 0f), new Vector2(1f, 1f));

        public static Curve EaseOut => new Curve(new Vector2(0f, 0f), new Vector2(0.58f, 1f));

        public static Curve EaseInOut => new Curve(new Vector2(0.42f, 0f), new Vector2(0.58f, 1f));
    }
}