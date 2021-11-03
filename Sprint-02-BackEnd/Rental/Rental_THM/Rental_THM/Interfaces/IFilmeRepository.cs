using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rental_THM.Interfaces
{
    //Interface responsável pelo repositório FilmeRepository
    interface  IFilmeRepository
    {
        List<FilmeDomain> ListarTodos();

        FilmeDomain BuscarPorId(int IdFilme);

        void Cadastrar(FilmeDomain novoFilme);

        void AtualizarIdUrl(int idFilme, FilmeDomain filme);

        void Deletar(int IdFilme);
    }
}
