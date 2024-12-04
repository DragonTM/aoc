using System.Text.RegularExpressions;

public class TaskThree
{
    public void ExecutePartOne()
    {
        using var inputFile = new StreamReader("input.txt");

        const string memoryRgx = "mul\\([1-9][0-9]{0,2},[1-9][0-9]{0,2}\\)";

        var line = inputFile.ReadLine();
        var result = 0;
        while (!string.IsNullOrEmpty(line))
        {
            foreach (Match match in Regex.Matches(line, memoryRgx))
            {
                var numbers = match
                    .Value
                    .Substring(0, match.Value.Length - 1)
                    .Substring(4)
                    .Split(",")
                    .Select(n => int.Parse(n))
                    .ToArray();

                result += numbers[0] * numbers[1];
            }

            line = inputFile.ReadLine();
        }

        using var outputFile = new StreamWriter("output.txt", false);

        outputFile.Write(result);
    }

    public void ExecutePartTwo()
    {
        using var inputFile = new StreamReader("input.txt");

        const string memoryRgx = "(mul\\([1-9][0-9]{0,2},[1-9][0-9]{0,2}\\))|do\\(\\)|don't\\(\\)";
        const string doStr = "do()";
        const string dontStr = "don't()";

        var line = inputFile.ReadLine();
        var result = 0;
        var multiply = true;
        while (!string.IsNullOrEmpty(line))
        {
            foreach (Match match in Regex.Matches(line, memoryRgx))
            {
                if (match.Value == dontStr)
                {
                    multiply = false;
                    continue;
                }

                if (match.Value == doStr)
                {
                    multiply = true;
                    continue;
                }

                if (!multiply)
                {
                    continue;
                }

                var numbers = match
                    .Value
                    .Substring(0, match.Value.Length - 1)
                    .Substring(4)
                    .Split(",")
                    .Select(n => int.Parse(n))
                    .ToArray();

                result += numbers[0] * numbers[1];
            }

            line = inputFile.ReadLine();
        }

        using var outputFile = new StreamWriter("output.txt", false);

        outputFile.Write(result);
    }
}