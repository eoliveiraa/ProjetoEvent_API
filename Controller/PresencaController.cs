﻿using EventPlus_.Domains;
using EventPlus_.Interfaces;
using EventPlus_.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus_.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PresencaController : ControllerBase
    {
        private readonly IPresencasRepository _presencaRepository;

        public PresencaController(IPresencasRepository presencaRepository)
        {
            _presencaRepository = presencaRepository;
        }

        /// <summary>
        /// Endpoint para cadastrar novo evento
        /// </summary>
        [HttpPost]
        public IActionResult Post(Presenca presencaRepository)
        {
            try
            {
                _presencaRepository.Inscrever(presencaRepository);
                return Created();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }


      
        /// <summary>
        /// Endpoint para buscar por Id a presença
        /// </summary>
        [HttpGet("BuscarPorId/{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                Presenca novaPresenca = _presencaRepository.BuscarPorId(id);
                return Ok(novaPresenca);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Endpoint para atualizar as presenças
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Presenca presenca)
        {
            try
            {
                _presencaRepository.Atualizar(id, presenca);
                return StatusCode(204, presenca);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint para fazer uma lista das presenças
        /// </summary>
        [HttpGet()]
        public IActionResult Get()
        {
            try
            {
                List<Presenca> listaPresencas = _presencaRepository.Listar();
                return Ok(listaPresencas);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Endpoint para fazer uma lista das minhas presenças
        /// </summary>
        [HttpGet("ListarMinhasPresencas/{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                List<Presenca> listaMinhasPresencas = _presencaRepository.ListarMinhasPresencas(id);
                return Ok(listaMinhasPresencas);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}
