// Alexander Raptis, Feb 7th 2023

using System;
using static System.Net.Mime.MediaTypeNames;

namespace MovieFun
{
    class Program
    {
        enum Genre
        {
            Country,
            Classic,
            Pop,
            Rock,
            Jazz,
            HipHop
        }
        static void Main(string[] args)
        {
            // Collect all genre types into one comma separated string
            string genres = string.Join(", ", Enum.GetNames(typeof(Genre)));

            // Creating temporary variables
            string tmpTitle, tmpArtist, tmpAlbum;
            TimeSpan tmpLength;
            Genre tmpGenre;

            // Creating music struct using parameterized constructor
            Music song1 = new Music("Stairway to Heaven", "Led Zeppelin",
                "Led Zeppelin IV", TimeSpan.Parse("00:08:02"), Genre.Rock);
            Console.WriteLine(song1.Display());

            // Creating music structures from user input
            Console.Write("Please enter the first song title: ");
            tmpTitle = Console.ReadLine();
            Console.Write("Enter the artist's name for this song: ");
            tmpArtist = Console.ReadLine();
            Console.Write("Enter the album the song is from: ");
            tmpAlbum = Console.ReadLine();
            Console.Write("Please enter the length of the song in this format (hh:mm:ss): ");
            tmpLength = TimeSpan.Parse(Console.ReadLine());
            Console.Write($"Please enter the genre of the song from this list ({genres}): ");
            tmpGenre = (Genre)Enum.Parse(typeof(Genre), Console.ReadLine(), true);

            Music song2 = new Music(tmpTitle, tmpArtist, tmpAlbum, tmpLength, tmpGenre);
            Music song3 = song2;

            Console.Write("Please enter the second song title: ");
            tmpTitle = Console.ReadLine();
            song3.setTitle(tmpTitle);

            Console.Write("Please enter the length of the song in this format (hh:mm:ss): ");
            tmpLength = TimeSpan.Parse(Console.ReadLine());
            song3.setLength(tmpLength);

            Console.WriteLine(song2.Display());
            Console.WriteLine(song3.Display());
        }
        struct Music
        {
            private string Title;
            private string Artist;
            private string Album;
            private TimeSpan Length;
            private Genre Genre;

            public Music(string _title, string _artist, string _album, TimeSpan _length, Genre _genre)
            {
                Title = _title;
                Artist = _artist;
                Album = _album;
                Length = _length;
                Genre = _genre;
            }
            public string Display()
            {
                return $"Title: {Title}\nArtst: {Artist}\nAlbum: {Album}\nLength: {Length:c}\nGenre: {Genre}";
            }
            public void setTitle(string _title)
            {
                Title = _title;
            }
            public void setLength(TimeSpan _length)
            {
                Length = _length;
            }
        }
    }
}