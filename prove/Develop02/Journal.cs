using System;
using System.Globalization;
using CsvHelper.Configuration;
using CsvHelper;

public class Journal 
{
    // Contains a list of entries associated to the journal object.
    public List<Entry> _entries = new List<Entry>();

    // Declaring a current entry field.
    public Entry _currentEntry;
        

    /// <summary>
    /// Instantiate a new entry  
    /// </summary>
    /// <param name="prompt">The prompt displayed to the user</param>
    /// <param name="response">The response provided by the user</param>
    /// <returns>The Entry object instantiated</returns>
    public Entry WriteEntry(string prompt, string response)
    {              
        _currentEntry = new Entry(prompt, response);       

        return _currentEntry; 
    }

    /// <summary>
    /// Displays all the entries from _entries list
    /// </summary>    
    public void DisplayEntries()
    {        
        foreach (Entry currentEntry in _entries) {
              currentEntry.Display();
          }  
    }

    /// <summary>
    /// Save all the entries located in _entries list to a given file name
    /// If the given file name does not exist, then a new csv file is created
    /// </summary>
    public void SaveEntries()
    {   
        Console.WriteLine($"What is the file name?");
        string fileName = Console.ReadLine();
        bool fileExists = File.Exists(fileName);        
        bool writeHeaderRecord;
        bool appendEntryToFile;
        
        if (fileExists)
        {
            Console.WriteLine($"The file name you entered already exists.");
            Console.WriteLine($"Do you want to append the new entries to the file? (Y/N).");
            string response = Console.ReadLine();
            if (response.Equals("Y"))
            {   
                writeHeaderRecord = false;
                appendEntryToFile = true;
                WriteEntryToCSVFile(writeHeaderRecord, appendEntryToFile, fileName);
                Console.WriteLine($"The file {fileName} has been appended successfully.");
            }
            else if (response.Equals("N"))
            {
                writeHeaderRecord = true;
                appendEntryToFile = false;
                WriteEntryToCSVFile(writeHeaderRecord, appendEntryToFile, fileName);
                Console.WriteLine($"The file {fileName} has been overwritten successfully.");
            }
            else
            {
                Console.WriteLine($"Please enter a vilid answer (Y/N).");
            }
        }
        else
        {
            writeHeaderRecord = true;
            appendEntryToFile = false;
            WriteEntryToCSVFile(writeHeaderRecord, appendEntryToFile, fileName);
            Console.WriteLine($"The file {fileName} has been created and written successfully.");
        }   
    }

    /// <summary>
    /// Load all the entries located in a given csv file.
    /// If the csv file name provided does not exists, then only a message is displayed
    /// explaining that the file does not exists
    /// </summary>
    public void LoadEntries()
    {
        Console.WriteLine("What is the file name from which you will load the entries?");
        string fileName = Console.ReadLine();
        bool fileExists = File.Exists(fileName); 
        if (fileExists)
        {
            var reader = new StreamReader(fileName); 
            var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);
            IEnumerable<Entry> result = csvReader.GetRecords<Entry>();
            _entries = result.ToList<Entry>();

            csvReader.Dispose();
            reader.Dispose();
        }
        else
        {
            Console.WriteLine($"The file {fileName} does not exist?");
        }                
    }  

    /// <summary>
    /// Auxiliar method to write entries to a CSV file
    /// The CSVHelper library is used to deal with csv files
    /// </summary>
    private void WriteEntryToCSVFile(bool writeHeaderRecord, bool appendEntryToFile, string fileName)
    {
       
        CsvConfiguration csvConfig = new CsvConfiguration(CultureInfo.CurrentCulture)
        {
            HasHeaderRecord = writeHeaderRecord
        };
                        
        var writer = new StreamWriter(fileName, appendEntryToFile);
        var csvWriter = new CsvWriter(writer, csvConfig);
        csvWriter.WriteRecords(_entries);

        csvWriter.Dispose();
        writer.Dispose();        
    }
}