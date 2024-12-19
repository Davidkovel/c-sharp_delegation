using System;
using System.Text;
using DelegateClass;

namespace Delegate
{

    public class CreditCard
    {
        public string CardNumber { get; set; }
        public string CardHolderName { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int PIN { get; private set; }
        public double CreditLimit { get; set; }
        public double Balance { get; private set; }

        public Action<double> DepositBalance;
        public Action<double> FundsSpent;
        public Action CreditUsed;
        public Action LimitReached;
        public Action PinChanged;


        public CreditCard() {
            this.CardNumber = string.Empty;
            this.CardHolderName = string.Empty;
            this.ExpiryDate = DateTime.MinValue;
            this.PIN = 0;
            this.Balance = 0.0;
            this.CreditLimit = 0.0;
        }

        public CreditCard(string cardNumber, string cardHolderName, DateTime expiryDate, int pin, double creditLimit) : this()
        {
            CardNumber = cardNumber;
            CardHolderName = cardHolderName;
            ExpiryDate = expiryDate;
            PIN = pin;
            CreditLimit = creditLimit;
            Balance = 0.0;
        }


        public void Deposit(double amount) {
            if (amount < 0) { Console.WriteLine("Сума поповнення має бути більшою за 0"); return; }

            Balance += amount;
            DepositBalance.Invoke(amount);

        }


        public void Spend(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Сума зняття має бути бiльше 0");
                return;
            }

            if (Balance >= amount)
            {
                Balance -= amount;
                FundsSpent?.Invoke(amount);
            }
            else
            {
                double deficit = amount - Balance;

                if (deficit <= CreditLimit)
                {
                    Console.WriteLine("Використання кредитних коштів.");
                    CreditLimit -= deficit;
                    Balance = 0;
                    FundsSpent?.Invoke(amount);
                    CreditUsed?.Invoke();
                }
                else
                {
                    Console.WriteLine("Досягнуто ліміт кредитних коштів");
                    LimitReached?.Invoke();
                }
            }
        }

        public void ChangePIN(int newPin)
        {
            PIN = newPin;
            PinChanged.Invoke();
        }


    }

    internal class Program
    {
        private static CreditCard card;
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            try
            {
                card = new CreditCard("6743-2343-6542-3573", "Vova Bob", new DateTime(2027, 06, 22), 1234, 8000);

                card.DepositBalance = DepositBalanceHandler;
                card.FundsSpent = FundsSpentHandler;
                card.CreditUsed = CreditUsedHandler;
                card.LimitReached = LimitReachedHandler;
                card.PinChanged = PinChangedHandler;

                card.Deposit(1000);
                card.Spend(1200);
                card.Spend(4000);
            }

            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            finally
            {

                Console.WriteLine("\nProgram execution completed.");
            }
        }

        public static void FundsSpentHandler(double amount)
        {
            Console.WriteLine($"Знято з карти: {amount}. Залишок: {card.Balance}");
        }

        public static void CreditUsedHandler()
        {
            Console.WriteLine("Ви почали використовувати кредитні кошти.");
        }

        public static void LimitReachedHandler()
        {
            Console.WriteLine("Досягнуто ліміт кредитних коштів. Подальші операції неможливі.");
        }

        public static void DepositBalanceHandler(double amount)
        {
            Console.WriteLine($"Баланс поповнено на {amount}. Поточний баланс: {card.Balance}");
        }

        public static void PinChangedHandler()
        {
            Console.WriteLine("PIN-код змінено");
        }
    }
}

/*
Баланс поповнено на 1000. Поточний баланс: 1000
Використання кредитних коштів.
Знято з карти: 1200. Залишок: 0
Ви почали використовувати кредитні кошти.
Використання кредитних коштів.
Знято з карти: 4000. Залишок: 0
Ви почали використовувати кредитні кошти.

Program execution completed.

C:\Users\David\source\repos\ConsoleApp1\ConsoleApp1\bin\Debug\net8.0\ConsoleApp1.exe (process 5184) exited with code 0 (0x0).
Press any key to close this window . . .



 
 
*/