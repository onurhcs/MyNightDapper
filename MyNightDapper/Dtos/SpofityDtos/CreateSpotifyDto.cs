using System.ComponentModel.DataAnnotations;

namespace MyNightDapper.Dtos.SpofityDtos
{
    public class CreateSpotifyDto
    {
        [Required]
        public string artist_name { get; set; }

        [Required]
        public string track_name { get; set; }

        [Required]
        public string track_id { get; set; }

        public byte? popularity { get; set; }
        public int? year { get; set; }
        public string genre { get; set; }
        public float? danceability { get; set; }
        public float? energy { get; set; }
        public byte? key { get; set; }
        public float? loudness { get; set; }
        public bool? mode { get; set; }
        public float? speechiness { get; set; }
        public float? acousticness { get; set; }
        public float? instrumentalness { get; set; }
        public float? liveness { get; set; }
        public float? valence { get; set; }
        public float? tempo { get; set; }
        public int? duration_ms { get; set; }
        public byte? time_signature { get; set; }
    }
}
