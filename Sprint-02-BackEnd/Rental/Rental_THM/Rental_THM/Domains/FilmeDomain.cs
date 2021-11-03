    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rental_THM.Domains
{
    public class FilmeDomain
    {
        public int idFilme { get; set; }
        public int idGenero { get; set; }
        public string nomeFilme { get; set; }
        public GeneroDomain genero { get; set; }
    }
}
