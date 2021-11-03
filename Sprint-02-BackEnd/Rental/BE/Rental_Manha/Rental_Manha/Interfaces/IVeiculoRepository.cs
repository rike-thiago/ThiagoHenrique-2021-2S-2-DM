using Rental_Manha.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rental_Manha.Interfaces
{
    interface IVeiculoRepository
    {
        List<VeiculoDomain> ListarTodos();

        VeiculoDomain BuscarPorId(int idVeiculo);

        void Cadastrar(VeiculoDomain novoVeiculo);

        void AtualizarIdCorpo(VeiculoDomain VeiculoAtualizado);

        void AtualizarIdUrl(int idVeiculo, VeiculoDomain VeiculoAtualizado);

        void Deletar(int idVeiculo);
    }
}