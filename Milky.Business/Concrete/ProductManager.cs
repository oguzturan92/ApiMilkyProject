using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Milky.Entity.Concrete;
using MilkyProject.Business.Abstract;
using MilkyProject.Data.Abstract;
using MilkyProject.Entity.Concrete;

namespace MilkyProject.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public void Delete(int id)
        {
            _productDal.Delete(id);
        }

        public Product GetById(int id)
        {
            return _productDal.GetById(id);
        }

        public List<Product> GetListAll()
        {
            return _productDal.GetListAll();
        }

        public void Insert(Product entity)
        {
            _productDal.Insert(entity);
        }

        public void Update(Product entity)
        {
            _productDal.Update(entity);
        }
    }
}