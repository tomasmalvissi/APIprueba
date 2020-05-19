using ApiPrueba.WEBAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPrueba.WEBAPI.Data
{
    public class ApiContetx : DbContext
    {
        public ApiContetx(DbContextOptions<ApiContetx> dbop) : base(dbop)
        {

        }
        public DbSet<Pais> Pais { get; set; }
    }
}
