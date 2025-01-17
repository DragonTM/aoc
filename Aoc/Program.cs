using var inputFile = new StreamReader("input.txt");

var line = inputFile.ReadLine();
var result = 0;
var display = new List<List<char>>();

while (!string.IsNullOrEmpty(line))
{
    display.Add([.. line]);

    line = inputFile.ReadLine();
}

for (var i = 1; i < display.Count - 1; i++)
{
    for (var j = 1; j < display[i].Count - 1; j++)
    {
        if (Xmas(display, i, j))
        {
            result++;
        }
    }

}

using var outputFile = new StreamWriter("output.txt", false);

outputFile.Write(result);

return;

bool Xmas(List<List<char>> display, int i, int j)
{
    if (display[i][j] != 'A')
    {
        return false;
    }

    var xmas = display[i - 1][j - 1].ToString() + display[i][j] + display[i + 1][j + 1];

    if (xmas != "MAS" && xmas != "SAM")
    {
        return false;
    }

    xmas = display[i - 1][j + 1].ToString() + display[i][j] + display[i + 1][j - 1];

    if (xmas != "MAS" && xmas != "SAM")
    {
        return false;
    }

    return true;
}