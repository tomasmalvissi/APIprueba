using ApiPrueba.WEBAPI.Data;
using ApiPrueba.WEBAPI.Data.Entities;
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
    public class PaisesController : ControllerBase
    {
        private readonly ApiContetx context;

        public PaisesController(ApiContetx context)
        {
            this.context = context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Pais>> Get()
        {
            return context.Pais.Include(p => p.Provincias).ToList();
        }
        [HttpGet("{id}", Name = "ObtenerPaisPorId")]
        public ActionResult<Pais> Get(int id) 
        {
            var pais = context.Pais.Include(p=> p.Provincias).FirstOrDefault(p=> p.Id == id);
            if (pais == null)
            {
                return NotFound();
            }
            return pais;
        }
        [HttpPost]
        public ActionResult<Pais> Post([FromBody] Pais pais)
        {
            context.Pais.Add(pais);
            context.SaveChanges();
            return new CreatedAtRouteResult("ObtenerPaisPorId", new {id=pais.Id }, pais);
        }
        [HttpPut("{id}")]
        public ActionResult<Pais> Put(int id, [FromBody] Pais pais) 
        {
            if (id != pais.Id)
            {
                return BadRequest();
            }
            context.Entry(pais).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult<Pais> Delete(int id) 
        {
            var pais = context.Pais.FirstOrDefault(p => p.Id == id);
            if (pais == null)
            {
                return NotFound();
            }
            context.Pais.Remove(pais);
            context.SaveChanges();
            return Ok();
        }
    }
}
