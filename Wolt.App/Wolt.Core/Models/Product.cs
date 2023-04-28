

using Wolt.Core.Enums;
using Wolt.Core.Models.Base;

namespace Wolt.Core.Models
{
    public class Product:BaseModel
    {
        private static int _id;
        public double Price { get; set; }
        public double DiscountPrice { get; set; }
        public string Description { get; set; }
        public ProductCategory Category { get; set; }
        public Restaurant Restaurant { get; set; }

        public Product(string name,double price, double discountPrice, string description, ProductCategory category, Restaurant restaurant)
        {
            _id++;
            Id = _id;
            Name = name;
            Price = price;
            DiscountPrice = discountPrice;
            Description = description;
            Category = category;
            Restaurant = restaurant;
        }

        public override string ToString()
        {

            if (DiscountPrice < Price)
            {
                return $"there is  {Price-DiscountPrice} discount   Name: {Name}, Price: {DiscountPrice}, Desc: {Description}, Category: {Category} Restaurant: {Restaurant}";
            }


            return $"Name: {Name}, Price: {Price}, Desc: {Description}, Category: {Category} Restaurant: {Restaurant}"; 
        }
    }
}
