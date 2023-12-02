namespace AdventOfCode2023;

public class Day2
{
    public static string[] ReadInput()
    {
        return File.ReadAllLines("input/day2.txt");
    }

    public static bool isGamePossible(string line)
    {
        var games = line.Split(": ")[1].Split("; ");

        foreach (var game in games)
        {
            var reveals = game.Split(", ");
            foreach (var reveal in reveals)
            {
                var number = int.Parse(reveal.Split(" ")[0]);
                var color = reveal.Split(" ")[1];
                if (color == "red" && number > 12)
                {
                    return false;
                }

                if (color == "green" && number > 13)
                {
                    return false;
                }

                if (color == "blue" && number > 14)
                {
                    return false;
                }
            }
        }

        return true;
    }

    public static int getPowerOfGame(string line)
    {
        var minRed = 0;
        var minGreen = 0;
        var minBlue = 0;

        var games = line.Split(": ")[1].Split("; ");

        foreach (var game in games)
        {
            var reveals = game.Split(", ");
            foreach (var reveal in reveals)
            {
                var number = int.Parse(reveal.Split(" ")[0]);
                var color = reveal.Split(" ")[1];

                if (color == "red" && number > minRed)
                {
                    minRed = number;
                }

                if (color == "blue" && number > minBlue)
                {
                    minBlue = number;
                }

                if (color == "green" && number > minGreen)
                {
                    minGreen = number;
                }
            }
        }

        return minRed * minBlue * minGreen;
        
    }

    public static void RunPart1()
    {
        var totalSum = 0;
        foreach (var line in ReadInput())
        {
            var gameID = int.Parse(line.Split("Game ")[1].Split(":")[0]);
            if (isGamePossible(line))
            {
                totalSum += gameID;
            }
        }
        Console.WriteLine(totalSum);
    }

    public static void RunPart2()
    {
        var totalSum = 0;
        foreach (var line in ReadInput())
        {
            totalSum += getPowerOfGame(line);
        }
        Console.WriteLine(totalSum);
    }
}