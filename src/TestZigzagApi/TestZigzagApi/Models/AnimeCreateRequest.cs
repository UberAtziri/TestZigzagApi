using System;

namespace TestZigzagApi.Models
{
    public class AnimeCreateRequest
    {
        public string Name { get; set; }

        public float Rating { get; set; }

        public string Description { get; set; }

        public DateTime ReleaseDate { get; set; }

        public int NumberOfEpisodes { get; set; }

        public string CategoryName { get; set; }
    }
}