using System;

namespace MyLib
{
    public class Account
    {
        
        public delegate void TrafficOverloadHandler(string message);
        public event TrafficOverloadHandler Notify;
        private string Name;
        private decimal MoneyBalance, Price;
        private double Speed, Megabytes, MegabytesPday;
        private Tariff[] Tariffs = new Tariff[4]
        {
            new Tariff("M", 60, 30, 1000), // "S" = name, 60 - monthly cost, 30 - speed, 1000 - MBs/Day
            new Tariff("L", 80, 30, 2000),
            new Tariff("XL", 100, 30, 3000),
            new Tariff("XXL", 120, 30, 4000),
        };
        
        public Tariff[] GetTariffs() => Tariffs;
        
        public Account() { }
        
        public Account(int ChosenTariff, decimal Money)
        {
            if ((ChosenTariff > 0) && (ChosenTariff < Tariffs.Length))
            {
                ChooseTariff(ChosenTariff);
                MoneyBalance = Money;
            }
            else throw new ArgumentOutOfRangeException("Index is out of range");
        }
        
        public Account(int ChosenTariff)
        {
            ChooseTariff(ChosenTariff);
            MoneyBalance = 0;
        }

        public void UseInternet(double Hours)
        {
            if (Hours > 0)
            {
                for (double i = 0; i < Hours; i += 0.1)
                {
                    Megabytes -= Speed * 1.5;
                    if (Megabytes <= 0)
                    {
                        Notify?.Invoke("You have no megabytes left!");
                        Megabytes = 0;
                        return;
                    }
                }
            }
            else throw new ArgumentException("Hours must be > 0 ");
        }


        public void ChooseTariff(int ChosenTariff)
        {
            Name = Tariffs[ChosenTariff].Name;
            Price = Tariffs[ChosenTariff].Price;
            Speed = Tariffs[ChosenTariff].Speed;
            MegabytesPday = Tariffs[ChosenTariff].MegabytesPday;
            Megabytes = MegabytesPday;
        }
        
        public void Put(decimal Money)
        {
            MoneyBalance += Money;
        }

        public decimal CheckMoney() => MoneyBalance;
        
        public double CheckMBs() => Megabytes;

        public void NextDay()
        {
            MoneyBalance -= Price / 30;
            Megabytes += MegabytesPday;
            if (MoneyBalance < 0) Megabytes = 0;
        }

        public override string ToString()
        {
            return "Your Tarrif Name: " + Name + "\n"
                    + "Money Left: " + MoneyBalance.ToString() + "\n"
                    + "Megabyts Left: " + Megabytes.ToString() + "\n";
        }
    }
    public struct Tariff
    {
        public Tariff(string Name, decimal Price, double Speed, double Megabytes)
        {
            this.Name = Name;
            this.Price = Price;
            this.Speed = Speed;
            MegabytesPday = Megabytes;
        }
        public string Name { get; }
        public decimal Price { get; }
        public double Speed { get; }
        public double MegabytesPday { get; }
    }
}