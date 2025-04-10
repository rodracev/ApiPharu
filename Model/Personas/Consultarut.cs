using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPharu.Model.Personas
{
    public class Consultarut
    {
       [Key]
        public string Rut { get; set; }
        public string Estado { get; set; }
        public string Motivo { get; set; }   
    }
}