using InLock_Manha_TT.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InLock_Manha_TT.Interfaces
{
    interface IEstudioRepository
    {
        List<EstudioDomain> ListarTodos();

        EstudioDomain BuscarPorId(int idEstudio);

        void Cadastrar(EstudioDomain novoEstudio);

        void AtualizarIdCorpo(EstudioDomain EstudioAtualizado);

        void AtualizarIdUrl(int idEstudio, EstudioDomain EstudioAtualizado);

        void Deletar(int idEstudio);
    }
}