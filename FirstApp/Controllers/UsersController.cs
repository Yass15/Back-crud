using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using FirstApp.Models.Users;
using FirstApp.Services;
using FirstApp.Entities;
using FirstApp.Repository;
using System.Threading.Tasks;

namespace FirstApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : MyMDBController<User, EfCoreUserRepository>
    {
        public UsersController(EfCoreUserRepository repository) : base(repository)
        {
        }
    }
}
