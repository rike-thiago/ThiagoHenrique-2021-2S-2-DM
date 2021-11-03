using InLock_Manha_TT.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InLock_Manha_TT.Interfaces
{
    interface IUsuarioRepository
    {
        List<UsuarioDomain> ListarTodos();

        UsuarioDomain BuscarPorId(int idUsuario);

        void Cadastrar(UsuarioDomain novoUsuario);

        void AtualizarIdCorpo(UsuarioDomain UsuarioAtualizado);

        void AtualizarIdUrl(int idUsuario, UsuarioDomain UsuarioAtualizado);

        void Deletar(int idUsuario);

        UsuarioDomain BuscarPorEmailSenha(string email, string senha);
    }
}
