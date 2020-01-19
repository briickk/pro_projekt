using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzasSizeController : ControllerBase
    {
        private _2019SBDContext _context;
        public PizzasSizeController(_2019SBDContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetPizzasSizes()
        {
            return Ok(_context.AcPizzasSize.ToList());

        }

        [HttpGet("{id:int}")]
        public IActionResult GetPizzasSize(int id)
        {
            var pizzasSize = _context.AcPizzasSize.FirstOrDefault(e => e.Id == id);

            if (pizzasSize == null)
            {
                return NotFound();
            }

            return Ok(pizzasSize);
        }

        [HttpPost]
        public IActionResult CreatePizzasSize(AcPizzasSize pizzasSize)
        {
            var newId = _context.AcPizzasSize.OrderByDescending(e => e.Id).FirstOrDefault().Id + 1;
            pizzasSize.Id = newId;

            _context.AcPizzasSize.Add(pizzasSize);
            _context.SaveChanges();

            return Ok(pizzasSize);
        }

        [HttpPut("{id:int}")]
        public IActionResult ChangePizzasSize(int id, AcPizzasSize pizzasSize)
        {
            if (_context.AcPizzasSize.Count(e => e.Id == id) == 0)
            {
                return NotFound();
            }

            _context.AcPizzasSize.Attach(pizzasSize);
            _context.Entry(pizzasSize).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(pizzasSize);
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeletePizzasSize(int id)
        {
            var pizzasSize = _context.AcPizzasSize.FirstOrDefault(e => e.Id == id);
            if (pizzasSize == null)
            {
                return NotFound();
            }

            _context.AcPizzasSize.Remove(pizzasSize);
            _context.SaveChanges();

            return Ok(pizzasSize);
        }
    }
}