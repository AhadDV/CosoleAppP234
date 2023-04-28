

using System.Diagnostics;
using System.Xml.Linq;
using Wolt.Core.Enums;
using Wolt.Core.Models;
using Wolt.Data.Repositories.Restaurants;
using Wolt.Service.Services.Interfaces;

namespace Wolt.Service.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly RestaurantRepository _repository=new RestaurantRepository();
        public async Task<string> CreateAsync(int id,string name, double price, double discountprice, string desc,ProductCategory category)
        {
            Console.ForegroundColor= ConsoleColor.Red;

            Restaurant restaurant = await _repository.GetAsync(res=>res.Id==id);

            if (await ValidateProduct(name, price, discountprice, desc) != null)
            {
                return await ValidateProduct(name, price, discountprice, desc);
            }

            Product product = new Product(name,price,discountprice,desc,category,restaurant);

            
            restaurant.Products.Add(product);

            Console.ForegroundColor = ConsoleColor.Green;
            return "Created";
        }

        public async Task<string> DeleteAsync(int resId, int prodId)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Restaurant restaurant = await _repository.GetAsync(res => res.Id == resId);

            if (restaurant == null)
                return "restorant not found";

            Product product=restaurant.Products.FirstOrDefault(prod=>prod.Id==prodId);

            if(product==null)
                return "product not found";

            restaurant.Products.Remove(product);
            Console.ForegroundColor = ConsoleColor.Green;

            return "deleted";
        }

        public async Task GetAll()
        {
            foreach (var item in  await _repository.GetAllAsync())
            {
        
                foreach (var prod in item.Products)
                {
                    Console.WriteLine(prod);
                }
            }
        }

        public async Task<Product> GetAsync(int resId, int prodId)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Restaurant restaurant = await _repository.GetAsync(res => res.Id == resId);

            if (restaurant == null)
            {
                Console.WriteLine("restorant not found");
                return null;
            }
              

            Product product = restaurant.Products.FirstOrDefault(prod => prod.Id == prodId);

            if (product == null)
            {
                Console.WriteLine("product not found");
                return null;
            }
             
            return product;
        }

        public async Task<string> UpdateAsync(int resId, int prodId, string name, double price, double discountprice, string desc)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Restaurant restaurant = await _repository.GetAsync(res => res.Id == resId);

            if (restaurant == null)
                return "restorant not found";

            if (await ValidateProduct(name, price, discountprice, desc)!=null)
            {
                return await ValidateProduct(name, price, discountprice, desc);
            }

            Product product = restaurant.Products.FirstOrDefault(prod => prod.Id == prodId);

            product.Name= name;
            product.Price= price;
            product.DiscountPrice=discountprice;
            product.Description= desc;

            return "updated";
        }


        private async Task<string> ValidateProduct(string name, double price, double discountprice, string desc)
        {
           
            if (string.IsNullOrWhiteSpace(name))
                return "add valid name";

            if (price <= 0)
                return "add valid price";

            if (discountprice > price || discountprice <= 0)
                return "add valid discountprice";

            return null;
        }
    }
}
