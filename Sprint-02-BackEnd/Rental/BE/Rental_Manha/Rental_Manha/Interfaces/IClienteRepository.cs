using Rental_Manha.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rental_Manha.Interfaces
{
    interface IClienteRepository
    {
        List<ClienteDomain> ListarTodos();

        ClienteDomain BuscarPorId(int idCliente);

        void Cadastrar(ClienteDomain novoCliente);

        void AtualizarIdCorpo(ClienteDomain ClienteAtualizado);

        void AtualizarIdUrl(int idCliente, ClienteDomain ClienteAtualizado);

        void Deletar(int idCliente);
    }
}