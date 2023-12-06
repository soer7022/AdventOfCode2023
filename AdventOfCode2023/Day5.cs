namespace AdventOfCode2023;

public class Day5
{

    class Map
    {
        private long destRangeStart;
        private long sourceRangeStart;
        private long rangeLength;

        public Map(long destRangeStart, long sourceRangeStart, long rangeLength)
        {
            this.destRangeStart = destRangeStart;
            this.sourceRangeStart = sourceRangeStart;
            this.rangeLength = rangeLength;
        }

        public bool isInRange(long number)
        {
            return number >= sourceRangeStart && number < sourceRangeStart + rangeLength;
        }

        public long mapNumber(long number)
        {
            var diff = destRangeStart - sourceRangeStart;
            return number + diff;
        }
    }
    public static string[] ReadInput()
    {
        return File.ReadAllLines("input/day5.txt");
    }

    public static void RunPart1()
    {
        var lines = ReadInput();
        var currentSeeds = new List<long>();

        for (int i = 0; i < lines.Length; i++)
        {
            var line = lines[i];
            if (i == 0)
            {
                var seeds = line.Split("seeds: ")[1].Split(" ").Select(long.Parse).ToList();
                currentSeeds.InsertRange(0,seeds);
            }

            if (i >= 3) // skip first 3 lines since they're placeholders
            {
                var maps = new List<Map>();
                while (true)
                {
                    try
                    {
                        line = lines[i];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        break;
                    }
                    if (line == "")
                    {
                        i++; // skip name of new map
                        break;
                    }

                    var numbers = line.Split(" ").Select(long.Parse).ToList();
                    maps.Add(new Map(numbers[0],numbers[1],numbers[2]));

                    i++;
                }

                for (int j = 0; j < currentSeeds.Count; j++)
                {
                    foreach (var map in maps)
                    {
                        if (map.isInRange(currentSeeds[j]))
                        {
                            currentSeeds[j] = map.mapNumber(currentSeeds[j]);
                            break;
                        }
                    }
                }
                
            }
            
        }
        
        Console.WriteLine(currentSeeds.Min());

    }

    public static void RunPart2()
    {
       
    }
}