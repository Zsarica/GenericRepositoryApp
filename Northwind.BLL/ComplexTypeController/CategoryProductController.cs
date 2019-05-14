using Core.DataAccess;
using Northwind.DAL;
using Northwind.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.BLL.ComplexTypeController
{
    public class CategoryProductController
    {
        IRepository<Product> _pr;
        IRepository<Category> _cr;

        public CategoryProductController()
        {
            _pr = new Repository<Product>();
            _cr = new Repository<Category>();
        }


        public List<ProductCategoryDTO> TumListeyiVer()
        {
            var sorgu = (from p in _pr.GetQuery()
                         join c in _cr.GetQuery() on p.CategoryID equals c.CategoryID
                         select new ProductCategoryDTO()
                         {
                             ProductID = p.ProductID,
                             CategoryID = c.CategoryID,
                             CategoryName = c.CategoryName,
                             ProductName = p.ProductName
                         });

            return sorgu.ToList();
        }

        public List<ProductCategoryDTO> DevamEdenUrunlerListesi()
        {
            
            var sorgu = (from p in _pr.GetQuery(p=>p.Discontinued==false)
                         join c in _cr.GetQuery() on p.CategoryID equals c.CategoryID
                         select new ProductCategoryDTO()
                         {
                             ProductID = p.ProductID,
                             CategoryID = c.CategoryID,
                             CategoryName = c.CategoryName,
                             ProductName = p.ProductName
                         });

            return sorgu.ToList();
        }
    }
}
