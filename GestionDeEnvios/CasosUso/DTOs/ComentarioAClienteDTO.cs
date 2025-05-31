using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasosUso.DTOs
{
    public class ComentarioAClienteDTO
    {
        public string Texto { get; set; }
        public DateTime Fecha { get; set; }
    }
}
