using System.ComponentModel.Design.Serialization;

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
    if (right.TryGetValue(left[i], out var count)){
        result += count * left[i];
    }
}

using var outputFile = new StreamWriter("output.txt", false);

outputFile.Write(result);