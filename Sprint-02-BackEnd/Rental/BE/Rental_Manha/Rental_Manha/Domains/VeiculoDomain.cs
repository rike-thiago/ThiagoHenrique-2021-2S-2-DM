using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rental_Manha.Domains
{
    public class VeiculoDomain
    {
        public int idVeiculo { get; set; }

        public int idModelo { get; set; }

        public int idMarca { get; set; }

        public int idEmpresa { get; set; }

        public ModeloDomain modelo { get; set; }

        public MarcaDomain marca { get; set; }

        public EmpresaDomain empresa { get; set; }

        public string placaVeiculo { get; set; }
    }
}   