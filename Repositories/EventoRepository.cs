using EventPlus_.Context;
using EventPlus_.Domains;
using EventPlus_.Interfaces;

namespace EventPlus_.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly Eventos_Context _context;

        public EventoRepository(Eventos_Context context)
        {
            _context = context;
        }

        public void Atualizar(Guid id, Evento evento)
        {
            try
            {
                Evento eventoBuscado = _context.Eventos.Find(id)!;

                if (eventoBuscado != null)
                {
                    eventoBuscado.NomeEvento = evento.NomeEvento;
                }
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Evento BuscarPorId(Guid id)
        {
            try
            {
                Evento eventoBuscado = _context.Eventos.Find(id)!;
                return eventoBuscado;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(Evento novoEvento)
        {
            try
            {
                _context.Eventos.Add(novoEvento);

                _context.SaveChanges();
            }

            catch (Exception)
            {
                throw;
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                Evento eventoBuscado = _context.Eventos.Find(id)!;

                if(eventoBuscado != null)
                {
                    _context.Eventos.Remove(eventoBuscado);
                }

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Evento> Listar()
        {
            try
            {
                List<Evento> listaEvento = _context.Eventos.ToList();
                return listaEvento;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Evento> ListarPorId(Guid id)
        {
            try
            {
                List<Evento> listaEvento = _context.Eventos.Where(p => p.EventosID == id).ToList();
                return listaEvento;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Evento> ListarProximosEventos(Guid id)
        {
            try
            {
                List<Evento> listarEventosProximos = _context.Eventos.Where(e => e.DataEvento > DateTime.Now).OrderBy(e => e.DataEvento).ToList();
                return listarEventosProximos;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
