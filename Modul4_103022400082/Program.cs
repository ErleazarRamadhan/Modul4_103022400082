using System;
using System.Collections.Generic;

enum State
{
    OFF,
    STANDBY,
    BREWING,
    MAINTENANCE
}

class KodePaket
{
    Dictionary<string, string> tabelPaket = new Dictionary<string, string>()
    {
        { "Basic", "P201"},
        { "Standard", "P202"},
        { "Premium", "P203"},
        { "Unlimited", "P204"},
        { "Gaming", "P205"},
        { "Streaming", "P206"},
        { "Family", "P207"},
        { "Business", "P208"},
        { "Student", "P209"},
        { "Traveler", "P210"},
    };

    public string getKodePaket(string namaPaket)
    {
        if (tabelPaket.ContainsKey(namaPaket))
            return tabelPaket[namaPaket];
        else
            return "Kode tidak ditemukan";
    }
}

class MesinKopi
{
    private State currentState;

    public MesinKopi()
    {
        currentState = State.OFF;
    }

    public void PowerOn()
    {
        if (currentState == State.OFF)
        {
            currentState = State.STANDBY;
            Console.WriteLine("Mesin Off berubah menjadi Standby");
        }
        else Invalid();
    }

    public void StartBrew()
    {
        if (currentState == State.STANDBY)
        {
            currentState = State.BREWING;
            Console.WriteLine("Mesin Standby berubah menjadi Brewing");
        }
        else Invalid();
    }

    public void FinishBrew()
    {
        if (currentState == State.BREWING)
        {
            currentState = State.STANDBY;
            Console.WriteLine("Mesin Brewing berubah menjadi Standby");
        }
        else Invalid();
    }

    public void StartMaintenance()
    {
        if (currentState == State.STANDBY)
        {
            currentState = State.MAINTENANCE;
            Console.WriteLine("Mesin Standby berubah menjadi Maintenance");
        }
        else Invalid();
    }

    public void FinishMaintenance()
    {
        if (currentState == State.MAINTENANCE)
        {
            currentState = State.STANDBY;
            Console.WriteLine("Mesin Maintenance berubah menjadi Standby");
        }
        else Invalid();
    }

    public void PowerOff()
    {
        if (currentState == State.STANDBY)
        {
            currentState = State.OFF;
            Console.WriteLine("Mesin Standby berubah menjadi Off");
        }
        else Invalid();
    }

    public void Invalid()
    {
        Console.WriteLine("Perubahan state tidak valid");
    }
}

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("=== KODE PAKET ===");
        KodePaket kp = new KodePaket();

        Console.Write("Masukkan nama paket: ");
        string input = Console.ReadLine();

        string hasil = kp.getKodePaket(input);
        Console.WriteLine("Kode Paket: " + hasil);

        Console.WriteLine("\n=== SIMULASI MESIN KOPI ===");

        MesinKopi mesin = new MesinKopi();

        mesin.PowerOn();
        mesin.StartBrew();
        mesin.FinishBrew();
        mesin.StartMaintenance();
        mesin.FinishMaintenance();
        mesin.PowerOff();

        mesin.StartBrew();

        Console.ReadLine();
    }
}