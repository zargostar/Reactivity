using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ActivityController:ControllerBase
    {
        private readonly DataContext _context;

        public ActivityController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {

            var res = await _context.Activities.ToListAsync();
            return res;



        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetActivity(Guid id)
        {


            var result = await _context.Activities.FirstOrDefaultAsync(x => x.Id == id);
            if (result is null)
            {
                throw new Exception($"{id} Is not found");

            }
            return result;
        }
    }
}