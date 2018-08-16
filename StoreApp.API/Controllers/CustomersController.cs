using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StoreApp.API.Data;
using Microsoft.EntityFrameworkCore;

namespace StoreApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController: ControllerBase
    {
        private readonly DataContext db;

        public CustomersController(DataContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers(){
            return Ok(await db.Customers.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(int id){
            return Ok(await db.Customers.FirstOrDefaultAsync(x => x.Id==id));
        }


    }
}