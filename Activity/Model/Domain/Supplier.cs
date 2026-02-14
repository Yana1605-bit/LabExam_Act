namespace Activity.Model.POS
{
    public class Supplier
    {
        public Guid SupplierId { get; set; }
        public string SupplierName { get; set; } = string.Empty;
        public string address { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string TaxCode { get; set; } = string.Empty;  
    }
}
