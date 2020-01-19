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
    public class AddressesController : ControllerBase
    {
        private _2019SBDContext _context;
        public AddressesController(_2019SBDContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAddresses()
        {
            return Ok(_context.AcAddresses.ToList());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetAddress(int id)
        {
            var address = _context.AcAddresses.FirstOrDefault(e => e.Id == id);

            if (address == null)
            {
                return NotFound();
            }

            return Ok(address);
        }



        [HttpPost]
        public IActionResult CreateAddress(AcAddresses address)
        {
            var newId = _context.AcAddresses.OrderByDescending(e => e.Id).FirstOrDefault().Id + 1;
            address.Id = newId;

            _context.AcAddresses.Add(address);
            _context.SaveChanges();

            return Ok(address);
        }

        [HttpPut("{id:int}")]
        public IActionResult ChangeAddress(int id, AcAddresses address)
        {
            if (_context.AcAddresses.Count(e => e.Id == id) == 0)
            {
                return NotFound();
            }

            _context.AcAddresses.Attach(address);
            _context.Entry(address).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(address);
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteAddress(int id)
        {
            var address = _context.AcAddresses.FirstOrDefault(e => e.Id == id);
            if (address == null)
            {
                return NotFound();
            }

            _context.AcAddresses.Remove(address);
            _context.SaveChanges();

            return Ok(address);
        }
    }
}