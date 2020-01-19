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
    public class PizzasController : ControllerBase
    {
        private _2019SBDContext _context;
        public PizzasController(_2019SBDContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetPizzas()
        {
            return Ok(_context.AcPizzas.ToList());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetPizzaIngredient(int id)
        {
            var acPizza = _context.AcPizzas.FirstOrDefault(e => e.Id == id);
            if (acPizza == null)
            {
                return NotFound();
            }

            return Ok(acPizza);
        }

        [HttpPost]
        public IActionResult Create(AcPizzas newPizza)
        {

            var newId = _context.AcPizzas.OrderByDescending(i => i.Id).FirstOrDefault().Id + 1;
            newPizza.Id = newId;

            _context.AcPizzas.Add(newPizza);
            _context.SaveChanges();

            return StatusCode(201, newPizza);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, AcPizzas pizza)
        {
            if (_context.AcPizzaIngredients.Count(e => e.Id == id) == 0)
            {
                return NotFound();
            }

            _context.AcPizzas.Attach(pizza);
            _context.Entry(pizza).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(pizza);

        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var pizza = _context.AcPizzas.FirstOrDefault(e => e.Id == id);
            if (pizza == null)
            {
                return NotFound();
            }

            _context.AcPizzas.Remove(pizza);
            _context.SaveChanges();

            return Ok(pizza);
        }

    }
}