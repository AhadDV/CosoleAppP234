

using Wolt.Core.Models;

namespace Wolt.Service.Services.Interfaces
{
    public interface IRestaurantService
    {
        public Task<string> CreateAsync(string name, string adress, string number, int review);
        public Task<string> DeleteAsync(int id);
        public Task<string> UpdateAsync(int id,string name, string adress, string phone,int review);
        public Task<Restaurant> GetAsync(int id);
        public Task GetAllAsync();
        public Task<List<Product>> GetAllProductsAsync(int id);
    }
}
