using ApiPrueba.WEBAPI.Data;
using ApiPrueba.WEBAPI.Data.Entities;
using Microsoft.AspNetCore.Mvc;
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
    }
}
