using UnityEngine;

public class CargoGroup : EntityGroup
{
    public CargoEntity[] Cargo => (CargoEntity[]) Entities;

    public bool Winter = false;

    public float WinterSpeed;

    public CargoEntity First;
    public CargoEntity Second;
    
    public override void Setup()
    {
        base.Setup();
        
        transform.localPosition = Vector3.back;
        First = (CargoEntity) Entities[1];
        Second = (CargoEntity) Entities[0];
    }

    private void Update()
    {
        if (!IsInit)
            return;

        var first = First.Progress > 0.3f;
        First.Render.gameObject.SetActive(!first);

        var second = Second.Progress > 0.43f;
        Second.Render.gameObject.SetActive(!second);
        
    }
}
