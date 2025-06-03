using Case_Study_6_Generic_List;

class Program
{
    static void Main(string[] args)
    {
        IPlaylist playlist = new MyPlayList();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\nSongsHub Portal - Playlist Management");
            Console.WriteLine("1. Add Song");
            Console.WriteLine("2. Remove Song by ID");
            Console.WriteLine("3. Get Song by ID");
            Console.WriteLine("4. Get Song by Name");
            Console.WriteLine("5. Get All Songs");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice: ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                try
                {
                    switch (choice)
                    {
                        case 1: // Add Song
                            AddSongToPlaylist(playlist);
                            break;
                        case 2: // Remove Song by ID
                            RemoveSongFromPlaylist(playlist);
                            break;
                        case 3: // Get Song by ID
                            GetSongByIdFromPlaylist(playlist);
                            break;
                        case 4: // Get Song by Name
                            GetSongByNameFromPlaylist(playlist);
                            break;
                        case 5: // Get All Songs
                            DisplayAllSongs(playlist);
                            break;
                        case 6: // Exit
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid number.");
            }
        }
    }

    static void AddSongToPlaylist(IPlaylist playlist)
    {
        try
        {
            Console.Write("Enter Song ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter Song Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Song Genre (Pop, HipHop, Soul Music, Jazz, Rock, Disco, Melody, Classic): ");
            string genre = Console.ReadLine();

            Song newSong = new Song { SongId = id, SongName = name, SongGenre = genre };
            playlist.Add(newSong);
            Console.WriteLine("Song added successfully!");
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input format. Please enter correct values.");
        }
    }

    static void RemoveSongFromPlaylist(IPlaylist playlist)
    {
        Console.Write("Enter Song ID to remove: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            playlist.Remove(id);
            Console.WriteLine("Song removed successfully!");
        }
        else
        {
            Console.WriteLine("Invalid Song ID. Please enter a number.");
        }
    }

    static void GetSongByIdFromPlaylist(IPlaylist playlist)
    {
        Console.Write("Enter Song ID to search: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var song = playlist.GetSongById(id);
            DisplaySongDetails(song);
        }
        else
        {
            Console.WriteLine("Invalid Song ID. Please enter a number.");
        }
    }

    static void GetSongByNameFromPlaylist(IPlaylist playlist)
    {
        Console.Write("Enter Song Name to search: ");
        string name = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(name))
        {
            var song = playlist.GetSongByName(name);
            DisplaySongDetails(song);
        }
        else
        {
            Console.WriteLine("Song name cannot be empty.");
        }
    }

    static void DisplayAllSongs(IPlaylist playlist)
    {
        var allSongs = playlist.GetAllSongs();
        if (allSongs.Count == 0)
        {
            Console.WriteLine("The playlist is empty.");
        }
        else
        {
            Console.WriteLine("\nAll Songs in Playlist:");
            Console.WriteLine("----------------------");
            foreach (var song in allSongs)
            {
                DisplaySongDetails(song);
                Console.WriteLine("----------------------");
            }
            Console.WriteLine($"Total songs: {allSongs.Count}");
        }
    }
    static void DisplaySongDetails(Song song)
    {
        Console.WriteLine($"ID: {song.SongId}");
        Console.WriteLine($"Name: {song.SongName}");
        Console.WriteLine($"Genre: {song.SongGenre}");
    }
}