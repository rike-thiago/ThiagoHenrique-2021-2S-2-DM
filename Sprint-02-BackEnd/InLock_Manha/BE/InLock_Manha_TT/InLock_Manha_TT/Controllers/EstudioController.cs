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
    public class EstudioController : ControllerBase
    {
        private IEstudioRepository _EstudioRepository { get; set; }


        public EstudioController()
        {
            _EstudioRepository = new EstudioRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<EstudioDomain> listaEstudios = _EstudioRepository.ListarTodos();

            return Ok(listaEstudios);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            EstudioDomain estudioBuscado = _EstudioRepository.BuscarPorId(id);

            if (estudioBuscado == null)
            {
                return NotFound("Nenhum estúdio encontrado");
            }

            return Ok(estudioBuscado);
        }

        [HttpPost]
        public IActionResult Post(EstudioDomain novoEstudio)
        {
            _EstudioRepository.Cadastrar(novoEstudio);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult PutIdUrl(int id, EstudioDomain EstudioAtualizado)
        {
            EstudioDomain estudioBuscado = _EstudioRepository.BuscarPorId(id);

            {
                if (estudioBuscado == null)
                {
                    return NotFound
                        (new
                        {
                            mensagem = "Estudio não encontrado!",
                        });
                }
            }

            try
            {
                _EstudioRepository.AtualizarIdUrl(id, EstudioAtualizado);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPut]
        public IActionResult PutBody(EstudioDomain EstudioAtualizado)
        {
            if (EstudioAtualizado.idEstudio == 0)
            {
                return BadRequest(
                    new
                    {
                        mensagemErro = "O id do estudio não foi informado!"
                    }
                );
            }

            EstudioDomain EstudioBuscado = _EstudioRepository.BuscarPorId(EstudioAtualizado.idEstudio);

            if (EstudioBuscado != null)
            {
                try
                {
                    _EstudioRepository.AtualizarIdCorpo(EstudioAtualizado);

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
                        mensagemErro = "Estudio não encontrado!",
                        codErro = true
                    }
                );
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _EstudioRepository.Deletar(id);

            return StatusCode(204);
        }
            }
        }
