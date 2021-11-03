using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rental_Manha.Domains;
using Rental_Manha.Interfaces;
using Rental_Manha.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rental_Manha.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private IClienteRepository _ClienteRepository { get; set; }

        public ClienteController()
        {
            _ClienteRepository = new ClienteRepository();
        }

        [HttpGet]

        public IActionResult Get()
        {
            List<ClienteDomain> ListaCliente = _ClienteRepository.ListarTodos();

            return Ok(ListaCliente);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            ClienteDomain ClienteBuscado = _ClienteRepository.BuscarPorId(id);

            if (ClienteBuscado == null)
            {
                return NotFound("Nenhum cliente encontrado!");
            }

            return Ok(ClienteBuscado);
        }

        [HttpPost]
        public IActionResult Post(ClienteDomain novoCliente)
        {
            _ClienteRepository.Cadastrar(novoCliente);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult PutIdUrl(int id, ClienteDomain ClienteAtualizado)
        {
            ClienteDomain ClienteBuscado = _ClienteRepository.BuscarPorId(id);

            if (ClienteBuscado == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "Cliente não encontrado!",
                        erro = true
                    });
            }

            try
            {
                _ClienteRepository.AtualizarIdUrl(id, ClienteAtualizado);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPut]
        public IActionResult PutBody(ClienteDomain ClienteAtualizado)
        {
            if (ClienteAtualizado.nomeCliente == null || ClienteAtualizado.idCliente == 0)
            {
                return BadRequest(
                    new
                    {
                        mensagemErro = "O nome ou o id do cliente não foi informado!"
                    }
                );
            }

            ClienteDomain ClienteBuscado = _ClienteRepository.BuscarPorId(ClienteAtualizado.idCliente);

            if (ClienteBuscado != null)
            {
                try
                {
                    _ClienteRepository.AtualizarIdCorpo(ClienteAtualizado);

                    return NoContent();
                }
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            }

            return NotFound(
                    new
                    {
                        mensagemErro = "Cliente não encontrado!",
                        codErro = true
                    }
                );
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _ClienteRepository.Deletar(id);

            return StatusCode(204);
        }
    }
}