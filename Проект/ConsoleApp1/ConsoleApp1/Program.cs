using System;

public abstract class Movie
{
    public abstract string GetSoundtrackLanguage();
    public abstract string GetSubtitleLanguage();
}
public abstract class MovieFactory
{
    public abstract Movie CreateMovie();
}

public class EnglishMovieFactory : MovieFactory
{
    public override Movie CreateMovie()
    {
        return new EnglishMovie();
    }
}
public class RussianMovieFactory : MovieFactory
{
    public override Movie CreateMovie()
    {
        return new RussianMovie();
    }
}

public class EnglishMovie : Movie
{
    public override string GetSoundtrackLanguage()
    {
        return "English";
    }
    public override string GetSubtitleLanguage()
    {
        return "English";
    }
}
public class RussianMovie : Movie
{
    public override string GetSoundtrackLanguage()
    {
        return "Russian";
    }
    public override string GetSubtitleLanguage()
    {
        return "Russian";
    }
}

class Program
{
    static void Main(string[] args)
    {
        MovieFactory englishFactory = new EnglishMovieFactory();
        Movie englishMovie = englishFactory.CreateMovie();
        MovieFactory russianFactory = new RussianMovieFactory();
        Movie russianMovie = russianFactory.CreateMovie();
        Console.WriteLine("English Movie:");
        Console.WriteLine("Soundtrack language: " + englishMovie.GetSoundtrackLanguage());
        Console.WriteLine("Subtitle language: " + englishMovie.GetSubtitleLanguage());
        Console.WriteLine();
        Console.WriteLine("Russian Movie:");
        Console.WriteLine("Soundtrack language: " + russianMovie.GetSoundtrackLanguage());
        Console.WriteLine("Subtitle language: " + russianMovie.GetSubtitleLanguage());
        Console.ReadLine();
    }
}