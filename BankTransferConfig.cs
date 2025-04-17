using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace modul8_103022300148
{
    public class BankTransferConfig
    {
        public string lang { get; set; }
        public class Transfer
        {
            public Transfer(int threshold, int low_fee, int high_fee)
            {
                this.threshold = threshold;
                this.low_fee = low_fee;
                this.high_fee = high_fee;
            }

            public int threshold { get; set; }
            public int low_fee { get; set; }
            public int high_fee { get; set; }
        }
        
        public List<string> methods { get; set; }
        public class Confirmation
        {
            public Confirmation(string en, string id)
            {
                this.en = en;
                this.id = id;
            }

            public string en { get; set; }
            public string id { get; set; }
        }
        public Transfer transfer { get; set; }
        public Confirmation confirmation { get; set; }
          public BankTransferConfig() { }  
        public BankTransferConfig(string lang, List<string> methods, Transfer transfer, Confirmation confirmation)
        {
            this.lang = lang;
            this.methods = methods;
            this.transfer = transfer;
            this.confirmation = confirmation;
        }
    }
    public class UIConfig
    {
        public BankTransferConfig config;
        public const String filePath = "D:\\bank_transfer_config.json";
        public UIConfig()
        {
            try
            {
                ReadConfigFile();
            }
            catch (Exception)
            {
                SetDefault();
                WriteNewConfigFile();
            }
        }
        public BankTransferConfig ReadConfigFile()
        {
            String jsonString = File.ReadAllText(filePath);
            var options = new JsonSerializerOptions
            {
                IncludeFields = true
            };
            BankTransferConfig json = JsonSerializer.Deserialize<BankTransferConfig>(jsonString, options);
            return json;
        }
        public void SetDefault()
        {
            config = new BankTransferConfig();
            config.lang = "en";
            config.transfer = new BankTransferConfig.Transfer(25000000, 6500, 15000);
            config.methods = new List<string>() { "RTO (real-time)", "SKN", "RTGS", "BI FAST" };
            config.confirmation = new BankTransferConfig.Confirmation("yes", "ya");
        }
        public void WriteNewConfigFile()
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
            String jsonString = JsonSerializer.Serialize(config, options);
            File.WriteAllText(filePath, jsonString);
        }
    }
}
