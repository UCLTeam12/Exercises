using System.ComponentModel.DataAnnotations.Schema;

namespace MusicStore.Models;

public class Album
{
    public Guid AlbumId { get; set; }
    public Guid GenreId { get; set; }
    public Guid ArtistId { get; set; }
    public string Title { get; set; }
    public decimal Price { get; set; }
    public string AlbumArtUrl { get; set; }
    [ForeignKey("ArtistId")]
    public Artist Artist { get; set; }
    [ForeignKey("GenreId")]
    public Genre Genre { get; set; }
}