using DBCRUD.Models.DBModels;
using DBCRUDProject.DataContext;
using DBCRUDProject.Models.APIModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace DBCRUDProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DrinkController : ControllerBase
    {

        private readonly MyContext _context;

        private readonly ILogger<DrinkController> _logger;

        public DrinkController(ILogger<DrinkController> logger, MyContext context)
        {
            _logger = logger;
            _context = context;
        }


        [HttpGet]
        [Route("Find")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Find(int id)
        {
            try
            {
                var post = _context.Drink.Where(p => p.DrinkID == id).FirstOrDefault();

                return Ok(post);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Create")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateDrinkModel data)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var model = new DrinkModel()
                {
                    DrinkName = data.DrinkName,
                    DrinkPrice = data.DrinkPrice,
                    CreateTime = DateTime.Now,
                    UpdateTime = DateTime.Now
                };
                _context.Add(model);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("Update")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Update([FromBody] UpdateDrinkModel data)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var post = await _context.Drink.FindAsync(data.DrinkID);
                post.DrinkName = data.DrinkName;
                post.DrinkPrice = data.DrinkPrice;
                post.UpdateTime = DateTime.Now;

                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("Delete")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var post = await _context.Drink.FindAsync(id);
                _context.Drink.Remove(post);

                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
