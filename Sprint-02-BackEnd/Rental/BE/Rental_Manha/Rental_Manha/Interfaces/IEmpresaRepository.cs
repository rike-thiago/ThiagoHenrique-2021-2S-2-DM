using Rental_Manha.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rental_Manha.Interfaces
{
    interface IEmpresaRepository
    {
        List<EmpresaDomain> ListarTodos();

        EmpresaDomain BuscarPorId(int idEmpresa);

        void Cadastrar(EmpresaDomain novaEmpresa);

        void AtualizarIdCorpo(EmpresaDomain EmpresaAtualizada);

        void AtualizarIdUrl(int idEmpresa, EmpresaDomain EmpresaAtualizada);

        void Deletar(int idEmpresa);
    }
}