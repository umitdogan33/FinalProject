using Business.Abstract;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Interceptors;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using System.Linq;
using Business.BusinessAspects.Autofac;
using Core.Aspects.Autofac.Caching;
using System.Transactions;
using Core.Aspects.Autofac.Transaction;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        //burası sadece IProduct tanır
        IProductDal _productdal;

        public ProductManager(IProductDal productdal)
        {
            _productdal = productdal;
        }

        

        [ValidationAspect(typeof(ProductValidator))]
       [CacheRemoveAspect("get")]
       [TransactionScopeAspect]
       [SecuredOperation("admin,product.add")]
        public IResult Add(Product product)
        {
            IResult result = BusinessRules.Run(CheckIfProductCountOfCategoryCorrect(product.CategoryId), SameProductName(product.ProductName));

            if (result != null)
            {
                return result;
            }
            _productdal.Add(product);
            return new SuccessResult(Mesaages.ProductAdded);


        }


        [CacheAspect]
        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour == 20)
            {
                return new ErrorDataResult<List<Product>>(Mesaages.mantaincetime);
            }
            return new SuccessDataResult<List<Product>>(_productdal.GetAll(), Mesaages.ProductsListed);
        }


        [CacheAspect]
        public IDataResult<Product> GetById(int Id)
        {
            var result = _productdal.Get(p => p.ProductId == Id);
            return new SuccessDataResult<Product>(result, Mesaages.ProductsListed);
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productdal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }


        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productdal.GetProductDetails());
        }


        public IDataResult<List<Product>> GetAllByCategoryId(int Id)
        {
            return new SuccessDataResult<List<Product>>(_productdal.GetAll(p => p.CategoryId == Id));
        }


            
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Update(Product product)
        {
            var result = _productdal.GetAll(p => p.CategoryId == product.CategoryId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Mesaages.ProductCountOfCategoryError);
            }
            _productdal.Add(product);
            return new Result(true, "ekleme başarılı ");
        }

        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            var result = _productdal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Mesaages.ProductCountOfCategoryError);
            }

            return new SuccessResult();
        }

        private IResult SameProductName(string ProductName)
        {
            var result = _productdal.GetAll(p => p.ProductName == ProductName).Any();
            if (result)
            {
                return new ErrorResult(Mesaages.ProductNameAlreadyExists);
            }

            return new SuccessResult();
        }

       
       
    }
}
