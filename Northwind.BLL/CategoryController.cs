using Core.DataAccess;
using Northwind.DAL;
using Northwind.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.BLL
{
    public class CategoryController
    {
        IRepository<Category> _cr;
        public CategoryController()
        {
            _cr = new Repository<Category>();
        }

        public List<CategoryDTO> GetCategories()
        {
            List<Category> categories = _cr.GetList();
            return EntityToDto(categories);
        }

        private CategoryDTO EntityToDto(Category entity)
        {
            CategoryDTO dto = new CategoryDTO
            {
                CategoryID = entity.CategoryID,
                CategoryName = entity.CategoryName,
                Description = entity.Description
            };
            return dto;
        }

        private List<CategoryDTO> EntityToDto(List<Category> entityList)
        {
            List<CategoryDTO> dtoList = new List<CategoryDTO>();
            foreach (var entity in entityList)
            {
                CategoryDTO dto = EntityToDto(entity);
                dtoList.Add(dto);
            }
            return dtoList;
        }
    }
}
