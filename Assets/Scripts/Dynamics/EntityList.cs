[System.Serializable]
public class EntityList
{
	public EntityGroup[] All => new EntityGroup[]
	{
		Birds, Clouds, Cargo, BigShips, MediumShips, SmallCargoShips, SmallSailShips
	};

	public BirdGroup Birds;
	public CloudGroup Clouds;
	public CargoGroup Cargo;
		
	public ShipGroup[] Ships => new[] {BigShips, MediumShips, SmallCargoShips, SmallSailShips};
	
	public ShipGroup BigShips;
	public ShipGroup MediumShips;

	public ShipGroup[] SmallShips => new[] {SmallCargoShips, SmallSailShips};
	
	public ShipGroup SmallCargoShips;
	public ShipGroup SmallSailShips;

	public EntityList()
	{
			
	}
}