namespace AdventOfCode2023;

public class Day4
{
    public static string[] ReadInput()
    {
        return File.ReadAllLines("input/day4.txt");
    }

    public static int getValueOfCard(List<int> winningNumbers, List<int> yourNumbers)
    {
        var worth = 0;
        foreach (var number in yourNumbers)
        {
            if (winningNumbers.Contains(number))
            {
                if (worth == 0)
                {
                    worth = 1;
                }
                else
                {
                    worth *= 2;
                }
            }
        }

        return worth;
    }

    public static void RunPart1()
    {
        var total = 0;
        foreach (var line in ReadInput())
        {
            var numbers = line.Split(": ")[1].Split(" | ");
            var winningNumbers = numbers[0].Split(" ").Where(s => !string.IsNullOrWhiteSpace(s)).Select(int.Parse).ToList();

            var yourNumbers = numbers[1].Split(" ").Where(s => !string.IsNullOrWhiteSpace(s)).Select(int.Parse).ToList();

            total += getValueOfCard(winningNumbers, yourNumbers);
        }

        Console.WriteLine(total);
    }

    public static void RunPart2()
    {
        List<(List<int>, List<int>)> cards = new List<(List<int>, List<int>)>(); // 0 indexed

        var copies = new Dictionary<int, int>();
        var input = ReadInput();
        for (int i = 0; i < input.Length; i++)
        {
            copies[i + 1] = 1;
        }

        foreach (var line in input)
        {
            var cardNumber = int.Parse(line.Split("Card ")[1].Split(":")[0]);
            
            var numbers = line.Split(": ")[1].Split(" | ");
            var winningNumbers = numbers[0].Split(" ").Where(s => !string.IsNullOrWhiteSpace(s)).Select(int.Parse).ToList();
            var yourNumbers = numbers[1].Split(" ").Where(s => !string.IsNullOrWhiteSpace(s)).Select(int.Parse).ToList();
            var counter = 1;
            foreach (var number in yourNumbers)
            {
                if (winningNumbers.Contains(number))
                {
                    copies[cardNumber + counter] += 1 * copies[cardNumber];
                    counter += 1;
                }
            }
        }

        var total = 0;
        foreach (var pair  in copies)
        {
            total += pair.Value;
        }
        
        Console.WriteLine(total);
    }
}