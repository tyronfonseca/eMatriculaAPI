using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMatricula.API.Classes
{
    public class QueryMatricula
    {
        public int? Id { get; set; }
        public int? IdStudent { get; set; }
        public int? IdCourse { get; set; }
        public int? IdProfessor { get; set; }

        //============Consejero===============
        public string HorarioAtencion { get; set; }
        public string Oficina { get; set; }
        public string Telefono { get; set; }
    }
}
