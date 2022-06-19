using CaixinhaAPI.Model;

namespace CaixinhaAPI.Repositories
{
    public interface ICaixinhaRepository
    {
        Task<IEnumerable<Ideia>> Get();

        Task<Ideia> Get(int id);

        Task<Ideia> Create(Ideia ideia);

        Task Update(Ideia ideia);

        Task Delete(int id);
    }
}
