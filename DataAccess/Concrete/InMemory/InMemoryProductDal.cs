using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;

        public InMemoryProductDal()
        {
            _products = new List<Product>
            {
                new Product { ProductId = 1, CategoryId = 1, ProductName = "Acer Laptop", UnitPrice = 7999, UnitsInStock = 8},
                new Product { ProductId = 2, CategoryId = 1, ProductName = "Asus Laptop", UnitPrice = 8999, UnitsInStock = 6},
                new Product { ProductId = 3, CategoryId = 1, ProductName = "Macbook Pro", UnitPrice = 12999, UnitsInStock = 3},
                new Product { ProductId = 4, CategoryId = 3, ProductName = "Logitech Mouse", UnitPrice = 129, UnitsInStock = 14},
                new Product { ProductId = 5, CategoryId = 2, ProductName = "Samsung s9", UnitPrice = 4500, UnitsInStock = 11}
            };
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            _products.Remove(productToDelete);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            return _products.SingleOrDefault(filter.Compile());
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            if (filter == null)
            {
                return _products;
            }
                
            else
            {
                return _products.Where(filter.Compile()).ToList();
            }
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }
    }
}
