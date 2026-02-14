using Activity.Model.POS;

namespace Activity.Model.Domain
{
    public class Product
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public Guid CategoryId { get; set; }
        public Guid SupplierId { get; set; }
        public DateTime DAteArrive { get; set; }
        public DateTime Expired { get; set; }
        public int BatchNum { get; set; }

        public Category? Category { get; set; }
        public Supplier? Supplier { get; set; }
    }
}
