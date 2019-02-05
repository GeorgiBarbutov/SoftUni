using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Song> playlist = new List<Song>();

        FillPlaylist(playlist);
        PrintPlaylist(playlist);
    }

    private static void PrintPlaylist(List<Song> playlist)
    {
        Console.WriteLine($"Songs added: {playlist.Count}");

        int hours = 0;
        int minutes = 0;
        int seconds = 0;

        if (playlist.Count != 0)
        {
            UpdateLenght(playlist, ref hours, ref minutes, ref seconds);
        }

        Console.WriteLine($"Playlist length: {hours}h {minutes}m {seconds}s");
    }

    private static void UpdateLenght(List<Song> playlist, ref int hours, ref int minutes, ref int seconds)
    {
        foreach (var song in playlist)
        {
            minutes += song.Minutes;
            seconds += song.Seconds;
        }

        if (seconds > 59)
        {
            minutes += seconds / 60;
            seconds = seconds % 60;
        }
        if (minutes > 59)
        {
            hours += minutes / 60;
            minutes = minutes % 60; 
        }
    }

    private static void FillPlaylist(List<Song> playlist)
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            try
            {
                string[] songInput = Console.ReadLine().Split(';');

                if (songInput.Length != 3)
                {
                    throw new ArgumentException("Invalid song.");
                }
                else
                {
                    AddSong(playlist, songInput);
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

    private static void AddSong(List<Song> playlist, string[] songInput)
    {
        string artistName = songInput[0];
        string songName = songInput[1];
        string songLenght = songInput[2];

        Song song = new Song(artistName, songName, songLenght);

        playlist.Add(song);

        Console.WriteLine("Song added.");
    }
}

