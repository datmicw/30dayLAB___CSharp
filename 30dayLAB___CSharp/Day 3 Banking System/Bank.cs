//Day 3: Banking System
//Task:
//Create a class BankAccount with properties AccountNumber, OwnerName, and Balance.
//• Add methods for Deposit, Withdraw, and Transfer.
//• Ensure withdrawals don’t exceed the balance.
//• Algorithm: Use branching logic (if/else) for transaction processing

namespace _30dayLAB___CSharp.Day_3_Banking_System
{
    internal class Bank
    {
        public int AccountNumber { get; set; }
        public string AccountName { get; set; }
        public decimal Balance { get; set; }
    }
}
