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
    public class UsersController : ControllerBase
    {
        private _2019SBDContext _context;
        public UsersController(_2019SBDContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(_context.AcUsers.ToList());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetUser(int id)
        {
            var user = _context.AcUsers.FirstOrDefault(e => e.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public IActionResult CreateUser(AcUsers user)
        {
            var newId = _context.AcUsers.OrderByDescending(e => e.Id).FirstOrDefault().Id + 1;
            user.Id = newId;

            _context.AcUsers.Add(user);
            _context.SaveChanges();

            return StatusCode(201, user);

        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, AcUsers user)
        {
            if (_context.AcUsers.Count(e => e.Id == id) == 0)
            {
                return NotFound();
            }

            _context.AcUsers.Attach(user);
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(user);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var user = _context.AcUsers.FirstOrDefault(e => e.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            _context.AcUsers.Remove(user);
            _context.SaveChanges();

            return Ok(user);
        }

    }
}