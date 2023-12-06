namespace AdventOfCode2023;

public class Day6
{
    class Race
    {
        private long time;
        private long distance;

        public Race(long time, long distance)
        {
            this.time = time;
            this.distance = distance;
        }

        private bool isButtonPressTimeValid(long milliseconds)
        {
            var remainingTime = time - milliseconds;
            var speed = milliseconds;
            var travelledDistance = remainingTime * speed;
            return travelledDistance > distance;
        }

        public long getWaysOfWinning()
        {
            var totalWays = 0;
            for (long i = 0; i < time; i++)
            {
                if (isButtonPressTimeValid(i))
                {
                    totalWays++;
                } else if (totalWays > 0)
                {
                    break;
                }
            }

            return totalWays;
        }
    }
    public static string[] ReadInput()
    {
        return File.ReadAllLines("input/day6.txt");
    }


    public static void RunPart1()
    {
        var lines = ReadInput();
        var timeStamps = lines[0].Split(":")[1].Split(" ").Where(s => !string.IsNullOrWhiteSpace(s)).Select(int.Parse).ToList();
        var distances = lines[1].Split(":")[1].Split(" ").Where(s => !string.IsNullOrWhiteSpace(s)).Select(int.Parse).ToList();
        var races = new List<Race>();
        for (int i = 0; i < timeStamps.Count; i++)
        {
            races.Add(new Race(timeStamps[i],distances[i]));
        }

        long total = 1;

        foreach (var race in races)
        {
            total *= race.getWaysOfWinning();
        }
        
        Console.WriteLine(total);

    }

    public static void RunPart2()
    {
        var lines = ReadInput();
        var timeStamps = lines[0].Split(":")[1].Split(" ").Where(s => !string.IsNullOrWhiteSpace(s)).Select(int.Parse).ToList();
        var distances = lines[1].Split(":")[1].Split(" ").Where(s => !string.IsNullOrWhiteSpace(s)).Select(int.Parse).ToList();
        var actualTimestampString = "";
        var actualDistanceString = "";
        
        for (int i = 0; i < timeStamps.Count; i++)
        {
            actualTimestampString += timeStamps[i];
            actualDistanceString += distances[i];
        }

        var race = new Race(long.Parse(actualTimestampString), long.Parse(actualDistanceString));

        var total = race.getWaysOfWinning();
        
        Console.WriteLine(total);
    }
}