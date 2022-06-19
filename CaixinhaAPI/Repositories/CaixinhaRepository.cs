using CaixinhaAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace CaixinhaAPI.Repositories
{
    public class CaixinhaRepository : ICaixinhaRepository
    {
        public readonly CaixinhaContext _context;
        public CaixinhaRepository(CaixinhaContext context)
        {
            _context = context;
        }
        public async Task<Ideia> Create(Ideia ideia)
        {
            _context.Ideias.Add(ideia);
            await _context.SaveChangesAsync();
            return ideia;
        }

        public async Task Delete(int id)
        {
            var ideiaToDelete = await _context.Ideias.FindAsync(id);
            _context.Ideias.Remove(ideiaToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Ideia>> Get()
        {
            return await  _context.Ideias.ToListAsync();
        }

        public async Task<Ideia> Get(int id)
        {
            return await _context.Ideias.FindAsync(id);
        }

        public async Task Update(Ideia ideia)
        {
            _context.Entry(ideia).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
