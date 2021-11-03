using InLock_Manha_TT.Domains;
using InLock_Manha_TT.Interfaces;
using InLock_Manha_TT.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InLock_Manha_TT.Controllers
{

    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]
    public class JogoController : ControllerBase
    {
        private IJogoRepository _JogoRepository { get; set; }


        public JogoController()
        {
            _JogoRepository = new JogoRepository();
        }

        [Authorize (Roles = "1,2")]
        [HttpGet]
        public IActionResult Get()
        {
            List<JogoDomain> listaJogos = _JogoRepository.ListarTodos();

            return Ok(listaJogos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            JogoDomain jogoBuscado = _JogoRepository.BuscarPorId(id);

            if (jogoBuscado == null)
            {
                return NotFound("Nenhum jogo encontrado");
            }

            return Ok(jogoBuscado);
        }

        [Authorize (Roles = "1")]
        [HttpPost]
        public IActionResult Post(JogoDomain novoJogo)
        {
            _JogoRepository.Cadastrar(novoJogo);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult PutUrl(int id, JogoDomain JogoAtualizado)
        {
            JogoDomain jogoBuscado = _JogoRepository.BuscarPorId(id);

            if (jogoBuscado == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "Jogo não encontrado!",
                        erro = true
                    });
            }

            try
            {
                _JogoRepository.AtualizarIdUrl(id, JogoAtualizado);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPut]
        public IActionResult PutBody(JogoDomain JogoAtualizado)
        {
            if (JogoAtualizado.idJogo == 0)
            {
                return BadRequest(
                    new
                    {
                        mensagemErro = "O id do jogo não foi informado!"
                    }
                );
            }

            JogoDomain JogoBuscado = _JogoRepository.BuscarPorId(JogoAtualizado.idJogo);

            if (JogoBuscado != null)
            {
                try
                {
                    _JogoRepository.AtualizarIdCorpo(JogoAtualizado);

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
                        mensagemErro = "Jogo não encontrado!",
                        codErro = true
                    }
                );
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _JogoRepository.Deletar(id);

            return StatusCode(204);
        }
    }
}
