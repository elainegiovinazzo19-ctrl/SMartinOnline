using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMartinOnline.Entidades
{
    public class Bitacora
    {
        public int IdBitacora { get; set; }
        public int? IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Accion { get; set; }
        public DateTime Fecha { get; set; }
        public bool Exitoso { get; set; }
    }
}
