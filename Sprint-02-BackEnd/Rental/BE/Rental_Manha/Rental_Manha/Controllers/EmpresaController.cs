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
    public class EmpresaController : ControllerBase
    {
        private IEmpresaRepository _EmpresaRepository { get; set; }

        public EmpresaController()
        {
            _EmpresaRepository = new EmpresaRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<EmpresaDomain> ListaEmpresas = _EmpresaRepository.ListarTodos();

            return Ok(ListaEmpresas);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            EmpresaDomain empresaBuscada = _EmpresaRepository.BuscarPorId(id);

            if (empresaBuscada == null)
            {
                return NotFound("Nenhuma empresa encontrada!");
            }
            return Ok(empresaBuscada);
        }

        [HttpPost]
        public IActionResult Post(EmpresaDomain novaEmpresa)
        {
            _EmpresaRepository.Cadastrar(novaEmpresa);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult PutIdUrl(int id, EmpresaDomain empresaAtualizada)
        {
            EmpresaDomain empresaBuscada = _EmpresaRepository.BuscarPorId(id);

            {
                if (empresaBuscada == null)
                {
                    return NotFound
                        (new
                        {
                            mensagem = "Empresa não encontrada!"
                        });
                }
            }

            try
            {
                _EmpresaRepository.AtualizarIdUrl(id, empresaAtualizada);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPut]
        public IActionResult PutBody(EmpresaDomain EmpresaAtualizada)
        {
            if (EmpresaAtualizada.nomeEmpresa == null || EmpresaAtualizada.idEmpresa == 0)
            {
                return BadRequest(
                    new
                    {
                        mensagemErro = "O nome ou o id da empresa não foi informado!"
                    }
                );
            }

            EmpresaDomain EmpresaBuscada = _EmpresaRepository.BuscarPorId(EmpresaAtualizada.idEmpresa);

            if (EmpresaBuscada != null)
            {
                try
                {
                    _EmpresaRepository.AtualizarIdCorpo(EmpresaAtualizada);

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
                        mensagemErro = "Empresa não encontrada!",
                        codErro = true
                    }
                );
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _EmpresaRepository.Deletar(id);

            return StatusCode(204);
        }
    }
}