namespace Game.Core;

public struct AmmoStore
{
	public int Ammo    { get; set; }
	public int MaxAmmo { get; }
}

public interface IWeapon
{
	public const int         MaxAmmo = 30;
	public       Guid        Id         { get; }
	public       string      Title      { get; }
	public       int         CountAmmo  { get; }
	protected    AmmoStore[] AmmoStores { get; }

	public void Fire();

	public void Reload();

	public void AddMagazines( int magazines );
}

public class Weapon : IWeapon
{
	private readonly AmmoStore[] _ammoStores;

	public Weapon( string title )
	{
		Id          = Guid.NewGuid();
		Title       = title;
		_ammoStores = new AmmoStore[2];
	}

	private ref AmmoStore CurrentAmmoStore => ref _ammoStores[0];
	#region IWeapon Members

	public Guid   Id    { get; }
	public string Title { get; }

	public int CountAmmo { get => CurrentAmmoStore.Ammo; private set => CurrentAmmoStore.Ammo = value; }

	AmmoStore[] IWeapon.AmmoStores => _ammoStores;

	public void Fire() { }

	public void Reload() { }

	public void AddMagazines( int magazines ) => throw new NotImplementedException();

	#endregion
}