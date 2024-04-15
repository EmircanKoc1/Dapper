namespace DapperAPI.DTOs
{
    public class ProductDTO
    {
        public string ProductName { get; set; }
        public int SupplierId { get; set; }
        public int CategoryId { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public short UnitsInStock { get; set; }
        public short UnitsInOrder { get; set; }
        public short ReorderLevel { get; set; }
    }
}
