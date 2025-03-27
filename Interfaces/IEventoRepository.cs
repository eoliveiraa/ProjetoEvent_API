using EventPlus_.Domains;

namespace EventPlus_.Interfaces
{
    public interface IEventoRepository
    {
        List<Evento> Listar();

        void Cadastrar(Evento evento);

        void Atualizar(Guid id, Evento evento);

        void Deletar(Guid id);

        List<Evento> ListarPorId(Guid id);

        List<Evento> ListarProximosEventos(Guid id);
    }
}
