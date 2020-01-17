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
    public class PizzaIngredientsController : ControllerBase
    {
        private _2019SBDContext _context;
        public PizzaIngredientsController(_2019SBDContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetPizzaIngredients()
        {
            return Ok(_context.AcPizzaIngredients.ToList());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetPizzaIngredient(int id)
        {
            var acIngredient = _context.AcPizzaIngredients.FirstOrDefault(e => e.Id == id);
            if (acIngredient == null)
            {
                return NotFound();
            }

            return Ok(acIngredient);
        }

        [HttpPost]
        public IActionResult Create(AcPizzaIngredients newPizzaIngredient)
        {
            _context.AcPizzaIngredients.Add(newPizzaIngredient);
            _context.SaveChanges();

            return StatusCode(201, newPizzaIngredient);
        }

        [HttpPut]
        public IActionResult Update(AcPizzaIngredients pizzaIngredient)
        {
            if (_context.AcPizzaIngredients.Count(e => e.Id == pizzaIngredient.Id) == 0)
            {
                return NotFound();
            }

            _context.AcPizzaIngredients.Attach(pizzaIngredient);
            _context.Entry(pizzaIngredient).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(pizzaIngredient);

        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var pizzaIngredient = _context.AcPizzaIngredients.FirstOrDefault(e => e.Id == id);
            if (pizzaIngredient == null)
            {
                return NotFound();
            }

            _context.AcPizzaIngredients.Remove(pizzaIngredient);
            _context.SaveChanges();

            return Ok(pizzaIngredient);
        }

    }
}