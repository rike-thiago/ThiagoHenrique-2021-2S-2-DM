using InLock_Manha_TT.Domains;
using InLock_Manha_TT.Interfaces;
using InLock_Manha_TT.Repositories;
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
    public class TipoUsuarioController : ControllerBase
    {
        private ITipoUsuarioRepository _TipoUsuarioRepository { get; set; }


        public TipoUsuarioController()
        {
            _TipoUsuarioRepository = new TipoUsuarioRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<TipoUsuarioDomain> listaTipoUsuarios = _TipoUsuarioRepository.ListarTodos();

            return Ok(listaTipoUsuarios);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            TipoUsuarioDomain tipoUsuarioBuscado = _TipoUsuarioRepository.BuscarPorId(id);

            if (tipoUsuarioBuscado == null)
            {
                return NotFound("Nenhum Tipo de Usuário foi encontrado");
            }

            return Ok(tipoUsuarioBuscado);
        }

        [HttpPost]
        public IActionResult Post(TipoUsuarioDomain novoTipoUsuario)
        {
            _TipoUsuarioRepository.Cadastrar(novoTipoUsuario);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult PutUrl(int id, TipoUsuarioDomain TipoUsuarioAtualizado)
        {
            TipoUsuarioDomain tipoUsuarioBuscado = _TipoUsuarioRepository.BuscarPorId(id);

            if (tipoUsuarioBuscado == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "Tipo de Usuario não encontrado!",
                        erro = true
                    });
            }

            try
            {
                _TipoUsuarioRepository.AtualizarIdUrl(id, TipoUsuarioAtualizado);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPut]
        public IActionResult PutBody(TipoUsuarioDomain TipoUsuarioAtualizado)
        {
            if (TipoUsuarioAtualizado.idTipoUsuario == 0)
            {
                return BadRequest(
                    new
                    {
                        mensagemErro = "O id do jogo não foi informado!"
                    }
                );
            }

            TipoUsuarioDomain TipoUsuarioBuscado = _TipoUsuarioRepository.BuscarPorId(TipoUsuarioAtualizado.idTipoUsuario);

            if (TipoUsuarioBuscado != null)
            {
                try
                {
                    _TipoUsuarioRepository.AtualizarIdCorpo(TipoUsuarioAtualizado);

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
                        mensagemErro = "Tipo de Usuario não encontrado!",
                        codErro = true
                    }
                );
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _TipoUsuarioRepository.Deletar(id);

            return StatusCode(204);
        }
    }
}