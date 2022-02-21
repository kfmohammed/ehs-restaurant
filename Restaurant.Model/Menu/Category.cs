using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Restaurant.DataModel;

namespace Restaurant.Model
{
    [Serializable]
    public class Category
    {
        public int ID;
        public string CategoryName;
        public int CategoryID;

        #region Public Methods
        public int ValidateCategory(string categoryName)
        {
            var cat = new Restaurant.Repository.Masters.CategoryItem();
            var categoryID = cat.ValidateCategory(categoryName);

            if (categoryID == 0)
            {
                var catItem = new Restaurant.DataModel.Category { CategoryID = 0, CategoryName = categoryName };
                return cat.AddCategory(catItem);
            }

            return 0;
        }

        public List<Category> GetCategoryList()
        {
            var returnList = new List<Category>();
            var catlist = new Restaurant.Repository.Masters.CategoryItem().GetMenuCategory();

            if (catlist != null)
            {
                returnList.AddRange(catlist.Select(MapDatatoModel));
                return returnList;
            }

            return null;
        }
        

        #endregion

        #region Map POCO objects

        // Maps object from data to model
        private static Category MapDatatoModel(Restaurant.DataModel.Category catItem)
        {
            if (catItem != null)
            {
                return new Category{
                    ID = catItem.ID,
                    CategoryName = catItem.CategoryName,
                    CategoryID = catItem.CategoryID
                };
            }
            return null;
        }

        // Maps object from model to data repository
        private static Restaurant.DataModel.Category MapModeltoData(Category catItem)
        {
            return new Restaurant.DataModel.Category{
                ID = catItem.ID,
                CategoryName = catItem.CategoryName,
                CategoryID = catItem.CategoryID
             };
        }

    #endregion


    }
}
