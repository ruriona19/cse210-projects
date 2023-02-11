using System;

class Word
{
    // Contains the value related to the current word object
    public string Value {get; set;}
    // boolean flag to indicate whether the current word is hidden or not
    public bool IsHidden { get; set; }

    /// <summary>
    /// This constructor initialize the word object requireng the value property as a required attribute.
    /// </summary>
    /// <param name="value">The value related to the current word</param>
    public Word(string value)
    {
        this.Value = value;
        this.IsHidden = false;
    }    
}