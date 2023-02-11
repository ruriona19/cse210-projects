using System;
using System.Text.Json;

class Scripture
{
    // Contains the data related to the current reference
    private Reference _reference = new Reference();
    // Contains the list of words objected obtained from the scripture´s text. 
    private List<Word> _words = new List<Word>();
    // Boolean attribute to check if all words belonging to the scripture´s text are completely hidden.
    private bool _isCompletelyHidden = false;

     /// <summary>
    /// This method displays a menu and help the user save a scripture in a json file.
    /// </summary>    
    public void SaveScripture()
    {
        Console.Write("\r\nSelect to which canonical book the scripture you want to save belongs.\n");
        Console.WriteLine("1. Old Testament");        
        Console.WriteLine("2. New Testament");
        Console.WriteLine("3. The Book Of Mormon");        
        Console.WriteLine("4. Doctrine and Covenants");
        Console.WriteLine("5. Pearl of Great Price");        
        Console.Write("\r\nSelect from option 1 to 5\n");        
        string canonicalBook = Console.ReadLine();        
        
        Console.WriteLine("Enter the name of the book.");
        _reference.Book = Console.ReadLine();
        Console.WriteLine("Enter chapter number.");
        _reference.Chapter = Int16.Parse(Console.ReadLine());
        Console.WriteLine("Enter start verse.");
        _reference.StartVerse = Int16.Parse(Console.ReadLine());
        Console.WriteLine("Enter end verse.");
        _reference.EndVerse = Int16.Parse(Console.ReadLine());
        Console.WriteLine("Enter text.");
        _reference.Text = Console.ReadLine();

        switch (canonicalBook)
        {
            case "1":                
                SaveScriptureToJsonFile("OldTestament.json");
                break;
            case "2":                
                SaveScriptureToJsonFile("NewTestament.json");
                break;
            case "3":                
                SaveScriptureToJsonFile("TheBookOfMormon.json");
                break;
            case "4":                
                SaveScriptureToJsonFile("DoctrineAndConvenants.json");
                break;
            case "5":                
                SaveScriptureToJsonFile("PearlOfGreatPrice.json");
                break;
        }                
    }

    /// <summary>
    /// This method displays a menu in order the user may select the canonical scripture from which 
    /// the scripture to be memorized will be loaded.
    /// </summary>    
    public void LoadScriptureToMemorize()
    {
        Console.Write("\r\nSelect the canonical book from which you want to load the scripture.\n");
        Console.WriteLine("1. Old Testament");        
        Console.WriteLine("2. New Testament");
        Console.WriteLine("3. The Book Of Mormon");        
        Console.WriteLine("4. Doctrine and Covenants");
        Console.WriteLine("5. Pearl of Great Price");
        Console.Write("\r\nSelect from option 1 to 5\n");        
        
        string canonicalBook = Console.ReadLine();                

        switch (canonicalBook)
        {
            case "1":                      
                LoadScriptureFromJsonFile("Oldtament.json");
                _words = DumpTextScriptureToListOfWords(_reference.Text);                
                break;
            case "2":                                                
                LoadScriptureFromJsonFile("NewTestament.json");
                _words = DumpTextScriptureToListOfWords(_reference.Text);                
                break;
            case "3":                
                LoadScriptureFromJsonFile("TheBookOfMormon.json");
                _words = DumpTextScriptureToListOfWords(_reference.Text);                
                break;
            case "4":                
                LoadScriptureFromJsonFile("DoctrineAndCovenants.json");
                _words = DumpTextScriptureToListOfWords(_reference.Text);                
                break;
            case "5":                
                LoadScriptureFromJsonFile("PearlOfGreatPrice.json");
                _words = DumpTextScriptureToListOfWords(_reference.Text);                
                break;
        }
  
        ConsoleKeyInfo key;
        do
        {
            DisplayScripture();                    
            do
            {
                Console.WriteLine("Press enter to continue or type 'q' to finish: ");
                key = Console.ReadKey(true);                
            }
            while ((key.Key != ConsoleKey.Enter) && (key.Key != ConsoleKey.Q));
            HideWordsRandomly();
        }
        while((key.Key != ConsoleKey.Q) && (_isCompletelyHidden != true));
    }

    /// <summary>
    /// This method is on charge to display the scripture in the console
    /// </summary>
    private void DisplayScripture()
    {   
        string currentText = "";
        foreach (Word word in _words) 
        {
            if (!word.IsHidden)
            {
                currentText += word.Value;
                currentText += " ";
            }
            else
            {
                currentText += GetHiddenWord(word.Value.Length);
                currentText += " ";
            }   
        }

        if (_reference.StartVerse == _reference.EndVerse)
        {
            Console.WriteLine($"{_reference.Book} {_reference.Chapter}:{_reference.StartVerse}");
        }
        else
        {
            Console.WriteLine($"{_reference.Book} {_reference.Chapter}:{_reference.StartVerse}-{_reference.EndVerse}");      
        }
        
        Console.WriteLine($"{currentText}\n");                
    }

    /// <summary>
    /// This method is on charge of Deserialize and load a scripture from json file  
    /// </summary>
    /// <param name="filename">The name of the json file from which the scripture will be loaded</param>
    private void LoadScriptureFromJsonFile(string fileName)
    {
        string fileNamePath = "Scriptures/" + fileName;
        string jsonString = File.ReadAllText(fileNamePath);
        _reference = JsonSerializer.Deserialize<Reference>(jsonString);                        
    }

    /// <summary>
    /// This method is on charge of Serialize and save a scripture to a json file  
    /// </summary>
    /// <param name="filename">The name of the json file from which the scripture will be loaded</param>
    private void SaveScriptureToJsonFile(string fileName)
    {
        string fileNamePath = "Scriptures/" + fileName;
        string jsonString = JsonSerializer.Serialize<Reference>(_reference);        
        File.WriteAllText(fileNamePath, jsonString);
    }

    /// <summary>
    /// This method is on charge of dump the text belonging to the current scripture to a list of words
    /// </summary>
    /// <param name="textScripture">The text belonging to the current scripture</param>
    private List<Word> DumpTextScriptureToListOfWords(string textScripture)
    {
        string[] text = textScripture.Split(' ');
        foreach (string wordFromText in text) {
            Word word = new Word(wordFromText);
            _words.Add(word);
        }
        return _words;
    }

    /// <summary>
    /// This method is on charge of return a hidden word (underscore character) based of the number of characters related to the current workd
    /// </summary>
    /// <param name="numberOfCharactersFromWord">Number of characters of the current word</param>
    /// <returns>A string with the curernt word represented with underscore. E.g.: if the current word is "spirits" then this method will return "_______"</returns>
    private string GetHiddenWord(int numberOfCharactersFromWord)
    {
        string hiddenWord = "";
        for (int i = 0; i < numberOfCharactersFromWord; i++)
        {
            hiddenWord += string.Concat('_');
        }

        return hiddenWord;
    }

    /// <summary>
    /// This method is on charge of hide the words related to the current scripture randomly.
    /// </summary>
    private void HideWordsRandomly()
    {
        int wordsHidden = 0;
        int randomIndex;
        var random = new Random();
        
        if (_isCompletelyHidden == false)
        {
            while ((wordsHidden < 2) && (_isCompletelyHidden == false))
            {
                randomIndex = random.Next(_words.Count);
                if (!_words[randomIndex].IsHidden)
                {
                    _words[randomIndex].IsHidden = true;
                    wordsHidden += 1;    
                }   
                _isCompletelyHidden = _words.All(x => x.IsHidden == true);                         
            }    
        }
    }
}