using MiProyectoWebApi.Domain.Entities;
using MiProyectoWebApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace MiProyectoWebApi.Infrastructure.Repositories
{
    public class MangaRepository
    {
        private readonly MangaDbContext _context;

        public MangaRepository(MangaDbContext context)
        {
            _context = context;
        }

        // Obtener todos los mangas
        public async Task<List<Manga>> GetAllAsync()
        {
            return await _context.Mangas.ToListAsync();
        }

        // Obtener manga por ID
        public async Task<Manga?> GetByIdAsync(int id)
        {
            return await _context.Mangas.FindAsync(id);
        }

        // Agregar nuevo manga
        public async Task AddAsync(Manga manga)
        {
            _context.Mangas.Add(manga);
            await _context.SaveChangesAsync();
        }

        // Actualizar manga
        public async Task UpdateAsync(Manga manga)
        {
            _context.Mangas.Update(manga);
            await _context.SaveChangesAsync();
        }

        // Eliminar manga
        public async Task DeleteAsync(Manga manga)
        {
            _context.Mangas.Remove(manga);
            await _context.SaveChangesAsync();
        }
    }
}
