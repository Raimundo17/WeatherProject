using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WeatherProject.Data.Entities;
using WeatherProject.Helpers;

namespace WeatherProject.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _context.Database.MigrateAsync(); // ver se a base de dados está criada (o seed ao correr cria a tabela das migrações)

            await _userHelper.CheckRoleAsync("Admin");
            await _userHelper.CheckRoleAsync("visitor");

            var user = await _userHelper.GetUserByEmailAsync("weatherproject77@gmail.com"); // ver se ja existe utilizador, o primeiro a ser criado é o admin pela propria aplicacao
            if (user == null) // se nao existir
            {
                user = new User
                {
                    FirstName = "Daniel",
                    LastName = "Raimundo",
                    Email = "weatherproject77@gmail.com",
                    UserName = "weatherproject77@gmail.com",
                    //ImageUrl = "~/wwwroot/images/Admin/avatar-2.jpg"
                };

                var result = await _userHelper.AddUserAsync(user, "123456");// os dois paramentros a passar é o user e a password á parte do objeto para poder ser encriptada

                if (result != IdentityResult.Success) // se houve algum problema a criar
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }

                await _userHelper.AddUserToRoleAsync(user, "Admin");
                var token = await _userHelper.GenerateEmailConfirmationTokenAsync(user);   //video 33
                await _userHelper.ConfirmEmailAsync(user, token);  //video 33
            }

            var isInRole = await _userHelper.IsUserInRoleAsync(user, "Admin");
            if (!isInRole)
            {
                await _userHelper.AddUserToRoleAsync(user, "Admin");
            }

        }
    }
}
