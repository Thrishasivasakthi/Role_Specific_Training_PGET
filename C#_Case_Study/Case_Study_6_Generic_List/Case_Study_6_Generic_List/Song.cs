using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Case_Study_6_Generic_List
{
    public class Song
    {
        public int SongId { get; set; }
        public string SongName { get; set; }
        private string _songGenre;

        public string SongGenre
        {
            get { return _songGenre; }
            set
            {
                // Validate song genre
                string[] validGenres = { "Pop", "HipHop", "Soul Music", "Jazz", "Rock", "Disco", "Melody", "Classic" };
                if (validGenres.Contains(value))
                {
                    _songGenre = value;
                }
                else
                {
                    throw new ArgumentException("Invalid genre. Must be one of: Pop, HipHop, Soul Music, Jazz, Rock, Disco, Melody, Classic");
                }
            }
        }
    }
}
