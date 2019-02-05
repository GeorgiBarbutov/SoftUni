using System;

public class Song
{
    private const int MIN_ARTIST_NAME_LENGHT = 3;
    private const int MAX_ARTIST_NAME_LENGHT = 20;
    private const int MIN_SONG_NAME_LENGHT = 3;
    private const int MAX_SONG_NAME_LENGHT = 30;
    private const int MIN_MINUTES = 0;
    private const int MAX_MINUTES = 14;
    private const int MIN_SECONDS = 0;
    private const int MAX_SECONDS = 59;

    private string artistName;
    private string songName;
    private int minutes;
    private int seconds;

    public Song(string artistName, string songName, string songLenght)
    {
        ArtistName = artistName;
        SongName = songName;

        CheckLenght(songLenght);

        int indexOfSemiColumn = songLenght.IndexOf(':');

        int songMinutes = int.Parse(songLenght.Substring(0, indexOfSemiColumn));
        int songSeconds = int.Parse(songLenght.Substring(indexOfSemiColumn + 1));

        Minutes = songMinutes;
        Seconds = songSeconds;
    }

    private static void CheckLenght(string songLenght)
    {
        if (!songLenght.Contains(":") || songLenght.Split(':').Length != 2)
            throw new ArgumentException("Invalid song length.");
        else if (!int.TryParse(songLenght.Split(':')[0], out int result1) || !int.TryParse(songLenght.Split(':')[1], out int result))
        {
            throw new ArgumentException("Invalid song length.");
        }
    }

    public int Seconds
    {
        get { return seconds; }

        private set
        {
            if (value < MIN_SECONDS || value > MAX_SECONDS)
                throw new ArgumentException($"Song seconds should be between {MIN_SECONDS} and {MAX_SECONDS}.");

            seconds = value;
        }
    }

    public int Minutes
    {
        get { return minutes; }

        private set
        {
            if (value < MIN_MINUTES || value > MAX_MINUTES)
                throw new ArgumentException($"Song minutes should be between {MIN_MINUTES} and {MAX_MINUTES}.");

            minutes = value;
        }
    }

    private string SongName
    {
        get { return songName; }

        set
        {
            if (value.Length < MIN_SONG_NAME_LENGHT || value.Length > MAX_SONG_NAME_LENGHT)
                throw new ArgumentException($"Song name should be between {MIN_SONG_NAME_LENGHT} and {MAX_SONG_NAME_LENGHT} symbols.");

            songName = value;
        }
    }

    private string ArtistName
    {
        get { return artistName; }

        set
        {
            if (value.Length < MIN_ARTIST_NAME_LENGHT || value.Length > MAX_ARTIST_NAME_LENGHT)
                throw new ArgumentException($"Artist name should be between {MIN_ARTIST_NAME_LENGHT} and {MAX_ARTIST_NAME_LENGHT} symbols.");

            artistName = value;
        }
    }
}

