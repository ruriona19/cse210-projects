public class Entry 
{
    // Read only property to save the date in which an entry is created.
    public string date {get;}

    // Public property to read and write the prompt
    public string prompt {get; set; }

    // Public property to read and write the response provided by the user
    public string response {get; set; }    

    /// <summary>
    /// Constructs a new entry instance 
    /// </summary>
    /// <param name="prompt">The prompt related to the current entry</param>
    /// <param name="response">The response related to the current entry</param>
    public Entry(string prompt, string response)
    {
        this.prompt = prompt;
        this.response = response;
        this.date = DateTime.Now.ToString("dd/MM/yyyy");
    }

    /// <summary>
    /// Displays the prompt, date and response related to the current entry.
    /// </summary>
    public void Display()
    {
        Console.WriteLine($"Date: {this.date.ToString()} - Prompt: {this.prompt}");
        Console.WriteLine($"{this.response}\n");
    }
}