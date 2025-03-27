using EventPlus_.Domains;
using EventPlus_.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus_.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TipoUsuarioController : ControllerBase
    {
        private readonly ITipoUsuarioRepository _tipoUsuarioRepository;

        public TipoUsuarioController(ITipoUsuarioRepository tipoUsuarioRepository)
        {
            _tipoUsuarioRepository = tipoUsuarioRepository;
        }


        /// <summary>
        /// Endpoint para cadastrar um tipo de usuario
        /// </summary>
        [HttpPost]
        public IActionResult Post(TipoUsuario novoTipoUsuario)
        {
            try
            {
                _tipoUsuarioRepository.Cadastrar(novoTipoUsuario);
                return Created();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Endpoint para listar os tipos de usuario
        /// </summary>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<TipoUsuario> listaTipoUsuario = _tipoUsuarioRepository.Listar();
                return Ok(listaTipoUsuario);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Endpoint para atualizar um tipo de usuário.
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, TipoUsuario tipoUsuario)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var tipoUsuarioExistente = _tipoUsuarioRepository.BuscarPorId(id);
                if (tipoUsuarioExistente == null)
                {
                    return NotFound("Tipo de usuário não encontrado.");
                }

                _tipoUsuarioRepository.Atualizar(id, tipoUsuario);
                return NoContent();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Endpoint para deletar os tipos de usuarios
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _tipoUsuarioRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Endpoint para buscar o tipo do usuario por Id
        /// </summary>
        [HttpGet("BuscarPorId/{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                TipoUsuario novotipoUsuario = _tipoUsuarioRepository.BuscarPorId(id);
                return Ok(novotipoUsuario);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}
