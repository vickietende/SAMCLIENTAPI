using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SAMCLIENTAPI.data;
using SAMCLIENTAPI.Migrations;
using SAMCLIENTAPI.models;

namespace SAMCLIENTAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly DataContext _con;

        public CityController(DataContext con)
        {
            _con = con;
        }
        [HttpGet]

        //public IEnumerable<cities> GetCities()
        //{
        //    return (IEnumerable<cities>)_con.cities.ToList();
        //}
        public async Task<ActionResult<List<city>>> GetCities()
        {
            return Ok(await _con.cities.ToListAsync());

        }
    }

}
