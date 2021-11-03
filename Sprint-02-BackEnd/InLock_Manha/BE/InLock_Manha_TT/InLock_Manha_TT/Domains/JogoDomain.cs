using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InLock_Manha_TT.Domains
{
    /// <summary>
    /// Classe que representa a entidade (tabela) JOGO
    /// </summary>
    public class JogoDomain
    {
        public int idJogo { get; set; }

        public int idEstudio { get; set; }

        public EstudioDomain Estudio { get; set; }

        public string nomeJogo { get; set; }

        public string descricao { get; set; }

        public DateTime dataLancamento { get; set; }

        public decimal valor { get; set; }
    }
}
