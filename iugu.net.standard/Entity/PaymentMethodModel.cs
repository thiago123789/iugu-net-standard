namespace iugu.net.standard.Entity
{
    // TODO: Precisa de refatoração, nomes fora do padrão .Net, sem documentação também
    public class PaymentMethodModel
    {
        public string id { get; set; }
        public string description { get; set; }
        public string item_type { get; set; }
        public PaymentMethodData data { get; set; }
    }

    // TODO: Precisa de refatoração, nomes fora do padrão .Net, sem documentação também
    public class PaymentMethodData
    {
        public string token { get; set; }
        public string holder_name { get; set; }
        public string bin { get; set; }
        public string display_number { get; set; }
        public string brand { get; set; }
        public int month { get; set; }
        public int year { get; set; }
    }
}
