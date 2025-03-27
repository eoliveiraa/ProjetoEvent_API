using EventPlus_.Context;
using EventPlus_.Controller;
using EventPlus_.Domains;
using EventPlus_.Interfaces;

namespace EventPlus_.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private readonly Eventos_Context _context;

        public TipoUsuarioRepository(Eventos_Context context)
        {
            _context = context;
        }

        public void Atualizar(Guid id, TipoUsuario tipoUsuario)
        {
            try
            {
                TipoUsuario tipoUsuarioBuscado = _context.TipoUsuario.Find(id)!;

                if (tipoUsuarioBuscado != null)
                {
                    tipoUsuarioBuscado.TituloTipoUsuario = tipoUsuario.TituloTipoUsuario;
                }
                    _context.SaveChanges();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public TipoUsuario BuscarPorId(Guid id)
        {
            try
            {
                TipoUsuario tipoUsuarioBuscado = _context.TipoUsuario.Find(id)!;
                return tipoUsuarioBuscado;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(TipoUsuario tipoUsuario)
        {
            try
            {
                _context.TipoUsuario.Add(tipoUsuario);
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
                TipoUsuario tipoUsuarioBuscado = _context.TipoUsuario.Find(id)!;

                if (tipoUsuarioBuscado != null)
                {
                    _context.TipoUsuario.Remove(tipoUsuarioBuscado);
                }
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public List<TipoUsuario> Listar()
        {
            try
            {
                List<TipoUsuario> listaTipoUsuario = _context.TipoUsuario.ToList();
                return listaTipoUsuario;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
