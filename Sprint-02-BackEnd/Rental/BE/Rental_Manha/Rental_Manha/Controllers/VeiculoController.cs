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
    public class VeiculoController : ControllerBase
    {
        private IVeiculoRepository _VeiculoRepository { get; set; }

        public VeiculoController()
        {
            _VeiculoRepository = new VeiculoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<VeiculoDomain> ListaVeiculos = _VeiculoRepository.ListarTodos();

            return Ok(ListaVeiculos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            VeiculoDomain VeiculoBuscada = _VeiculoRepository.BuscarPorId(id);

            if (VeiculoBuscada == null)
            {
                return NotFound("Nenhum veiculo encontrado!");
            }
            return Ok(VeiculoBuscada);
        }

        [HttpPost]
        public IActionResult Post(VeiculoDomain novaVeiculo)
        {
            _VeiculoRepository.Cadastrar(novaVeiculo);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult PutIdUrl(int id, VeiculoDomain VeiculoAtualizada)
        {
            VeiculoDomain VeiculoBuscada = _VeiculoRepository.BuscarPorId(id);

            {
                if (VeiculoBuscada == null)
                {
                    return NotFound
                        (new
                        {
                            mensagem = "Veiculo não encontrado!"
                        });
                }
            }

            try
            {
                _VeiculoRepository.AtualizarIdUrl(id, VeiculoAtualizada);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPut]
        public IActionResult PutBody(VeiculoDomain VeiculoAtualizada)
        {
            if (VeiculoAtualizada.placaVeiculo == null || VeiculoAtualizada.idVeiculo == 0)
            {
                return BadRequest(
                    new
                    {
                        mensagemErro = "A placa ou id do veiculo não foi informado!"
                    }
                );
            }

            VeiculoDomain VeiculoBuscada = _VeiculoRepository.BuscarPorId(VeiculoAtualizada.idVeiculo);

            if (VeiculoBuscada != null)
            {
                try
                {
                    _VeiculoRepository.AtualizarIdCorpo(VeiculoAtualizada);

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
                        mensagemErro = "Veiculo não encontrado!",
                        codErro = true
                    }
                );
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _VeiculoRepository.Deletar(id);

            return StatusCode(204);
        }
    }
}