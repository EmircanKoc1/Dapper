using Dapper;
using DapperAPI.DTOs;
using DapperAPI.Entities;
using DapperAPI.Helpers;
using DapperAPI.Interfaces;
using System.Data;

namespace DapperAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ConnectionHelper _connectionHelper;
        public ProductRepository(ConnectionHelper connectionHelper)
        {
            _connectionHelper = connectionHelper;
        }

        public void CreateProduct(ProductDTO product)
        {
            var query = "INSERT INTO PRODUCTS (ProductName,SupplierID,CategoryID,QuantityPerUnit,UnitPrice,UnitsInStock,UnitsOnOrder,ReorderLevel) VALUES (@ProductName,@SupplierID,@CategoryID,@QuantityPerUnit,@UnitPrice,@UnitsInStock,@UnitsOnOrder,@ReorderLevel)";

            var parameters = new DynamicParameters();
            parameters.Add("ProductName",product.ProductName,DbType.String);
            parameters.Add("SupplierID", product.SupplierId,DbType.Int32);
            parameters.Add("CategoryID", product.CategoryId,DbType.Int32);
            parameters.Add("QuantityPerUnit", product.QuantityPerUnit,DbType.String);
            parameters.Add("UnitPrice", product.UnitPrice,DbType.Decimal);
            parameters.Add("UnitsInStock", product.UnitsInStock,DbType.Int16);
            parameters.Add("UnitsOnOrder", product.UnitsInOrder,DbType.Int16);
            parameters.Add("ReorderLevel", product.ReorderLevel,DbType.Int16);
         
            using var connection = _connectionHelper.CreateSqlConnection();
            connection.Execute(query, parameters);

        }

        public Product GetProductById(int productId)
        {
            var query = "SELECT * FROM Products WHERE ProductID = @ProductId";
            using var connection = _connectionHelper.CreateSqlConnection();

            var product = connection.QueryFirst<Product>(query, new { ProductId = productId });

            return product;


        }

        public IEnumerable<Product> GetProducts()
        {
            var query = "SELECT * FROM Products";
            using var connection = _connectionHelper.CreateSqlConnection();
            var products = connection.Query<Product>(query);

            return products.ToList();
        }
    }
}
