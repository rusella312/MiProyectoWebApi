using Microsoft.EntityFrameworkCore;
using MiProyectoWebApi.Domain.Entities;

namespace MiProyectoWebApi.Infrastructure.Data
{
    public class MangaDbContext : DbContext
    {
        public MangaDbContext(DbContextOptions<MangaDbContext> options) : base(options) { }

        public DbSet<Manga> Mangas { get; set; }
    }
}
