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
        private readonly ApiContetx contetx;

        public PaisesController(ApiContetx contetx)
        {
            this.contetx = contetx;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Pais>> Get()
        {
            return contetx.Pais.ToList();
        }
        [HttpGet("{id}", Name = "ObtenerPaisPorId")]
        public ActionResult<Pais> Get(int id) 
        {
            var pais = contetx.Pais.FirstOrDefault(p=> p.Id == id);
            if (pais == null)
            {
                return NotFound();
            }
            return pais;
        }
        [HttpPost]
        public ActionResult<Pais> Post([FromBody] Pais pais)
        {
            contetx.Pais.Add(pais);
            contetx.SaveChanges();
            //return pais;
            return new CreatedAtRouteResult("ObtenerPaisPorId", new {id=pais.Id }, pais);
        }
        [HttpPut("{id}")]
        public ActionResult<Pais> Put(int id, [FromBody] Pais pais) 
        {
            if (id != pais.Id)
            {
                return BadRequest();
            }
            contetx.Entry(pais).State = EntityState.Modified;
            contetx.SaveChanges();
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult<Pais> Delete(int id) 
        {
            var pais = contetx.Pais.FirstOrDefault(p => p.Id == id);
            if (pais == null)
            {
                return NotFound();
            }
            contetx.Pais.Remove(pais);
            contetx.SaveChanges();
            return Ok();
        }
    }
}
