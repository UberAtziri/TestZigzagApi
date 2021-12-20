using System;
using System.ComponentModel.DataAnnotations;

namespace TestZigzagApi.Models
{
    public class AnimeCreateRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public float Rating { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public int NumberOfEpisodes { get; set; }

        [Required]
        public string CategoryName { get; set; }
    }
}