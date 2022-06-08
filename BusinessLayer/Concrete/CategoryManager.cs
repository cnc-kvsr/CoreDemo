using BusinessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        EfCategoryDal efCategoryDal;
        public CategoryManager()
        {
            efCategoryDal = new EfCategoryDal();
        }

        public void AddCategory(Category category)
        {
            efCategoryDal.Insert(category);
        }

        public void DeleteCategory(Category category)
        {
            efCategoryDal.Delete(category);
        }

        public Category GetByID(int id)
        {
           return efCategoryDal.GetByID(id);
        }

        public List<Category> GetList()
        {
            return efCategoryDal.GetAll();
        }

        public void UpdateCategory(Category category)
        {
            efCategoryDal.Update(category);
        }
    }
}
