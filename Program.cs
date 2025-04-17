using modul8_103022300148;
using static modul8_103022300148.BankTransferConfig;

class Program
{
    public static void Main(string[] args)
    {
        BankTransferConfig bankConfig = new BankTransferConfig();
        UIConfig uIConfig = new UIConfig();
        uIConfig.SetDefault();
        uIConfig.ReadConfigFile();
        Console.Write("Masukkan Bahasa en/id : ");
        string bahasa = Console.ReadLine();
        uIConfig.config.lang = bahasa;
        if (uIConfig.config.lang == "en")
        {
            Console.Write("Please insert the amount of money to transfer : ");
        }
        else
        {
            Console.Write("Masukkan jumlah uang yang akan di - transfer : ");
        }
        int nilai = int.Parse(Console.ReadLine());
        int total,fee;
        if (nilai <= uIConfig.config.transfer.threshold) {
            fee = uIConfig.config.transfer.low_fee;
            total = nilai + fee;
        }
        else
        {
            fee = uIConfig.config.transfer.high_fee;
            total = nilai + fee;
        }
        if (uIConfig.config.lang == "en")
        {
            Console.WriteLine("Transfer fee = " + fee  + " ,Total amount = " + total);
        }
        else
        {
            Console.WriteLine("Biaya transfer = " + fee + " ,Total biaya = " + total);
        }
        if (uIConfig.config.lang == "en")
        {
            Console.WriteLine("Select transfer method:");
        }
        else
        {
            Console.WriteLine("Pilih metode transfer:");
        }
        for (int i = 0; i < uIConfig.config.methods.Count; i++) { 
            Console.WriteLine((i+ 1) + ". " + uIConfig.config.methods[i]);
        }
        int pilih = int.Parse(Console.ReadLine());
        if (uIConfig.config.lang == "en")
        {
            Console.Write("Please type "+uIConfig.config.confirmation.en +" to confirm the transaction:");
        }
        else
        {
            Console.Write("Ketik "+uIConfig.config.confirmation.id+" untuk mengkonfirmasi transaksi:");
        }
        string input = Console.ReadLine();
        if (uIConfig.config.lang == "en" && input == uIConfig.config.confirmation.en)
        {
            Console.Write("The transfer is completed");
        }
        else if (input == uIConfig.config.confirmation.id)
        {
            Console.Write("Proses transfer berhasil");
        }
        else if (uIConfig.config.lang == "en" && input != uIConfig.config.confirmation.en)
        {
            Console.Write("Transfer is cancelled");
        }
        else if (input != uIConfig.config.confirmation.id)
        {
            Console.WriteLine("Transfer dibatalkan");
        }
        uIConfig.WriteNewConfigFile();
    }
}

