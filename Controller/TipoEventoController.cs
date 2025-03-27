using EventPlus_.Domains;
using EventPlus_.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace EventPlus_.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TipoEventoController : ControllerBase
    {
        private readonly ITipoEventoRepository _tipoEventoRepository;

        public TipoEventoController(ITipoEventoRepository tipoEventoRepository)
        {
            _tipoEventoRepository = tipoEventoRepository;
        }


        /// <summary>
        /// Endpoint para listar os tipos dos eventos
        /// </summary>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<TipoEvento> listaDeTipoEvento = _tipoEventoRepository.Listar();
                return Ok(listaDeTipoEvento);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Endpoint para cadastrar novos tipos de evento
        /// </summary>
        [HttpPost]
        public IActionResult Post(TipoEvento novoTipoEvento)
        {
            try
            {
                _tipoEventoRepository.Cadastrar(novoTipoEvento);
                return Created();
                
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Endpoint para atualizar o tipo do evento
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, TipoEvento tipoEvento)
        {
            try
            {
                _tipoEventoRepository.Atualizar(id, tipoEvento);
                return NoContent();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Endpoint para deletar o tipo do evento
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _tipoEventoRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Endpoint para buscar tipo do evento por Id
        /// </summary>
        [HttpGet("BuscarPorId/{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                TipoEvento buscaTipoEvento = _tipoEventoRepository.BuscarPorId(id);
                return Ok(buscaTipoEvento);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}
