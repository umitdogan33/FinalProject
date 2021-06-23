using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBasketDal : EfEntityRepositoryBase<Basket, NorthwindContext>, IBasketDal
    {
        public List<BasketDetailDto> GetBasketDetails()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from ba in context.Baskets
                             join usr in context.Users
                             on ba.UserId equals usr.Id
                             join prd in context.Products
                             on ba.ProductId equals prd.ProductId
                             
                             select new BasketDetailDto
                             {
                                 BasketId=ba.Id,
                                 UserId=usr.Id,
                                 ProductId=prd.ProductId,
                                 ProductName=prd.ProductName,
                                 Count=ba.Count
                             };

                return result.ToList();
            }

        }
    }
}
