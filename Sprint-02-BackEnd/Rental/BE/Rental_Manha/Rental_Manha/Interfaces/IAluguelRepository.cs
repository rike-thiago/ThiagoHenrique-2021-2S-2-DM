using Rental_Manha.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rental_Manha.Interfaces
{
    interface IAluguelRepository
    {
        List<AluguelDomain> ListarTodos();

        AluguelDomain BuscarPorId(int idAluguel);

        void Cadastrar(AluguelDomain novoAluguel);

        void AtualizarIdCorpo(AluguelDomain AluguelAtualizado);

        void AtualizarIdUrl(int idAluguel, AluguelDomain AluguelAtualizado);

        void Deletar(int idAluguel);
    }
}