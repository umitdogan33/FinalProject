using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            var results = productManager.GetProductDetails();

            if (results.Success==true)
            {
                foreach (var product in results.Data)
                {
                    Console.WriteLine(product.ProductName);
                }
            }

            else
            {
                Console.WriteLine(results.Message);
            }
            
        }

        
    }
}
