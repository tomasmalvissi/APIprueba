using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPrueba.WEBAPI.Data.Entities
{
    public class Provincia
    {
        public int Id { get; set; }
        [Required]
        public string CodProv { get; set; }
        [Required]
        public string NomProv { get; set; }
        public Pais Pais { get; set; }
    }
}
