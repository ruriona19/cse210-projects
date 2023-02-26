using System;
using System.Text.Json;

class QuestionToReflect
{
    // Contains the question related to this object
    private string _question;
    
    // Contains a flag to verify if the question was already used or not
    // in the reflection activity
    private bool _alreadyDisplayed;

    public string Question 
    { 
        get { return _question; }
        set { _question = value; } 
    }

    public bool AlreadyDisplayed 
    { 
        get { return _alreadyDisplayed; }
        set { _alreadyDisplayed = value; }
    }
}