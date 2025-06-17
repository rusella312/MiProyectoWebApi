using Microsoft.AspNetCore.Mvc;
using MiProyectoWebApi.Domain.Entities;
using MiProyectoWebApi.Services.Features.Mangas;

namespace MiProyectoWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MangaController : ControllerBase
    {
        private readonly MangaService _mangaService;

        public MangaController(MangaService mangaService)
        {
            _mangaService = mangaService;
        }

        // GET: api/manga
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Manga>>> GetAll()
        {
            var mangas = await _mangaService.GetAllAsync();
            return Ok(mangas);
        }

        // GET: api/manga/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Manga>> GetById(int id)
        {
            var manga = await _mangaService.GetByIdAsync(id);
            if (manga == null) return NotFound();
            return Ok(manga);
        }

        // POST: api/manga
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Manga manga)
        {
            await _mangaService.AddAsync(manga);
            return CreatedAtAction(nameof(GetById), new { id = manga.Id }, manga);
        }

        // PUT: api/manga/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] Manga updatedManga)
        {
            await _mangaService.UpdateAsync(id, updatedManga);
            return NoContent();
        }

        // DELETE: api/manga/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _mangaService.DeleteAsync(id);
            return NoContent();
        }
    }
}
