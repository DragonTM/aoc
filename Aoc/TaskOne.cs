public class TaskOne
{
    public void ExecutePartOne()
    {
        using var inputFile = new StreamReader("input.txt");

        var line = inputFile.ReadLine();
        var left = new List<int>();
        var right = new List<int>();

        while (!string.IsNullOrEmpty(line))
        {
            var numbers = line.Split(" ").Where(v => !string.IsNullOrEmpty(v)).Select(v => int.Parse(v)).ToArray();

            if (left.Count < 1)
            {
                left.Add(numbers[0]);
                right.Add(numbers[1]);
            }
            else
            {
                var addLeftAdd = FindPlace(left, numbers[0]);
                if (addLeftAdd < left.Count)
                {
                    left.Insert(addLeftAdd, numbers[0]);
                }
                else
                {
                    left.Add(numbers[0]);
                }

                var addRightAdd = FindPlace(right, numbers[1]);
                if (addRightAdd < right.Count)
                {
                    right.Insert(addRightAdd, numbers[1]);
                }
                else
                {
                    right.Add(numbers[1]);
                }
            }

            line = inputFile.ReadLine();
        }

        var result = 0;

        for (var i = 0; i < left.Count; i++)
        {
            result += Math.Abs(left[i] - right[i]);
        }

        using var outputFile = new StreamWriter("output.txt", false);

        outputFile.Write(result);

        int FindPlace(List<int> list, int value)
        {
            var i = 0;
            while (i < list.Count && list[i] < value)
            {
                i++;
            }

            return i;
        }
    }

    public void ExecutePartTwo()
    {
        using var inputFile = new StreamReader("input.txt");

        var line = inputFile.ReadLine();
        var left = new List<int>();
        var right = new Dictionary<int, int>();

        while (!string.IsNullOrEmpty(line))
        {
            var numbers = line.Split(" ").Where(v => !string.IsNullOrEmpty(v)).Select(v => int.Parse(v)).ToArray();

            left.Add(numbers[0]);

            if (right.ContainsKey(numbers[1]))
            {
                right[numbers[1]]++;
            }
            else
            {
                right.Add(numbers[1], 1);
            }

            line = inputFile.ReadLine();
        }

        var result = 0;

        for (var i = 0; i < left.Count; i++)
        {
            if (right.TryGetValue(left[i], out var count))
            {
                result += count * left[i];
            }
        }

        using var outputFile = new StreamWriter("output.txt", false);

        outputFile.Write(result);
    }
}