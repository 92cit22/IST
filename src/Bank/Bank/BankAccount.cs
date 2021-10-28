namespace BankAccountNs;

/// <summary> Bank account demo class. </summary>
public class BankAccount
{
	public static class ExceptionMessages
	{
		public const string DebitMoreBalance = "Debit amount exceeds balance";
		public const string DebitLessZero    = "Debit amount is less than zero";
		public const string CreditLessZero   = "Credit amount is less than zero";
	}
	public BankAccount( string customerName, double balance )
	{
		CustomerName = customerName;
		Balance      = balance;
	}

	public string CustomerName { get; }

	public double Balance { get; private set; }

	public void Debit( double amount )
	{
		if( amount > Balance ) throw new ArgumentOutOfRangeException( nameof( amount ), amount,ExceptionMessages.DebitMoreBalance  );

		if( amount < 0 ) throw new ArgumentOutOfRangeException( nameof( amount ), amount, ExceptionMessages.DebitLessZero );

		Balance -= amount;
	}

	public void Credit( double amount )
	{
		if( amount < 0 ) throw new ArgumentOutOfRangeException( nameof( amount ), amount, ExceptionMessages.CreditLessZero );

		Balance += amount;
	}

}