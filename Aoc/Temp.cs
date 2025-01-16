public class Temp
{
    public void Execute()
    {
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

        int Horizontal(List<List<char>> display, int i)
        {
            var forward = new int[4];
            var backward = new int[4];

            for (var j = 0; j < display[i].Count; j++)
            {
                UpdateCounts(display[i][j], forward, backward);
            }

            return forward[3] + backward[3];
        }

        int Vertical(List<List<char>> display, int j)
        {
            var forward = new int[4];
            var backward = new int[4];

            for (var i = 0; i < display.Count; i++)
            {
                UpdateCounts(display[i][j], forward, backward);
            }

            return forward[3] + backward[3];
        }

        int Diagonal(List<List<char>> display, int i, int j)
        {
            var forward1 = new int[4];
            var backward1 = new int[4];
            var forward2 = new int[4];
            var backward2 = new int[4];
            var forward3 = new int[4];
            var backward3 = new int[4];
            var forward = new int[4];
            var backward = new int[4];

            for (var k = 0; k < display[i].Count; k++)
            {
                if ((i + k) < display.Count && (j + k) < display[i].Count)
                {
                    UpdateCounts(display[i + k][j + k], forward, backward);
                    UpdateCounts(display[i + k][display.Count - 1 - k], forward2, backward2);
                }

                if ((i - k) > 0 && (j + k) < display[i].Count)
                {
                    UpdateCounts(display[i - k][j + k], forward1, backward1);
                    UpdateCounts(display[i - k][display.Count - 1 - k], forward3, backward3);
                }
            }

            return forward[3] + backward[3] + forward1[3] + backward1[3] + forward2[3] + backward2[3] + forward3[3] + backward3[3];
        }

        void UpdateCounts(char value, int[] forward, int[] backward)
        {
            switch (value)
            {
                case 'X':
                    forward[0]++;
                    if (backward[3] < backward[2])
                    {
                        backward[3]++;
                    }
                    break;
                case 'M':
                    if (forward[1] < forward[0])
                    {
                        forward[1]++;
                    }
                    if (backward[2] < backward[1])
                    {
                        backward[2]++;
                    }
                    break;
                case 'A':
                    if (forward[2] < forward[1])
                    {
                        forward[2]++;
                    }
                    if (backward[1] < backward[0])
                    {
                        backward[1]++;
                    }
                    break;
                case 'S':
                    if (forward[3] < forward[2])
                    {
                        forward[3]++;
                    }
                    backward[0]++;
                    break;
                default:
                    return;
            }
        }
    }
}