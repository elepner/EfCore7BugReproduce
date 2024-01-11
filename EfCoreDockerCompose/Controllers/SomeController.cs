using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EfCoreDockerCompose.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SomeController : ControllerBase
    {
        private readonly DbContext _dbContext;

        public SomeController(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet(Name = "GetAllRecords")]
        public async Task<IActionResult> Get()
        {
            await _dbContext.Database.MigrateAsync();
            return Ok(_dbContext.SomeRecords);
        }

        [HttpGet("next", Name = "PlaceSomeData")]
        public async Task<IActionResult> GetNextItem()
        {
            await _dbContext.Database.MigrateAsync();
            var result = await _dbContext.SomeRecords.AddAsync(new SomeRecord { Descritpion = FizzBuzz(_dbContext.SomeRecords.Count()) });
            await _dbContext.SaveChangesAsync();
            return Ok(result.Entity);
        }


        private static string FizzBuzz(int i)
        {
            return (i % 3) switch
            {
                0 when i % 5 == 0 => "FizzBuzz",
                0 => "Fizz",
                _ => i % 5 == 0 ? "Buzz" : i.ToString()
            };
        }
    }
}
