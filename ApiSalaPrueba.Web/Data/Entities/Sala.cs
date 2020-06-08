using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiSalaPrueba.Web.Data.Entities
{
    public class Sala
    {
        public int Id { get; set; }
        [Required]
        public string NomSala { get; set; }
        public string CodSala { get; set; }
    }
}
