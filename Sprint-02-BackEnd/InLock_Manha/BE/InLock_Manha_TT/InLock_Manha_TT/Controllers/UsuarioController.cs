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
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _UsuarioRepository { get; set; }


        public UsuarioController()
        {
            _UsuarioRepository = new UsuarioRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<UsuarioDomain> listaUsuarios = _UsuarioRepository.ListarTodos();

            return Ok(listaUsuarios);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            UsuarioDomain usuarioBuscado = _UsuarioRepository.BuscarPorId(id);

            if (usuarioBuscado == null)
            {
                return NotFound("Nenhum usuário encontrado");
            }

            return Ok(usuarioBuscado);
        }

        [HttpPost]
        public IActionResult Post(UsuarioDomain novoUsuario)
        {
            _UsuarioRepository.Cadastrar(novoUsuario);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult PutUrl(int id, UsuarioDomain UsuarioAtualizado)
        {
            UsuarioDomain usuarioBuscado = _UsuarioRepository.BuscarPorId(id);

            if (usuarioBuscado == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "Usuario não encontrado!",
                        erro = true
                    });
            }

            try
            {
                _UsuarioRepository.AtualizarIdUrl(id, UsuarioAtualizado);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPut]
        public IActionResult PutBody(UsuarioDomain UsuarioAtualizado)
        {
            if (UsuarioAtualizado.idUsuario == 0)
            {
                return BadRequest(
                    new
                    {
                        mensagemErro = "O id do jogo não foi informado!"
                    }
                );
            }

            UsuarioDomain UsuarioBuscado = _UsuarioRepository.BuscarPorId(UsuarioAtualizado.idUsuario);

            if (UsuarioBuscado != null)
            {
                try
                {
                    _UsuarioRepository.AtualizarIdCorpo(UsuarioAtualizado);

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
                        mensagemErro = "Usuario não encontrado!",
                        codErro = true
                    }
                );
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _UsuarioRepository.Deletar(id);

            return StatusCode(204);
        }
    }
}