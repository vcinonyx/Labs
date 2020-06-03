#include <iostream>
#include <string>
#include <string>

void(*TrafficOverloadHandler)(std::string message);

void DisplayMessage(std::string message) {
    std::cout << message << "\n";
}


struct Tariff
{
    Tariff(std::string Name, int Price, double Speed, double Megabytes)
    {
        this->Name = Name;
        this->Price = Price;
        this->Speed = Speed;
        this->MegabytesPday = Megabytes;
    }

    std::string Getname()
    {
        return this->Name;
    }
    int GetPrice()
    {
        return this->Price;
    }
    double GetSpeed()
    {
        return this->Speed;
    }

    double GetMegabytes()
    {
        return this->MegabytesPday;
    }
private:
    std::string Name;
    int Price;
    double Speed;
    double MegabytesPday;
};


class Account
{
private:
    std::string Name;
    int MoneyBalance, Price;
    double Speed, Megabytes, MegabytesPday;
    int TariffsNumber = 4;

public:

    Tariff* Tariffs = new Tariff[4]
    {
            Tariff("M", 60, 30, 1000), // "S" = name, 60 - monthly cost, 30 - speed, 1000 - MBs/Day
            Tariff("L", 80, 30, 2000),
            Tariff("XL", 100, 30, 3000),
            Tariff("XXL", 120, 30, 4000),
    };

    Tariff* GetTariffs() { return Tariffs; };

    Account() { }
    Account(int ChosenTariff, int Money)
    {
        ChooseTariff(ChosenTariff);
        MoneyBalance = Money;
    }
    Account(int ChosenTariff)
    {
        ChooseTariff(ChosenTariff);
        MoneyBalance = 0;
    }
    void UseInternet(double Hours)
    {
        if (Hours > 0)
        {
            for (double i = 0; i < Hours; i += 0.1)
            {
                Megabytes -= Speed * 1.5;
                if (Megabytes <= 0)
                {
                    TrafficOverloadHandler = DisplayMessage;
                    TrafficOverloadHandler("You have no megabytes left!");
                    Megabytes = 0;
                    return;
                }
            }
        }
    }
    void Put(int Money) { MoneyBalance += Money; }
    int CheckMoney() { return MoneyBalance; }
    double CheckMBs() { return Megabytes; }
    void NextDay()
    {
        MoneyBalance -= Price / 30;
        Megabytes += MegabytesPday;
        if (MoneyBalance < 0) Megabytes = 0;
    }
    void ChooseTariff(int ChosenTariff)
    {
        Name = Tariffs[ChosenTariff].Getname();
        Price = Tariffs[ChosenTariff].GetPrice();
        Speed = Tariffs[ChosenTariff].GetSpeed();
        MegabytesPday = Tariffs[ChosenTariff].GetMegabytes();
        Megabytes = MegabytesPday;
    };
};
