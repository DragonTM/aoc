using var inputFile = new StreamReader("input.txt");

var line = inputFile.ReadLine();
var result = 0;
var display = new List<List<char>>();

while (!string.IsNullOrEmpty(line))
{
    display.Add([.. line]);

    line = inputFile.ReadLine();
}

for (var i = 0; i < display.Count; i++)
{
    result += Horizontal(display, i);
    
    if (i != 0 && i != display.Count - 1)
    {
        result += Diagonal(display, i, 0);
    }
}

for (var j = 0; j < display[1].Count; j++)
{
    result += Vertical(display, j);
}

result += Diagonal(display, 0, 0);

using var outputFile = new StreamWriter("output.txt", false);

outputFile.Write(result);

return;

int Horizontal(List<List<char>> display, int i)
{
    var counter = 0;
    var word = string.Empty;

    for (var j = 0; j < display[i].Count; j++)
    {
        word = TheWord(display[i][j], word);

        if (word == "XMAS" || word == "SAMX") 
        {
            counter++;
        }
    }

    return counter; 
}

int Vertical(List<List<char>> display, int j)
{
    var word = string.Empty;
    var counter = 0;

    for (var i = 0; i < display.Count; i++)
    {
        word = TheWord(display[i][j], word);

        if (word == "XMAS" || word == "SAMX") 
        {
            counter++;
        }
    }

    return counter;
}

int Diagonal(List<List<char>> display, int i, int j)
{
    var counter = 0;
    var wordbr = string.Empty;
    var wordbl = string.Empty;
    var wordtr = string.Empty;
    var wordtl = string.Empty;
    
    for (var k = 0; k < display[i].Count; k++)
    {
        if ((i + k) < display.Count && (j + k) < display[i].Count)
        {
            wordbr = TheWord(display[i + k][j + k], wordbr);
            wordbl = TheWord(display[i + k][display.Count - 1 - k], wordbl);

            if (wordbr == "XMAS" || wordbr == "SAMX")
            {
                counter++;
            }

            if (wordbl == "XMAS" || wordbl == "SAMX")
            {
                counter++;
            }
        }

        if ((i - k) >= 0 && (j + k) < display[i].Count)
        {
            wordtr = TheWord(display[i - k][j + k], wordtr);
            wordtl = TheWord(display[i - k][display.Count - 1 - k], wordtl);
            if (wordtr == "XMAS" || wordtr == "SAMX")
            {
                counter++;
            }

            if (wordtl == "XMAS" || wordtl == "SAMX")
            {
                counter++;
            }
        }
    }

    return counter;
}

string TheWord(char value, string xmas)
{
    if (xmas.Length < 4) 
    {
        return xmas + value;
    }

    return xmas.Substring(1) + value;
}