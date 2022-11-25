using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SAMCLIENTAPI.data;
using SAMCLIENTAPI.models;

namespace SAMCLIENTAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly DataContext _con;

        public CustomerController(DataContext con)
        {
            _con = con;
        }
        [HttpGet]
        public async Task<ActionResult<List<customer>>> GetCustomers()
        {
            return Ok(await _con.customers.ToListAsync());

        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult>GetCustomer([FromRoute] int id)
        {
            var customer =await  _con.customers.FirstOrDefaultAsync(x => x.Id == id);

            if(customer == null)
            {
                return NotFound();
            }

            return Ok(customer); 
        }

        [HttpGet]
        [Route("{customerName}")]
        public async Task<IActionResult> GetCustomerForMerge(string customerName)
        {
            var customer = await _con.customers.FirstOrDefaultAsync(x => x.customerName == customerName);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }




        [HttpPost]

        public async Task<ActionResult<List<customer>>> CreateCustomers(customer Customer)
        {
            _con.customers.Add(Customer);
            await _con.SaveChangesAsync();

            return Ok(await _con.customers.ToListAsync());


        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateCustomers([FromRoute] int id, customer updateCustomerRequest)
        {

            var Customer = await _con.customers.FindAsync(id);

            if (Customer == null)
            {
                return NotFound();
            }

            Customer.customerName = updateCustomerRequest.customerName;
            Customer.customerCode=updateCustomerRequest.customerCode;
            Customer.ABN=updateCustomerRequest.ABN;
            Customer.division=updateCustomerRequest.division;
            Customer.address=updateCustomerRequest.address;
            Customer.contactNo=updateCustomerRequest.contactNo;
            Customer.city=updateCustomerRequest.city;

            await _con.SaveChangesAsync();
            return Ok(Customer);
        

        }

        [HttpDelete]
        [Route("{id:int}")]

        public async Task<IActionResult> DeleteCustomer([FromRoute]int id)
        {
            var dbCustomer = await _con.customers.FindAsync(id);
            if (dbCustomer == null)
            {
                return BadRequest("Customer not found");
            }
            _con.customers.Remove(dbCustomer);
            await _con.SaveChangesAsync();

            return Ok(dbCustomer);


        }
    }
}
