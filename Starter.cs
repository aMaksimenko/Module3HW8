using System;
using System.Collections.Generic;
using HomeWork.Models;
using HomeWork.Services;

namespace HomeWork
{
    public class Starter
    {
        public void Run()
        {
            var users = GenerateUsers();
            var accountServices = new Dictionary<string, AccountService>();

            foreach (var user in users)
            {
                var accountService = new AccountService(user);

                accountService.OnBalanceUpdate += LogMessage;
                accountServices.Add(user.Name, accountService);
            }

            accountServices["John"].Put(500);
            accountServices["John"].Take(300);
            accountServices["Bill"].Put(200);
            accountServices["John"].Take(600);
            accountServices["Terry"].Put(500);
            accountServices["Terry"].Take(350);
            accountServices["John"].Take(100);
        }

        private void LogMessage(object sender, string message)
        {
            Console.WriteLine(message);
        }

        private IEnumerable<User> GenerateUsers()
        {
            return new List<User>()
            {
                new User()
                {
                    Id = 1,
                    Name = "John"
                },
                new User()
                {
                    Id = 2,
                    Name = "Bill"
                },
                new User()
                {
                    Id = 3,
                    Name = "Terry"
                }
            };
        }
    }
}