using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // ProductTest();

            // CategoryTest();

            IProductService productManager = new ProductManager(new EfProductDal());

            foreach (var product in productManager.GetProductDetails().Data)
            {
                Console.WriteLine(product.ProductName + " / " + product.CategoryName);
            }
        }

        private static void CategoryTest()
        {
            ICategoryService categoryService = new CategoryManager(new EfCategoryDal());

            Console.WriteLine(categoryService.GetByCategoryName("Seafood").CategoryId);
        }

        private static void ProductTest()
        {
            IProductService productService = new ProductManager(new EfProductDal());

            //Console.WriteLine(productDal.Get(p => p.ProductId == 1).ProductName);

            var result = productService.GetAllByCategoryId(1);

            if (result.Success)
            {
                foreach (var product in result.Data)
                {
                    Console.WriteLine(product.ProductName + " " + product.CategoryId);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

            
        }
    }
}
