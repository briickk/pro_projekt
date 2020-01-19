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
    public class IngredientsController : ControllerBase
    {
        private _2019SBDContext _context;
        public IngredientsController(_2019SBDContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetIngredients(int id)
        {
            return Ok(_context.AcIngredients.ToList());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetIngredient(int id)
        {
            var acIngredient = _context.AcIngredients.FirstOrDefault(e => e.Id == id);
            if (acIngredient == null)
            {
                return NotFound();
            }

            return Ok(acIngredient);
        }

        [HttpPost]
        public IActionResult Create(AcIngredients newIngredient)
        {
            _context.AcIngredients.Add(newIngredient);
            _context.SaveChanges();

            return StatusCode(201, newIngredient);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, AcIngredients ingredient)
        {
            if (_context.AcIngredients.Count(e => e.Id == id) == 0)
            {
                return NotFound();
            }

            _context.AcIngredients.Attach(ingredient);
            _context.Entry(ingredient).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(ingredient);

        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var ingredient = _context.AcIngredients.FirstOrDefault(e => e.Id == id);
            if (ingredient == null)
            {
                return NotFound();
            }

            _context.AcIngredients.Remove(ingredient);
            _context.SaveChanges();

            return Ok(ingredient);
        }



    }
}