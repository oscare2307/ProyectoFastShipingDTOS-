using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dominio.Entities
{
    public class Vehiculo: EntidadBase
    {
        public  int Id { get; set; }
        public  string Matricula { get; set; }
        public  string Marca { get; set; }
        public  string Modelo { get; set; }

    }
}
