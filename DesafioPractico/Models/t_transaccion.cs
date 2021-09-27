using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DesafioPractico.Models
{
    public class t_transaccion
    {
        [Key]
        public int id { get; set; }


        [StringLength(25)]
        [Required(ErrorMessage = "Campo requerido")]
        public string tipo { get; set; }
    }
}