using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rental_THM.Interfaces
{
    //Interface responsável pelo repositório GeneroRepository
    interface IGeneroRepository
    {
        /// <summary>
        /// Retorna todos os generos
        /// </summary>
        /// <returns>Uma lista de generos</returns>
        List<GeneroDomain> ListarTodos();


        /// <summary>
        /// Busca um genero atraves do seu id
        /// </summary>
        /// <param name="idGenero">id do genero que será buscado</param>
        /// <returns>Um objeto do tipo GeneroDomain que foi buscado</returns>
        GeneroDomain BuscaPorId(int idGenero);


        /// <summary>
        /// Cadastra um novo genero
        /// </summary>
        /// <param name="novoGenero">Objeto novoGenero com os dados que serão cadastrados</param>
        void Cadastrar(GeneroDomain novoGenero);


        /// <summary>
        /// Atualiza um genero existente passando o id pelo corpo da requisição
        /// </summary>
        /// <param name="generoAtualizado">Objeto generoAtualizado com os novos dados</param>
        /// ex: http://localhost:5000/api/generos
        void AtualizarIdCorpo(GeneroDomain generoAtualizado);


        /// <summary>
        /// Atualiza um genero existente passando o id pela URL da requisição
        /// </summary>
        /// <param name="idGenero">id do genero que será atualizado</param>
        /// <param name="generoAtualizado">Objeto generoAtualizado com os novos dados</param>
        /// ex: http://localhost:5000/api/generos/4
        void AtualizarIdUrl(int idGenero, GeneroDomain generoAtualizado);


        /// <summary>
        /// Deleta um genero
        /// </summary>
        /// <param name="idGenero">id do genero que será deletado</param>
        void Deletar(int idGenero);

    }
}
