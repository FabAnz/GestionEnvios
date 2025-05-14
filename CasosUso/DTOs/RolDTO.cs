using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasosUso.DTOs
{
    public class RolDTO
    {
        public int Id { get; set; }

        [DisplayName("Rol")]
        public string Nombre { get; set; }
    }
}
