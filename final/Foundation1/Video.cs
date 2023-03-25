using System;
using System.Globalization;

public class Video 
{    
    private string _title;
    private string _author;
    private int _length;
    private List<Comment> _comments;
        
    public int GetNumberOfComments()
    {
        return _comments.Count();
    }

    public string GetTitle()
    {
        return _title;
    }

    public void SetTitle(string title)
    {
        _title = title;
    }

    public string GetAuthor()
    {
        return _author;
    }

    public void SetAuthor(string author)
    {
        _author = author;
    }

    public int GetLength()
    {
        return _length;
    }

    public void SetLength(int length)
    {
        _length = length;
    }

    public List<Comment> GetListOfComments()
    {
        return _comments;
    }

    public void SetListOfComments(List<Comment> comments)
    {
        _comments = comments;
    }

    public void DisplayVideo()
    {
        Console.WriteLine($"Title: {_title}");
        Console.WriteLine($"Author: {_author}");
        Console.WriteLine($"Length In Seconds: {_length}");
        Console.WriteLine("     ************************************************\n");
        for (int i = 0; i < GetNumberOfComments(); i++)
        {
            Console.WriteLine($"     Comment {i+1}:");
            _comments[i].DisplayComment();
        }        
        Console.WriteLine("     *************************************************\n");
    }
}