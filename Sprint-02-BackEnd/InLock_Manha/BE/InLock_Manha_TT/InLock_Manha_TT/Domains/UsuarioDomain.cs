using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InLock_Manha_TT.Domains
{
    /// <summary>
    /// Classe que representa a entidade (tabela) USUARIO
    /// </summary>
    public class UsuarioDomain
    {
        public int idUsuario { get; set; }

        public int idTipoUsuario { get; set; }

        public TipoUsuarioDomain TipoUsuario { get; set; }

        public string email { get; set; }

        public string nomeUsuario { get; set; }

        public string senha { get; set; }
    }
}
