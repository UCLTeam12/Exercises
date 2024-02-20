using System.ComponentModel.DataAnnotations.Schema;

namespace MusicStore.Models;

public class Artist
{
    public Guid ArtistId { get; set; }
    public string Name { get; set; }
    [ForeignKey("AlbumId")]
    public Album Album { get; set; }
}