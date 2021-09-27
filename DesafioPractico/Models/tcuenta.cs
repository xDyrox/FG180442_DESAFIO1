using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DesafioPractico.Models
{
    public class tcuenta
    {

        [Key]
        public int id { get; set; }


        [StringLength(200)]
        [Required(ErrorMessage = "Campo requerido")]
        public string tipo { get; set; }

        public bool Activo { get; set; }
    }
}