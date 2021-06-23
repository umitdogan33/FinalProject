using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BasketManager : IBasketService
    {
        IBasketDal _basketDal;

        public BasketManager(IBasketDal basketDal)
        {
            _basketDal = basketDal;
        }

        public IResult Add(Basket basket)
        {
            _basketDal.Add(basket);
            return new SuccessResult("ekleme işlemi başarılı ");
        }

        public IResult Delete(Basket basket)
        {
            _basketDal.Delete(basket);
            return new SuccessResult("silme işlemi başarılı ");
        }

        public IDataResult<List<Basket>> GetAll()
        {
            return new SuccessDataResult<List<Basket>>(_basketDal.GetAll());
        }

        public IResult Update(Basket basket)
        {
            _basketDal.Update(basket);
            return new SuccessResult("güncelleme işlemi başarılı ");
        }
    }
}
