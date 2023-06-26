using System;
using System.IO;

public class NameSorter
{
    public static void ReadFile(string filePath)
    {
        try
        {
            // Store individual full-names in Array
            string[] lines = File.ReadAllLines(filePath);
            
            // Break names into parts, sort by surname, then by first
            Array.Sort(lines, (x, y) =>
            {
                string[] nameX = x.Split(' ');
                string[] nameY = y.Split(' ');

                string lastNameX = nameX[nameX.Length - 1];
                string lastNameY = nameY[nameY.Length - 1];

                int lastNameComparison = lastNameX.CompareTo(lastNameY);
                if (lastNameComparison != 0)
                {
                    return lastNameComparison;
                }

                // If last names are the same, sort by first name
                string firstNameX = nameX[0];
                string firstNameY = nameY[0];
                return firstNameX.CompareTo(firstNameY);
            });

            // Print result to console
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }

        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }

    public static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Please provide a file path as an argument.");
        }
        else
        {
            string filePath = args[0];
            ReadFile(filePath);
        }

        Console.ReadLine();
    }
}

