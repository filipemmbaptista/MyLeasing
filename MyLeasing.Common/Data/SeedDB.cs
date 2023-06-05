using Microsoft.AspNetCore.Identity;
using MyLeasing.Common.Data.Entities;
using MyLeasing.Common.Helpers;
using MyLeasing.Common.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MyLeasing.Common.Data
{
    public class SeedDB
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public SeedDB(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            var user = await _userHelper.GetUserByEmailAsync("prime.HSRS33LE60@gmail.com".ToLower());
            if (user == null)
            {
                user = await AddUser("HSRS33LE60", "Prime", "Admin", "Street default, nº3");
            }

            if (!_context.Owners.Any())
            {
                await AddOwner("AK192KSPA9", "Joao", "Rodrigues", $"Street default, nº19");
                await AddOwner("PSK2938KS0", "Maria", "Callas", $"Street default, nº728");
                await AddOwner("JGUR6WJ3N8", "Maria", "Lopes", $"Street default, nº6");
                await AddOwner("MC6D83JDSG", "Rui", "Costa", $"Street default, nº33");
                await AddOwner("LLDHYWI280", "Rafael", "Santos", $"Street default, nº80");
                await AddOwner("72MSJJI80M", "Filipe", "Baptista", $"Street default, nº48");
                await AddOwner("2654HNDGH3", "Luis", "Patricio", $"Street default, nº65");
                await AddOwner("TBC2DU289Q", "Ruben", "Mateus", $"Street default, nº1");
                await AddOwner("L32HSIU38M", "Catarina", "Esperanca", $"Street default, nº13");
                await AddOwner("TFDHURYG23", "Ricardo", "Salgado", $"Street default, nº28");
                await _context.SaveChangesAsync();
            }

            if (!_context.Lessee.Any())
            {
                await AddLessee("HJKB34E21N", "Daniel", "Nicolau", $"Street default, nº17");
                await AddLessee("34IOUBH2S2", "Ricardo", "Saraiva", $"Street default, nº91");
                await AddLessee("FVDG98S7HY", "Hugo", "Sousa", $"Street default, nº7");
                await AddLessee("45C78NVT9D", "Guilherme", "Casanova", $"Street default, nº25");
                await AddLessee("F547N89YMD", "Celinia", "Texas", $"Street default, nº3");
                await _context.SaveChangesAsync();
            }
        }

        private async Task AddOwner(string doc, string fname, string lname, string address)
        {
            var user = await _userHelper.GetUserByEmailAsync($"{fname}.{doc}@gmail.com".ToLower());
            if (user == null)
            {
                user = await AddUser(doc, fname, lname, address);
            }

            _context.Owners.Add(new Owner
            {
                Document = doc,
                FirstName = fname,
                LastName = lname,
                User = user,
                Address = address
            });
        }

        private async Task AddLessee(string doc, string fname, string lname, string address)
        {
            var user = await _userHelper.GetUserByEmailAsync($"{fname}.{doc}@gmail.com".ToLower());
            if (user == null)
            {
                user = await AddUser(doc, fname, lname, address);
            }

            _context.Lessee.Add(new Lessee
            {
                Document = doc,
                FirstName = fname,
                LastName = lname,
                User = user,
                Address = address
            });
        }

        private async Task<User> AddUser(string doc, string fname, string lname, string address)
        {
            var user = new User
            {
                Document = doc,
                FirstName = fname,
                LastName = lname,
                Email = $"{fname}.{doc}@gmail.com".ToLower(),
                UserName = $"{fname}.{doc}@gmail.com".ToLower(),
                Address = address
            };

            var result = await _userHelper.AddUserAsync(user, "123456");

            if (result != IdentityResult.Success)
            {
                throw new InvalidOperationException($"Could not create the user in seeder - {result.Errors.First().Description}");
            }

            return user;
        }
    }
}
