using InLock_Manha_TT.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InLock_Manha_TT.Interfaces
{
    interface IJogoRepository
    {
        List<JogoDomain> ListarTodos();

        JogoDomain BuscarPorId(int idJogo);

        void Cadastrar(JogoDomain novoJogo);

        void AtualizarIdCorpo(JogoDomain JogoAtualizado);

        void AtualizarIdUrl(int idJogo, JogoDomain JogoAtualizado);

        void Deletar(int idJogo);
    }
}