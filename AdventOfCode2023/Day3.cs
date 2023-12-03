namespace AdventOfCode2023;

public class Day3
{
    public static string[] ReadInput()
    {
        return File.ReadAllLines("input/day3.txt");
    }

    public static void RunPart1()
    {
        var map = ReadInput();
        var positionsSeen = new List<(int,int)>();
        var totalSum = 0;
        for (int i = 0; i < map.Length; i++)
        {
            for (int j = 0; j < map[0].Length; j++)
            {
                int parsed;
                if (!int.TryParse(map[i][j].ToString(), out parsed) && map[i][j].ToString() != ".")
                {
                    for (int k = -1; k < 2; k++)
                    {
                        for (int l = -1; l < 2; l++)
                        {
                            if (positionsSeen.Contains((i+k,j+l)))
                                continue;
                            if (k == 0 && l == 0)
                                continue;

                            var number = "";
                            var letter = map[i + k][j + l];
                            if (int.TryParse(letter.ToString(), out parsed))
                            {
                                positionsSeen.Add((i+k,j+l));
                                // we found a number lets try to build it
                                number = parsed.ToString();
                                var index = -1;
                                // scan to the left
                                while (true)
                                {
                                    try
                                    {
                                        if (int.TryParse(map[i + k][j + l + index].ToString(), out parsed))
                                        {
                                            number = parsed + number;
                                            positionsSeen.Add((i+k,j+l+index));
                                            index--;
                                            
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                    catch (IndexOutOfRangeException)
                                    {
                                        break;
                                    }
                                }

                                index = 1;
                                while (true)
                                {
                                    try
                                    {
                                        if (int.TryParse(map[i + k][j + l + index].ToString(), out parsed))
                                        {
                                            number += parsed;
                                            positionsSeen.Add((i+k,j+l+index));
                                            index++;
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                    catch (IndexOutOfRangeException)
                                    {
                                        break;
                                    }
                                }

                                var finalNumber = int.Parse(number);
                                
                                totalSum += finalNumber;
                                
                            }
                        }
                    }
                }
            }
        }

        Console.WriteLine(totalSum);
    }

    public static void RunPart2()
    {
        var map = ReadInput();
        var positionsSeen = new List<(int,int)>();
        var totalSum = 0;
        for (int i = 0; i < map.Length; i++)
        {
            for (int j = 0; j < map[0].Length; j++)
            {
                int parsed;
                if (map[i][j].ToString() == "*")
                {
                    var numbersAroundGear = new List<int>();
                    for (int k = -1; k < 2; k++)
                    {
                        for (int l = -1; l < 2; l++)
                        {
                            if (positionsSeen.Contains((i+k,j+l)))
                                continue;
                            if (k == 0 && l == 0)
                                continue;

                            var number = "";
                            var letter = map[i + k][j + l];
                            if (int.TryParse(letter.ToString(), out parsed))
                            {
                                positionsSeen.Add((i+k,j+l));
                                // we found a number lets try to build it
                                number = parsed.ToString();
                                var index = -1;
                                // scan to the left
                                while (true)
                                {
                                    try
                                    {
                                        if (int.TryParse(map[i + k][j + l + index].ToString(), out parsed))
                                        {
                                            number = parsed + number;
                                            positionsSeen.Add((i+k,j+l+index));
                                            index--;
                                            
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                    catch (IndexOutOfRangeException)
                                    {
                                        break;
                                    }
                                }

                                index = 1;
                                while (true)
                                {
                                    try
                                    {
                                        if (int.TryParse(map[i + k][j + l + index].ToString(), out parsed))
                                        {
                                            number += parsed;
                                            positionsSeen.Add((i+k,j+l+index));
                                            index++;
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                    catch (IndexOutOfRangeException)
                                    {
                                        break;
                                    }
                                }

                                var finalNumber = int.Parse(number);
                                
                                numbersAroundGear.Add(finalNumber);
                                
                            }
                        }
                    }

                    if (numbersAroundGear.Count == 2)
                    {
                        totalSum += numbersAroundGear[0] * numbersAroundGear[1];
                    }
                }
            }
        }

        Console.WriteLine(totalSum);
    }
}