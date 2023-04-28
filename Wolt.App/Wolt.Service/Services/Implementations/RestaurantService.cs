

using System.Text.RegularExpressions;
using Wolt.Core.Models;
using Wolt.Data.Repositories.Restaurants;
using Wolt.Service.Services.Interfaces;

namespace Wolt.Service.Services.Implementations
{
    public class RestaurantService : IRestaurantService
    {
        private readonly  RestaurantRepository _repository = new RestaurantRepository();

        public async Task<string> CreateAsync(string name, string adress, string number, int review)
        {

            Console.ForegroundColor = ConsoleColor.Red;
            if (string.IsNullOrWhiteSpace(name))
                return "Add valid name";

            if (string.IsNullOrWhiteSpace(adress))
                return "Add valid adress";

            Regex regex = new Regex(@"^(\+994)?(994)?(51|55|77|70|60|90|99|050|051|055|077|070|060|090|099)\d{7}$");

            bool result = regex.IsMatch(number);

            if (!result)
                return "add valid phone number";

            if (review > 5 || review <= 0)
                return "add valid review";

            Console.ForegroundColor = ConsoleColor.Green;

            Restaurant restaurant = new Restaurant(name, adress, number, review);
            await _repository.AddAsync(restaurant);
            return "Successfully created";
        }

        public async Task<string> DeleteAsync(int id)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Restaurant restaurant = await _repository.GetAsync(res => res.Id == id);

            if (restaurant == null)
                return "restaurant not found";

            await _repository.RemoveAsync(restaurant);

            Console.ForegroundColor = ConsoleColor.Green;

            return "success";

        }

        public async Task GetAllAsync()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (var item in await _repository.GetAllAsync())
            {
                Console.WriteLine(item);
            }
        }

        public async Task<List<Product>> GetAllProductsAsync(int id)
        {
            Restaurant restaurant = await _repository.GetAsync(res=>res.Id==id);

            if (restaurant == null)
            {
                Console.ForegroundColor= ConsoleColor.Red;
                Console.WriteLine("restaurant not found");
                return null;
            }

            return restaurant.Products;
               
        }

        public async Task<Restaurant> GetAsync(int id)
        {
            Restaurant restaurant = await _repository.GetAsync(res => res.Id == id);

            if (restaurant == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("restaurant not found");
                return null;
            }
            return restaurant;

        }

        public async Task<string> UpdateAsync(int id,string name,string adress,string number,int review)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            if (string.IsNullOrWhiteSpace(name))
                return "Add valid name";

            if (string.IsNullOrWhiteSpace(adress))
                return "Add valid adress";

            Regex regex = new Regex(@"^(\+994)?(994)?(51|55|77|70|60|90|99|050|051|055|077|070|060|090|099)\d{7}$");

            bool result = regex.IsMatch(number);

            if (!result)
                return "add valid phone number";

            if (review > 5 || review <= 0)
                return "add valid review";

            Restaurant restaurant = await _repository.GetAsync(x=>x.Id==id);

            if (restaurant == null)
                return "Restaurant not found";


            restaurant.Review = review;
            restaurant.Name = name;
            restaurant.Adress = adress;
            restaurant.PhoneNumber= number;

            Console.ForegroundColor= ConsoleColor.Green;

            return "Updated";

        }
    }
}
