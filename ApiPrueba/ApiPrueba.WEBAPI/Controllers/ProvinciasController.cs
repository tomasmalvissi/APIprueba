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
        private readonly ApiContetx contetx;

        public ProvinciasController(ApiContetx contetx)
        {
            this.contetx = contetx;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Provincia>> Get() 
        {
            return contetx.Provincias.Include(p => p.Pais).ToList();
        }
        [HttpGet("{id}", Name = "ObtenerProvinciaPorId")]
        public ActionResult<Provincia> Get(int id) 
        {
            var provincia = contetx.Provincias.FirstOrDefault(p => p.Id == id);
            if (provincia == null)
            {
                return NotFound();
            }
            return provincia;
        }
        [HttpPost]
        public ActionResult<Provincia> Post([FromBody] Provincia provincia) 
        {
            contetx.Provincias.Add(provincia);
            contetx.SaveChanges();

            return new CreatedAtRouteResult("ObtenerProvinciaPorId", new { id = provincia.Id }, provincia);
        }
    }
}
