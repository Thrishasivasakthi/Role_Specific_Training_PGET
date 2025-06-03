using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Case_Study_6_Generic_List
{
    public class MyPlayList : IPlaylist
    {
        public static List<Song> myPlayList = new List<Song>();
        private const int MaxCapacity = 20;

        public MyPlayList()
        {
            // Constructor sets capacity (handled by List<T> automatically)
        }

        public void Add(Song song)
        {
            if (myPlayList.Count >= MaxCapacity)
            {
                throw new InvalidOperationException($"Cannot add more than {MaxCapacity} songs to the playlist.");
            }

            if (myPlayList.Any(s => s.SongId == song.SongId))
            {
                throw new ArgumentException("A song with this ID already exists in the playlist.");
            }

            myPlayList.Add(song);
        }

        public void Remove(int songId)
        {
            var songToRemove = myPlayList.FirstOrDefault(s => s.SongId == songId);
            if (songToRemove != null)
            {
                myPlayList.Remove(songToRemove);
            }
            else
            {
                throw new KeyNotFoundException("Song with the specified ID not found in the playlist.");
            }
        }

        public Song GetSongById(int songId)
        {
            return myPlayList.FirstOrDefault(s => s.SongId == songId) ??
                   throw new KeyNotFoundException("Song with the specified ID not found.");
        }

        public Song GetSongByName(string songName)
        {
            return myPlayList.FirstOrDefault(s =>
                s.SongName.Equals(songName, StringComparison.OrdinalIgnoreCase)) ??
                throw new KeyNotFoundException("Song with the specified name not found.");
        }

        public List<Song> GetAllSongs()
        {
            return new List<Song>(myPlayList); // Return a copy to protect the original list
        }
    }
}
