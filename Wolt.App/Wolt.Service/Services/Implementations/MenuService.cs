

using Wolt.Core.Enums;
using Wolt.Core.Models;

namespace Wolt.Service.Services.Implementations
{
    public class MenuService
    {
       
       public bool IsAdmin=false;

        private User[] Users = { new User { UserName = "Code", Password = "Code123" },new User {UserName="Izzat" ,Password="Izzat123"} };
        


        private RestaurantService restaurantService=new RestaurantService();
        private ProductService productService=new ProductService();

        public async Task<bool>  Login()
        {
            Console.WriteLine("Add username");
            string username=Console.ReadLine();
            Console.WriteLine("Add password");
            string password = Console.ReadLine();

            if (Users.Any(x => x.UserName == username && x.Password == password))
            {
                IsAdmin=true;
            }
            else
            {
                Console.WriteLine("Username or password incorrect");
                IsAdmin=false;
            }

            return IsAdmin;
        }

        public async Task ShowMenuAdmin()
        {
            Console.ForegroundColor= ConsoleColor.White;
            string sentence = "Welcome to my App";

            foreach (var item in sentence)
            {
                Thread.Sleep(100);
                Console.Write(item);
            }

            Console.WriteLine("0.Close App");
            Console.WriteLine("1.Create Restaurant");
            Console.WriteLine("2.Show Restaurants");
            Console.WriteLine("3.Show Restaurant by id");
            Console.WriteLine("4.Show Restaurant's products");
            Console.WriteLine("5.Update Restaurant");
            Console.WriteLine("6.Remove Restaurant");
            Console.WriteLine("7.Create Product");
            Console.WriteLine("8.Update Product");
            Console.WriteLine("9.Get Product by restaurant");
            Console.WriteLine("10.Remove Product");
            Console.WriteLine("11.Show All Products");

            string Request=Console.ReadLine();

            while (Request!="0")
            {
                switch (Request)
                {
                    case "1":
                        Console.Clear();
                       await CreateRestaurant();

                        break;
                    case "2":
                        Console.Clear();

                        await ShowRestaurants();
                        break;

                    case "3":
                        Console.Clear();

                        await ShowRestaurantById();
                        break;

                    case "4":
                        Console.Clear();

                        await ShowRestaurantProducts();
                        break;

                    case "5":
                        Console.Clear();

                        await UpdateRestaurant();
                        break;

                    case "6":
                        Console.Clear();

                        await RemoveRestaurant();
                        break;

                    case "7":
                        Console.Clear();

                        await CreateProduct();
                        break;

                    case "8":
                        Console.Clear();

                        await UpdateProduct();
                        break;

                    case "9":
                        Console.Clear();

                        await GetProductByRes(); 
                        break;

                    case "10":
                        Console.Clear();

                        await RemoveProduct();
                        break;

                    case "11":
                        Console.Clear();

                        await ShowAllProducts();
                        break;


                    default:
                        Console.Clear();

                        Console.ForegroundColor= ConsoleColor.Red;
                        Console.WriteLine("Select valid option");
                        break;
                }

                Console.ForegroundColor = ConsoleColor.White;
          
          
                Console.WriteLine("0.Close App");
                Console.WriteLine("1.Create Restaurant");
                Console.WriteLine("2.Show Restaurants");
                Console.WriteLine("3.Show Restaurant by id");
                Console.WriteLine("4.Show Restaurant's products");
                Console.WriteLine("5.Update Restaurant");
                Console.WriteLine("6.Remove Restaurant");
                Console.WriteLine("7.Create Product");
                Console.WriteLine("8.Update Product");
                Console.WriteLine("9.Get Product by restaurant");
                Console.WriteLine("10.Remove Product");
                Console.WriteLine("11.Show All Products");

                 Request = Console.ReadLine();
            }
        }

        public async Task ShowMenuUser()
        {
            Console.ForegroundColor = ConsoleColor.White;
            string sentence = "Welcome to my App";

            foreach (var item in sentence)
            {
                Thread.Sleep(100);
                Console.Write(item);
            }

            Console.WriteLine("0.Close App");
            Console.WriteLine("1.Show Restaurants");
            Console.WriteLine("2.Show Restaurant by id");
            Console.WriteLine("3.Show Restaurant's products");
            Console.WriteLine("4.Get Product by restaurant");
            Console.WriteLine("5.Show All Products");

            string Request = Console.ReadLine();

            while (Request != "0")
            {
                switch (Request)
                {
                    case "1":
                        Console.Clear();
                        await ShowRestaurants();

                        break;
                    case "2":
                        Console.Clear();
                        await ShowRestaurantById();

                        break;

                    case "3":
                        Console.Clear();

                        await ShowRestaurantProducts();
                        break;

                    case "4":
                        Console.Clear();
                        await ShowRestaurantProducts();
                        break;

                    case "5":
                        Console.Clear();

                        await ShowAllProducts();
                        break;

                    default:
                        Console.Clear();

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Select valid option");
                        break;
                }

                Console.ForegroundColor = ConsoleColor.White;


                Console.WriteLine("0.Close App");
                Console.WriteLine("1.Create Restaurant");
                Console.WriteLine("2.Show Restaurants");
                Console.WriteLine("3.Show Restaurant by id");
                Console.WriteLine("4.Show Restaurant's products");
                Console.WriteLine("5.Update Restaurant");
                Console.WriteLine("6.Remove Restaurant");
                Console.WriteLine("7.Create Product");
                Console.WriteLine("8.Update Product");
                Console.WriteLine("9.Get Product by restaurant");
                Console.WriteLine("10.Remove Product");
                Console.WriteLine("11.Show All Products");

                Request = Console.ReadLine();
            }
        }

        private async Task CreateRestaurant()
        {
            Console.ForegroundColor= ConsoleColor.White;
            Console.WriteLine("add name");
            string name=Console.ReadLine();
            Console.WriteLine("add adress");
            string adress = Console.ReadLine();
            Console.WriteLine("add phone");
            string phone = Console.ReadLine();
            Console.WriteLine("add review");
            int.TryParse(Console.ReadLine(),out int review);

          string message=  await restaurantService.CreateAsync(name,adress,phone,review);

            Console.WriteLine(message);
        }

        private async Task ShowRestaurants()
        {
            await restaurantService.GetAllAsync();
        }

        private async Task ShowRestaurantById()
        {
            Console.ForegroundColor = ConsoleColor.White;
 
            Console.WriteLine("add restaurant id");
            int.TryParse(Console.ReadLine(), out int id);

            Restaurant restaurant = await restaurantService.GetAsync(id);

            if(restaurant !=null) {
                Console.WriteLine(restaurant);
            }

            
        }

        private async Task ShowRestaurantProducts()
        {
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("add restaurant id");
            int.TryParse(Console.ReadLine(), out int id);


            List<Product> products =await restaurantService.GetAllProductsAsync(id);

            if (products != null)
            {
                foreach (var item in products)
                {
                    Console.WriteLine(item);
                    Console.WriteLine("---------");
                }
            }
             

        }

        private async Task UpdateRestaurant()
        {
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("add restaurant id");
            int.TryParse(Console.ReadLine(), out int id);
            Console.WriteLine("add name");
            string name = Console.ReadLine();
            Console.WriteLine("add adress");
            string adress = Console.ReadLine();
            Console.WriteLine("add phone");
            string phone = Console.ReadLine();
            Console.WriteLine("add review");
            int.TryParse(Console.ReadLine(), out int review);


            string message = await restaurantService.UpdateAsync(id,name,adress,phone,review);

            Console.WriteLine(message);
        }

        private async Task RemoveRestaurant()
        {
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("add restaurant id");
            int.TryParse(Console.ReadLine(), out int id);

           string message=await restaurantService.DeleteAsync(id);

            Console.WriteLine(message);


        }


        private async Task CreateProduct()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("add restaurant id");
            int.TryParse(Console.ReadLine(), out int id);
            Console.WriteLine("add name");
            string name = Console.ReadLine();

            Console.WriteLine("add price");
            int.TryParse(Console.ReadLine(), out int price);

            Console.WriteLine("add discount price");
            int.TryParse(Console.ReadLine(), out int discountprice);

            Console.WriteLine("add discount description");
            string description=Console.ReadLine();

            ProductCategory category;
            Console.WriteLine("choose category");
            foreach (var item in Enum.GetValues(typeof(ProductCategory)))
            {
                Console.WriteLine((int)item+"."+item);
            }
            int.TryParse(Console.ReadLine(), out int categoryindex);

            var result= Enum.GetName(typeof(ProductCategory), categoryindex);

            //bool result=Enum.IsDefined(typeof(ProductCategory), categoryindex);

            while (result==null)
            {
                Console.WriteLine("choose valid category");
                int.TryParse(Console.ReadLine(), out  categoryindex);
                result = Enum.GetName(typeof(ProductCategory), categoryindex);
            }
            category = (ProductCategory)categoryindex;

            string message = await productService.CreateAsync(id,name,price,discountprice,description,category);

            Console.WriteLine(message);
        }


       private async Task UpdateProduct()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("add restaurant id");
            int.TryParse(Console.ReadLine(), out int resid);
            Console.WriteLine("add product id");
            int.TryParse(Console.ReadLine(), out int prodid);
            Console.WriteLine("add name");
            string name = Console.ReadLine();

            Console.WriteLine("add price");
            int.TryParse(Console.ReadLine(), out int price);

            Console.WriteLine("add discount price");
            int.TryParse(Console.ReadLine(), out int discountprice);

            Console.WriteLine("add discount description");
            string description = Console.ReadLine();


            string message = await productService.UpdateAsync(resid,prodid, name, price, discountprice, description);

            Console.WriteLine(message);
        }

        private async Task GetProductByRes()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("add restaurant id");
            int.TryParse(Console.ReadLine(), out int resid);
            Console.WriteLine("add product id");
            int.TryParse(Console.ReadLine(), out int prodid);

           Product product = await productService.GetAsync(resid,prodid);

            if (product!=null)
            {
                Console.WriteLine(product);
            }
        }

        private async Task RemoveProduct()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("add restaurant id");
            int.TryParse(Console.ReadLine(), out int resid);
            Console.WriteLine("add product id");
            int.TryParse(Console.ReadLine(), out int prodid);

            string message= await productService.DeleteAsync(resid, prodid);

            Console.WriteLine(message);
        }

        private async Task ShowAllProducts()
        {
            await productService.GetAll();
        }
    }
}
