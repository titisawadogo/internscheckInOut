using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using internscheckInOut.Data;
using internscheckInOut.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace internscheckInOut.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class internsCheckController : Controller
    {
        private readonly CheckInOutDbContext checkInOutDbContext;

        public internsCheckController(CheckInOutDbContext CheckInOutDbContext)
        {
            this.checkInOutDbContext = CheckInOutDbContext;
        }

        // Get All CheckInOuts*********************************************************************************
        [HttpGet]
        public async Task<IActionResult> GetAllCheckInOuts()
        {
           var checkInOuts = await checkInOutDbContext.CheckInOuts.ToListAsync();
            return Ok(checkInOuts);
        }



        // Get a single checkInOut*********************************************************************************
        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetOneCheckInOut")]
        public async Task<IActionResult> GetOneCheckInOut([FromRoute] Guid id)
        {
            var checkInOut = await checkInOutDbContext.CheckInOuts.FirstOrDefaultAsync(x => x.Id == id);
            if (checkInOut != null)
            {
                return Ok(checkInOut);
            }

            return NotFound("Data not found");
        }



        // Create a checkInOut*********************************************************************************
        [HttpPost]
        public async Task<IActionResult> AddCheckInOut([FromBody] CheckInOut checkInOut)
        {
            // To create a new Guid "ID"
            checkInOut.Id = Guid.NewGuid();

            await checkInOutDbContext.CheckInOuts.AddAsync(checkInOut);
            await checkInOutDbContext.SaveChangesAsync();

            // It will create and give the location of the new data
            return CreatedAtAction(nameof(GetOneCheckInOut), new { id = checkInOut.Id }, checkInOut);
        }



        // Update checkInOut(s)*********************************************************************************
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateCheckInOut([FromRoute] Guid id, [FromBody] CheckInOut checkInOut)
        {
            var existingCheckInOut = await checkInOutDbContext.CheckInOuts.FirstOrDefaultAsync(x => x.Id == id);
            if (existingCheckInOut != null)
            {
                existingCheckInOut.internName = checkInOut.internName;
                existingCheckInOut.positionId = checkInOut.positionId;
                existingCheckInOut.teamId = checkInOut.teamId;
                existingCheckInOut.date = checkInOut.date;
                existingCheckInOut.checkinTime = checkInOut.checkinTime;
                existingCheckInOut.checkoutTime = checkInOut.checkoutTime;

                await checkInOutDbContext.SaveChangesAsync();

                return Ok(existingCheckInOut);

            }

            return NotFound("Data not found");
        }




        // Delete checkInOut(s)*********************************************************************************
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteCheckInOut([FromRoute] Guid id)
        {
            var existingCheckInOut = await checkInOutDbContext.CheckInOuts.FirstOrDefaultAsync(x => x.Id == id);
            if (existingCheckInOut != null)
            {
                // This will delete the data
                checkInOutDbContext.Remove(existingCheckInOut);

                await checkInOutDbContext.SaveChangesAsync();

                return Ok(existingCheckInOut);
            }

            return NotFound("Data not found");
        }
    }
}

