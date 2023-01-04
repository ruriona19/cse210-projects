using System;

class Program
{
    static void Main(string[] args)
    {
        string letterGrade = "";
        string letterGradeSign = ""; 
        int remainder = 0;

        Console.WriteLine("Please enter your grade percentage: ");
        int percentageGrade = Int16.Parse(Console.ReadLine());        

        // Get the letter grade from the percentage grade
        if (percentageGrade >= 90)
        {
            letterGrade = "A";
        }
        else if (percentageGrade >= 80)
        {
            letterGrade = "B";
        }
        else if (percentageGrade >= 70)
        {
            letterGrade = "C";
        }
        else if (percentageGrade >= 60)
        {
            letterGrade = "D";
        }
        else
        {
            letterGrade = "F";
        }

        // Get the letter grade sign
        remainder = percentageGrade%10; 
        if (remainder >= 7 && percentageGrade < 90 && percentageGrade >= 60)
        {
            letterGradeSign = "+";
        }
        else if (remainder < 3 && percentageGrade != 100 && percentageGrade >= 60)
        {
            letterGradeSign = "-";
        }
        else
        {
            letterGradeSign = "";
        }


        Console.WriteLine($"This is your letter grade: {letterGrade}{letterGradeSign}");

        if (percentageGrade >= 70)
        {
            Console.WriteLine("Congratulation you have passed!");
        }
        else
        {
            Console.WriteLine("Failure should be our teacher, not our undertaker. I encourage you to don´t give up and keep trying.");
        }
    }
}