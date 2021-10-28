using System;
using BankAccountNs;
using Xunit;
using ExMes = BankAccountNs.BankAccount.ExceptionMessages;

namespace Bank.Tests;

public class BankAccountTest
{
	private const    string CustomerName = "Mr. Bryan Walton";
	private readonly Random _random      = new();

	private double RandomBeginningBalance => _random.Next();

	[ Fact ]
	public void CustomerName_EquivalentToDeclared()
	{
		// Arrange
		var account = new BankAccount( CustomerName, RandomBeginningBalance );

		// Act
		var actual = account.CustomerName;

		// Assert
		Assert.Equal( CustomerName, actual );
	}

	[ Fact ]
	public void Debit_WithValidAmount_UpdatesBalance()
	{
		// Arrange
		var    beginningBalance = RandomBeginningBalance;
		double amount           = _random.Next( (int) beginningBalance );
		var    expected         = beginningBalance - amount;
		var    account          = new BankAccount( CustomerName, beginningBalance );

		// Act
		account.Debit( amount );

		// Assert
		var actual = account.Balance;
		Assert.Equal( expected, actual );
	}

	[ Fact ]
	public void Debit_WithAmountMoreThanBalance_ThrowOutOfRangeException()
	{
		// Arrange
		var    beginningBalance = RandomBeginningBalance;
		double amount           = _random.Next( (int) beginningBalance, int.MaxValue );
		var    account          = new BankAccount( CustomerName, beginningBalance );

		// Act
		// Assert
		Assert.Throws<ArgumentOutOfRangeException>( () => account.Debit( amount ) );
	}

	[ Fact ]
	public void Debit_WithAmountMoreThanBalance_ThrowOutOfRangeExceptionWithConcreteMessage()
	{
		// Arrange
		const string expected         = ExMes.DebitMoreBalance;
		var          beginningBalance = RandomBeginningBalance;
		double       amount           = _random.Next( (int) beginningBalance, int.MaxValue );
		var          account          = new BankAccount( CustomerName, beginningBalance );

		try
		{
			// Act
			account.Debit( amount );
		}
		catch (ArgumentOutOfRangeException exception)
		{
			// Assert
			Assert.Contains( expected, exception.Message );
		}
	}

	[ Fact ]
	public void Debit_WithAmountLessThanZero_ThrowOutOfRangeException()
	{
		// Arrange
		var    beginningBalance = RandomBeginningBalance;
		double amount           = _random.Next( 1, int.MaxValue ) * -1;
		var    account          = new BankAccount( CustomerName, beginningBalance );

		// Act
		// Assert
		Assert.Throws<ArgumentOutOfRangeException>( () => account.Debit( amount ) );
	}

	[ Fact ]
	public void Debit_WithAmountLessThanZero_ThrowOutOfRangeExceptionWithConcreteMessage()
	{
		// Arrange
		const string expected         = ExMes.DebitLessZero;
		var          beginningBalance = RandomBeginningBalance;
		double       amount           = _random.Next( 1, int.MaxValue ) * -1;
		var          account          = new BankAccount( CustomerName, beginningBalance );

		try
		{
			// Act
			account.Debit( amount );
		}
		catch (ArgumentOutOfRangeException exception)
		{
			// Assert
			Assert.Contains( expected, exception.Message );
		}
	}

	[ Fact ]
	public void Credit_WithValidAmount_UpdateBalance()
	{
		// Arrange
		var    beginningBalance = RandomBeginningBalance;
		double amount           = _random.Next( (int) beginningBalance );
		var    expected         = beginningBalance + amount;
		var    account          = new BankAccount( CustomerName, beginningBalance );

		// Act
		account.Credit( amount );

		// Assert
		var actual = account.Balance;
		Assert.Equal( expected, actual );
	}

	[ Fact ]
	public void Credit_WithAmountLessThanZero_ThrowOutOfRangeException()
	{
		// Arrange
		var    beginningBalance = RandomBeginningBalance;
		double amount           = _random.Next( 1, int.MaxValue ) * -1;
		var    account          = new BankAccount( CustomerName, beginningBalance );

		// Act
		// Assert
		Assert.Throws<ArgumentOutOfRangeException>( () => account.Credit( amount ) );
	}

	[ Fact ]
	public void Credit_WithAmountLessThanZero_ThrowOutOfRangeExceptionWithConcreteMessage()
	{
		// Arrange
		const string expected         = ExMes.CreditLessZero;
		var          beginningBalance = RandomBeginningBalance;
		double       amount           = _random.Next( 1, int.MaxValue ) * -1;
		var          account          = new BankAccount( CustomerName, beginningBalance );

		try
		{
			// Act
			account.Credit( amount );
		}
		catch (ArgumentOutOfRangeException exception)
		{
			// Assert
			Assert.Contains( expected, exception.Message );
		}
	}
}