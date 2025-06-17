using MiProyectoWebApi.Domain.Entities;
using MiProyectoWebApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace MiProyectoWebApi.Services.Features.Mangas
{
    public class MangaService
    {
        private readonly MangaDbContext _context;

        public MangaService(MangaDbContext context)
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

        // Agregar manga
        public async Task AddAsync(Manga manga)
        {
            _context.Mangas.Add(manga);
            await _context.SaveChangesAsync();
        }

        // Actualizar manga
        public async Task UpdateAsync(int id, Manga updatedManga)
        {
            var existing = await _context.Mangas.FindAsync(id);
            if (existing == null) return;

            existing.Title = updatedManga.Title;
            existing.Description = updatedManga.Description;
            existing.Author = updatedManga.Author;
            existing.CoverImageUrl = updatedManga.CoverImageUrl;
            existing.Genre = updatedManga.Genre;
            existing.YearPublished = updatedManga.YearPublished;
            existing.Rating = updatedManga.Rating;

            await _context.SaveChangesAsync();
        }

        // Eliminar manga
        public async Task DeleteAsync(int id)
        {
            var manga = await _context.Mangas.FindAsync(id);
            if (manga != null)
            {
                _context.Mangas.Remove(manga);
                await _context.SaveChangesAsync();
            }
        }
    }
}
