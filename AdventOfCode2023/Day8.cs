namespace AdventOfCode2023;

public class Day8
{
    public static string[] ReadInput()
    {
        return File.ReadAllLines("input/day8.txt");
    }

    public static void RunPart1()
    {
        var lines = ReadInput();
        var instructions = lines[0];
        var rawNodes = new Dictionary<string, (string, string)>();
        for (int i = 2; i < lines.Length; i++)
        {
            var nodeName = lines[i].Split(" = ")[0];
            var left = lines[i].Split("(")[1].Split(", ")[0];
            var right = lines[i].Split(", ")[1].Split(")")[0];
            rawNodes.Add(nodeName, (left, right));
        }

        var count = 0;
        var currentNodeName = "AAA";
        var currentNode = rawNodes[currentNodeName];

        while (true)
        {
            if (currentNodeName == "ZZZ")
            {
                break;
            }

            var instruction = instructions[count % instructions.Length];

            currentNodeName = instruction == 'L' ? currentNode.Item1 : currentNode.Item2;
            currentNode = rawNodes[currentNodeName];

            count++;
        }

        Console.WriteLine(count);
    }

    static int gcd(int a, int b)
    {
        if (b == 0)
            return a;
        return gcd(b, a % b);
    }

    static int LCM(List<int> arr, int index)
    {
        if (index == arr.Count - 1)
            return arr[index];
        int a = arr[index];
        int b = LCM(arr, index + 1);
        return a * b / gcd(a, b);
    }

    public static void RunPart2()
    {
        var lines = ReadInput();
        var instructions = lines[0];
        var rawNodes = new Dictionary<string, (string, string)>();
        for (int i = 2; i < lines.Length; i++)
        {
            var nodeName = lines[i].Split(" = ")[0];
            var left = lines[i].Split("(")[1].Split(", ")[0];
            var right = lines[i].Split(", ")[1].Split(")")[0];
            rawNodes.Add(nodeName, (left, right));
        }

        var startingNodeNames = new List<string>();
        foreach (var (key, _) in rawNodes)
        {
            if (key.EndsWith("A"))
            {
                startingNodeNames.Add(key);
            }
        }


        var pathLengths = new List<int>();

        for (int i = 0; i < startingNodeNames.Count; i++)
        {
            var currentNodeName = startingNodeNames[i];
            var currentNode = rawNodes[currentNodeName];
            var count = 0;
            while (true)
            {
                if (currentNodeName.EndsWith("Z"))
                {
                    break;
                }

                var instruction = instructions[count % instructions.Length];

                currentNodeName = instruction == 'L' ? currentNode.Item1 : currentNode.Item2;
                currentNode = rawNodes[currentNodeName];

                count++;
            }

            pathLengths.Add(count);
        }
        foreach (var pathLength in pathLengths)
        {
            Console.Write(pathLength + ",");
        }
        // path length is 6 elements
        var answer = pathLengths.Aggregate((x, y) => x * y / gcd(x, y));
        Console.WriteLine(answer);
    }
}