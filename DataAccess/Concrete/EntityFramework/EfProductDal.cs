/* Kodların altında açıklamalar var. */

using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    // entity framework'e göre kod yazıyoruz.
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {
        public List<ProductDetailDto> GetProductDetails()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from p in context.Products
                             join c in context.Categories
                             on p.CategoryId equals c.CategoryId
                             select new ProductDetailDto
                             {
                                 ProductId = p.ProductId,
                                 ProductName = p.ProductName,
                                 UnitsInStock = p.UnitsInStock,
                                 CategoryName = c.CategoryName
                             };

                return result.ToList();
            }
        }
    }
}

/* 
            using yazmak yerine, direkt olarak Northwind newleyebilirdik.
            ancak using içine yazınca, garbage collector işimiz bittikten sonra o nesneyi topluyor. performans artıyor.

            bu using'in özel bir kullanımıdır. adı: IDisposable pattern implementation of c#
            c# a özel bir yapıdır.
 */

//          yukarıda açıklama olarak yazdığım kodlar, Core katmanına taşındı.