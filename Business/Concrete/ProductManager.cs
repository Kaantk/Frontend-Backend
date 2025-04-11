using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constans;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal) 
        {
            _productDal = productDal;
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetList()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetList().ToList());
        }

        public IDataResult<List<Product>> GetListByCategory(int categoryId)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetList(p => p.CategoryId == categoryId).ToList());
        }

        public IResult Add(Product product)
        {
            return new SuccessResult(true, Messages.ProductAdded);
        }

        public IResult Delete(Product product)
        {
            return new SuccessResult(true, Messages.ProductDeleted);
        }

        public IResult Update(Product product)
        {
            return new SuccessResult(true, Messages.ProductUpdated);
        }

        //public void Add(Product product)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Delete(Product product)
        //{
        //    _productDal.Delete(product);
        //}

        //public Product GetById(int productId)
        //{
        //    return _productDal.Get(p => p.ProductId == productId);
        //}

        //public List<Product> GetList()
        //{
        //    return _productDal.GetList().ToList();
        //}

        //public List<Product> GetListByCategory(int categoryId)
        //{
        //    return _productDal.GetList(p => p.CategoryId == categoryId).ToList();
        //}

        //public void Update(Product product)
        //{
        //    _productDal.Update(product);
        //}
    }
}
