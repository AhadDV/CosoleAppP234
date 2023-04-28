

using Wolt.Core.Models.Base;

namespace Wolt.Core.Models
{
    public class Restaurant : BaseModel
    {
        private static int _id;
        public string Adress { get; set; }
        public string PhoneNumber { get; set; }
        public int Review { get; set; }
        public List<Product> Products;

        public Restaurant(string name,string adress,string phonenumber,int review)
        {
            _id++;
            Id= _id;
            Name= name;
            Adress= adress;
            PhoneNumber= phonenumber;
            Review= review;
            Products= new List<Product>();
            CreatedDate= DateTime.UtcNow.AddHours(4);
        }

        public override string ToString()
        {
            return $"Name: {Name}, Adress: {Adress}, Phone: {PhoneNumber}, Review: {Review}, CreateDate: {CreatedDate}, IpdateDate: {UpdatedDate}";
        }
    }
}
