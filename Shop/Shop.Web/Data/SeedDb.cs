
namespace Shop.Web.Data
{
    using Entities;
    using Microsoft.AspNetCore.Identity;
    using Shop.Web.Helpers;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class SeedDb
    {
        private readonly DataContext context;
        private readonly IUserHelper userHelper;
        private Random random;

        public string PhoneNumber { get; private set; }

        public SeedDb(DataContext context,IUserHelper userHelper)
        {
            this.context = context;
            this.userHelper = userHelper;
            this.random = new Random();
        }

        public async Task SeedAsync()
        {

            await this.context.Database.EnsureCreatedAsync();

            var user = await this.userHelper.GetUserByEmailAsync("diegohenderson425@outlook.com");
            if (user == null)
            {
                user = new User
                {
                    FirstName = "Diego",
                    LastName = "Henderson  ",
                    Email = "diegohenderson425@outlook.com",
                    UserName = "diegohenderson425@outlook.com",
                    PhoneNumber = "3512688446",
                };
                var result = await this.userHelper.AddUserAsync(user, "123456");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }
            };
            if (!this.context.Products.Any())
            {
                this.AddProduct("First Product",user);
                this.AddProduct("Second Product",user);
                this.AddProduct("Third Product",user);
                await this.context.SaveChangesAsync();
            }
        }

        private void AddProduct(string name, User user)
        {
            this.context.Products.Add(new Product
            {
                Name = name,
                Price = this.random.Next(100),
                IsAvailabe = true,
                Stock = this.random.Next(100),
                User = user,
            });
        }

    }

}


