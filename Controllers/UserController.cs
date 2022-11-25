using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SAMCLIENTAPI.data;
using SAMCLIENTAPI.models;

namespace SAMCLIENTAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _con;

        public UserController(DataContext con)
        {
            _con = con;
        }

        [HttpGet]
        public async Task<ActionResult<List<user>>> GetUsers()
        {
            return Ok(await _con.users.ToListAsync());

        }

        [HttpPost("register")]

        public async Task<ActionResult<List<user>>> CreateUsers(user User)
        {
            _con.users.Add(User);
            await _con.SaveChangesAsync();

            return Ok(await _con.users.ToListAsync());


        }
    }
}
