using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.Core.Enums;
using Wolt.Core.Models;

namespace Wolt.Service.Services.Interfaces
{
    internal interface IProductService
    {
        public Task<string> CreateAsync(int id,string name, double price,double discountprice,string desc, ProductCategory category);
        public Task<string> DeleteAsync(int resId, int prodId);
        public Task<string> UpdateAsync(int resId, int prodId, string name, double price, double discountprice, string desc);
        public Task<Product> GetAsync(int resId,int prodId);
        public Task GetAll();
    }
}
