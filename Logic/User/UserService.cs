using Database.Model;
using Helpers;
using Logic.Model;
using Logic.Tools;
using Microsoft.AspNetCore.Identity.Data;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> userRepo;

        public UserService(IRepository<User>  UserRepo)
        {
            userRepo = UserRepo;
        }

        public async Task<LogInResponse> LogInAsync()
        {
            var user = await userRepo.GetById(1);

            if (user == null)
                throw new DataNotFoundException("User Not Found");

            string AccessToken = JwtService.GenerateJWTToken(user);
          
            return new LogInResponse
            {
                AccessToken = AccessToken,
            };
        }


    }

}
