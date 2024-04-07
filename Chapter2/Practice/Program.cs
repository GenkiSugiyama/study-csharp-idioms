using System;
using System.Diagnostics;

namespace Chapter2.Practice // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Song[] songs = [
                new Song("うたうた", "artist1", 40),
                new Song("へいへいへい", "artist2", 30),
                new Song("うたばん", "artist3", 60)
            ];

            foreach (var (song, index) in songs.Select((song, index) => (song, index)))
            {
                var timeSpan = new TimeSpan(0, 0, song.Length);
                Console.WriteLine($"{index + 1}曲目");
                Console.WriteLine($"タイトル：{song.Title}");
                Console.WriteLine($"歌手：{song.ArtistName}");
                Console.WriteLine($"演奏時間：{timeSpan.ToString(@"mm\:ss")}");
                Console.WriteLine("----------");
            }
        }
    }

    public class Song
    {
        public string Title { get; set; }
        public string ArtistName { get; set; }
        public int Length { get; set; }

        public Song(string title, string artistName, int length)
        {
            this.Title = title;
            this.ArtistName = artistName;
            this.Length = length;
        }
    }
}