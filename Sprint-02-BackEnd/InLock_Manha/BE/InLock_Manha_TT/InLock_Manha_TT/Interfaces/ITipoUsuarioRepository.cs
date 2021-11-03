using InLock_Manha_TT.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InLock_Manha_TT.Interfaces
{
    interface ITipoUsuarioRepository
    {
        List<TipoUsuarioDomain> ListarTodos();

        TipoUsuarioDomain BuscarPorId(int idTipoUsuarioDomain);

        void Cadastrar(TipoUsuarioDomain novoTipoUsuarioDomain);

        void AtualizarIdCorpo(TipoUsuarioDomain TipoUsuarioAtualizado);

        void AtualizarIdUrl(int idTipoUsuarioDomain, TipoUsuarioDomain TipoUsuarioAtualizado);

        void Deletar(int idTipoUsuarioDomain);
    }
}
