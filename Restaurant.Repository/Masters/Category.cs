using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Restaurant.DataModel;

namespace Restaurant.Repository.Masters
{
    public class CategoryItem
    {
        public List<Category> GetMenuCategory()
        {
            using (var db = new ResturantDataContext())
            {
                return db.Categories.ToList();
            }
        }

        public Category GetCategory(int ID)
        {  
            using (var db = new ResturantDataContext())
            {
                return db.Categories.FirstOrDefault(p => p.ID == ID);
            }
        }

        public int AddCategory(Category category)
        {
            using (var context = new ResturantDataContext())
            {
                context.Categories.InsertOnSubmit(category);
                context.SubmitChanges();
                return category.ID;
            }
            return 0;
        }

        public bool UpdateCategory(Category category, int categoryID)
        {
            using (var context = new ResturantDataContext())
            {
                var categoryItem = context.Categories.SingleOrDefault(a => a.ID == Convert.ToInt32(categoryID));
                if (categoryItem != null && categoryItem.ID != 0)
                {
                    categoryItem.CategoryName = category.CategoryName ;
                    categoryItem.CategoryID = category.CategoryID;
                    context.SubmitChanges();
                    return true;
                }

                return false;
            }
        }

        public int ValidateCategory(string CategoryName)
        {
            using (var context = new ResturantDataContext())
            {
                var categoryItem = context.Categories.SingleOrDefault(a => a.CategoryName.Equals(CategoryName,StringComparison.OrdinalIgnoreCase));
                if (categoryItem != null && categoryItem.ID != 0)
                {
                    return categoryItem.CategoryID;
                }
                return 0;
            }
        }
    }
}
