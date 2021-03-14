using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal : EfEntityRepositoryBase<Category, NorthwindContext>, ICategoryDal
    {
        
    }
}

// burada ICategoryDal interface'ini de bırakmamızın bir sebebi var.
// biz EfEntityRepositoryBase sınıfını, sadece ortak EF metotları yazmak için oluşturduk.
// sadece ICategory'yi ilgilendirecek başka metotlar yazmamız gerekecek.
// bunun için IEntityDal sınıfları her entity için yine var olmaya devam etmeli.

// örneğin ICategoryDal içinde; public List<CategoryDto> GetDetails; tarzı bir şey ekleyebiliriz.