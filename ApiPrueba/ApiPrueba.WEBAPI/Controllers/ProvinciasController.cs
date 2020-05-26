using ApiPrueba.WEBAPI.Data;
using ApiPrueba.WEBAPI.Data.Entities;
using ApiPrueba.WEBAPI.Migrations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPrueba.WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvinciasController : ControllerBase
    {
        private readonly ApiContetx context;

        public ProvinciasController(ApiContetx context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Provincia>> Get() 
        {
            return context.Provincias.Include(p => p.Pais).ToList();
        }
        [HttpGet("ProvById/{id}", Name = "ProvById")]
        public ActionResult<Provincia> GetProvById(int id) 
        {
            var provincia = context.Provincias.FirstOrDefault(p => p.Id == id);
            if (provincia == null)
            {
                return NotFound();
            }
            return provincia;
        }
        [HttpPost]
        public ActionResult<Provincia> Post([FromBody] Provincia provincia) 
        {
            context.Provincias.Add(provincia);
            context.SaveChanges();

            return new CreatedAtRouteResult("ProvById", new { id = provincia.Id }, provincia);
        }
        [HttpGet("ProvByCod/{cod}")]
        public ActionResult<Provincia> GetProvByCod(string cod)
        {
            var provincia = context.Provincias.Include(p => p.Pais).FirstOrDefault(p => p.CodProv == cod);
            if (provincia == null)
            {
                return NotFound();
            }
            return provincia;
        }
        [HttpPut("{id}")]
        public ActionResult<Provincia> Put(int id, [FromBody] Provincia provincia)
        {
            if (id != provincia.Id)
            {
                return BadRequest();
            }

            context.Entry(provincia).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult<Provincia> Delete(int id)
        {
            var provincia = context.Provincias.FirstOrDefault(p => p.Id == id);
            if (provincia == null)
            {
                return NotFound();
            }
            context.Provincias.Remove(provincia);
            context.SaveChanges();
            return Ok();
        }
    }
}
