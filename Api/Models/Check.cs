using Newtonsoft.Json;

namespace Api.Models
{

    public class ReceiptData
    {
        public JsonData data { get; set; }
    }

    public class JsonData
    {
        public ReceiptJson json { get; set; }
    }

    public class ReceiptJson
    {
        public long totalSum { get; set; }
        public int operationType { get; set; }
        public Items[] items { get; set; }
    }

    public class Items
    {
        public string name { get; set; }
        public double price { get; set; }
        public double quantity { get; set; }
        public double sum { get; set; }
    }

    public class CheckModel
    {
        public double totalSum { get; set; }
        public int operationType { get; set; }
        public Items[] items { get; set; }
        
    }
}