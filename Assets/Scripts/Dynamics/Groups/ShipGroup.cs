using UnityEngine;

public class ShipGroup : EntityGroup
{
    public ShipEntity[] Ships => (ShipEntity[]) Entities;

    public Vector3 ShipwreckPosition = Vector3.up;
    public Vector3 ShipwreckRotation = Vector3.right;
}
