using DG.Tweening;
using UnityEngine;

public class TweenController : MonoBehaviour
{
    public WeatherController Weather;
    
    public TweenPath[] Tweens;
   
    public float TimeScale = 1f;

    public float MoveLerp;
    public float RotateLerp;
    
    protected virtual void Awake()
    {
        Tweens = GetComponentsInChildren<TweenPath>(true);
        foreach (var tween in Tweens)
        {
            tween.Controller = this;
        }
        
        Initialize();
    }
    
    protected virtual void Start()
    {
		
    }
	
    protected virtual void Update()
    {
    }

    protected virtual void Initialize()
    {
        
    }
}
