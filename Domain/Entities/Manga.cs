namespace MiProyectoWebApi.Domain.Entities
{
    public class Manga
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Author { get; set; } = "";
        public string Genre { get; set; } = "";
        public string Description { get; set; } = "";
        public string CoverImageUrl { get; set; } = "";
        public int YearPublished { get; set; }
        public int Rating { get; set; }
    }
}
