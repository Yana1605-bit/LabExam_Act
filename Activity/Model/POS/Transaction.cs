namespace Activity.Model.POS
{
    public class Transaction
    {
        public Guid TransactionId { get; set; }
        public DateTime TransactionDate { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
        public decimal Change { get; set; }
    }
}
