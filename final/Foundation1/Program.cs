using System;

class Program
{
    static List<Video> videos = new List<Video>();

    static void Main(string[] args)
    {        
        bool showMenu = true;

        // This loop is on charge to show the main menu until the user select option 5 (Quit)
        while (showMenu)
        {   
            showMenu = MainMenu();
        }            
    }

    /// <summary>
    /// This funnction is responsible of display the main menu and
    /// interact with options selected by the user.
    /// </summary>
    private static bool MainMenu()
    {                
        Console.WriteLine("Please select one of the following choices:");
        Console.WriteLine("1. Load list of videos from txt file");
        Console.WriteLine("2. Display list of videos");        
        Console.WriteLine("3. Quit");
        Console.Write("\r\nSelect a choice from the menu: ");                
        string currentOption = Console.ReadLine();        

        switch (currentOption)
        {
            case "1":
                LoadVideosFromTxtFile();
                Console.WriteLine("The list of videos were loaded sucessfully");
                return true;
            case "2":
                DisplayVideos();     
                return true;
            case "3":                                
                return false;            
            default:
                return true;
        }
    }

    private static void LoadVideosFromTxtFile()
    {                
        string[] lines = System.IO.File.ReadAllLines("youTubeVideos.txt");                       

        for (int i = 0; i < lines.Count(); i++)
        {
            List<Comment> comments = new List<Comment>();
            Video currentVideo = new Video();
            string[] parts = lines[i].Split(":");
            string[] videoAttributes = parts[0].Split(";");
            string[] commentsString = parts[1].Split(",");

            currentVideo.SetTitle(videoAttributes[0]);
            currentVideo.SetAuthor(videoAttributes[1]);
            currentVideo.SetLength(Convert.ToInt32(videoAttributes[2]));
            
            for (int j = 0; j < commentsString.Count(); j++)
            {
                Comment currentComment = new Comment();
                string[] commentAttributes = commentsString[j].Split("->");
                currentComment.SetPersonName(commentAttributes[0]);
                currentComment.SetText(commentAttributes[1]);
                comments.Add(currentComment); 
            }
            currentVideo.SetListOfComments(comments); 
            videos.Add(currentVideo);                  
        }               
    }

    private static void DisplayVideos()
    {                        
        foreach (var video in videos)
        {
            Console.WriteLine("\n\nVideo:==================================================================\n");
            video.DisplayVideo();
            Console.WriteLine("=======================================================================\n");
        }
    }
}