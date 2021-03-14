using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCategoryDal : ICategoryDal
    {
        List<Category> _categories;

        public InMemoryCategoryDal()
        {
            _categories = new List<Category>
            {
                new Category { CategoryId = 1, CategoryName = "Bilgisayar"},
                new Category { CategoryId = 2, CategoryName = "Akıllı Telefon"},
                new Category { CategoryId = 3, CategoryName = "Mouse"}
            };
        }
        public void Add(Category category)
        {
            _categories.Add(category);
        }

        public void Delete(Category category)
        {
            Category categoryToDelete = _categories.SingleOrDefault(c => c.CategoryId == category.CategoryId);
            _categories.Remove(categoryToDelete);
        }

        public Category Get(Expression<Func<Category, bool>> filter)
        {
            return _categories.SingleOrDefault(filter.Compile());
        }

        public List<Category> GetAll(Expression<Func<Category, bool>> filter = null)
        {
            if (filter == null)
            {
                return _categories;
            }

            else
            {
                return _categories.Where(filter.Compile()).ToList();
            }
        }

        public void Update(Category category)
        {
            Category categoryToUpdate = _categories.SingleOrDefault(c => c.CategoryId == category.CategoryId);
            
            categoryToUpdate.CategoryName = category.CategoryName;
        }
    }
}
