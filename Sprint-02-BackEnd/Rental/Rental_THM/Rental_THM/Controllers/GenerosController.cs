using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rental_THM.Controllers
{
    //Define que o tipo de resposta da API será no Formato JSON.
    [Produces("application/json")]

    //Define que a rota de uma requisição será no formato dominio/api/nomeController.
    // ex: http://localhost:5000/api/generos
    [Route("api/[controller]")]
    //Define que é um controlador de API.
    [ApiController]

    public class GenerosController : ControllerBase
    {
        //Objeto que irá receber todos os métodos definidos na interface IGeneroRepository
        private IGeneroRepository _IGeneroRepository { get; set; }
    }
}
