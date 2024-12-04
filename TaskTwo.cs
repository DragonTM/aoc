public class TaskTwo
{
    public void ExecutePartOne()
    {
        using var inputFile = new StreamReader("input.txt");

        var line = inputFile.ReadLine();
        var result = 0;
        while (!string.IsNullOrEmpty(line))
        {
            var numbers = line.Split(" ").Where(v => !string.IsNullOrEmpty(v)).Select(v => int.Parse(v)).ToList();

            if (IsSafe(numbers))
            {
                result++;
            }

            line = inputFile.ReadLine();
        }

        using var outputFile = new StreamWriter("output.txt", false);

        outputFile.Write(result);

        bool IsSafe(List<int> numbers)
        {
            const int maxDiff = 3;

            var num = numbers[0];
            var trend = 0;

            for (var i = 1; i < numbers.Count; i++)
            {
                var diff = numbers[i] - num;

                if (Math.Abs(diff) < 1 || Math.Abs(diff) > maxDiff)
                {
                    return false;
                }

                if (trend == 0)
                {
                    trend = diff;
                }
                else
                {
                    if (trend * diff < 0)
                    {
                        return false;
                    }
                }

                num = numbers[i];
            }

            return true;
        }
    }
}