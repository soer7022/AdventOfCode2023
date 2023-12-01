namespace AdventOfCode2023;

public class Day1
{
    public static string[] ReadInput()
    {
        return File.ReadAllLines("input/day1.txt");
    }
    public static void RunPart1()
    {
        var totalSum = 0;
        foreach (var line in ReadInput())
        {
            totalSum += GetSumForLine(line, totalSum);
        }
        
        Console.WriteLine(totalSum);
        
    }

    private static int GetSumForLine(string line, int totalSum)
    {
        int firstNumber = -1;
        int lastNumber = -1;
        int currentNumber;
        foreach (var character in line)
        {
            if (int.TryParse(character.ToString(), out currentNumber))
            {
                if (firstNumber == -1)
                    firstNumber = currentNumber;

                lastNumber = currentNumber;
            }
        }

        return int.Parse(firstNumber + lastNumber.ToString());
    }

    public static void RunPart2()
    {
        int totalSum = 0;
        foreach (var line in ReadInput())
        {
            var lineForSolve = line;
            lineForSolve = lineForSolve.Replace("one", "o1e");
            lineForSolve = lineForSolve.Replace("two", "t2o");
            lineForSolve = lineForSolve.Replace("three", "t3e");
            lineForSolve = lineForSolve.Replace("four", "f4r");
            lineForSolve = lineForSolve.Replace("five", "f5e");
            lineForSolve = lineForSolve.Replace("six", "s6x");
            lineForSolve = lineForSolve.Replace("seven", "s7n");
            lineForSolve = lineForSolve.Replace("eight", "e8t");
            lineForSolve = lineForSolve.Replace("nine", "n9e");
            totalSum += GetSumForLine(lineForSolve, totalSum);
        }
        Console.WriteLine(totalSum);
        
    }
}