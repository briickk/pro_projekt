using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    }
}