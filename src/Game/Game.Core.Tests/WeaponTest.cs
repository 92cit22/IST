using Xunit;

namespace Game.Core.Tests;

public class WeaponTest
{
	private const string WeaponTitle = "Rifle";
	[ Fact ]
	public void WeaponCreate()
	{
		// Arrange
			
		// Act
		IWeapon weapon = new Weapon(WeaponTitle);

		// Assert
		Assert.NotNull( weapon );
	}

	[ Fact ]
	public void GetWeaponIdTest()
	{
		// Arrange
		IWeapon weapon = new Weapon(WeaponTitle);
		// Act
		var id = weapon.Id;
		// Assert
		Assert.NotNull( id );
	}

	[ Fact ]
	public void WeaponShouldFireTest()
	{
		// Arrange
		IWeapon weapon   = new Weapon(WeaponTitle);
		var     expected = weapon.CountAmmo;
			
		//Act 
		weapon.Fire();
		var actual = weapon.CountAmmo;
			
		// Assert
		Assert.NotEqual( expected, actual );
	}
		
}