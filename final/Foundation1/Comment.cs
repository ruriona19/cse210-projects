public class Comment 
{    
    private string _personName;
    private string _text;

    public string GetPersonName()
    {
        return _personName;
    }

    public void SetPersonName(string personName)
    {
        _personName = personName;
    }

    public string GetText()
    {
        return _text;
    }

    public void SetText(string text)
    {
        _text = text;
    }

    public void DisplayComment()
    {
        Console.WriteLine($"     Person Name: {_personName}");
        Console.WriteLine($"     Text: {_text}");
    }
}