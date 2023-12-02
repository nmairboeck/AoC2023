
var lines = await File.ReadAllLinesAsync("Input.txt");

const int maxRed = 12;
const int maxGreen = 13;
const int maxBlue = 14;

int possibleSum = 0;

int powerSum = 0;

for (int i = 0; i < lines.Length; i++)
{
    var line = lines[i];
    var gamesData = line[(line.IndexOf(':') + 1)..];
    var games = gamesData.Split(new char[] { ';', ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
    if (IsGamePossible(games))
    {
        possibleSum += i + 1;
    }

    powerSum += GetPower(games);
}

bool IsGamePossible(string[] games)
{
    for (int j = 0; j < games.Length - 1; j += 2)
    {
        var count = int.Parse(games[j]);
        switch (games[j + 1])
        {
            case "red":
                if (count > maxRed)
                {
                    return false;
                }
                break;
            case "blue":
                if (count > maxBlue)
                {
                    return false;
                }
                break;
            case "green":
                if (count > maxGreen)
                {
                    return false;
                }
                break;
        }
    }
    return true;
}

int GetPower(string[] games)
{
    var maxRed = 0;
    var maxGreen = 0;
    var maxBlue = 0;

    for (int j = 0; j < games.Length - 1; j += 2)
    {
        var count = int.Parse(games[j]);
        switch (games[j + 1])
        {
            case "red":
                if (count > maxRed)
                {
                    maxRed = count;
                }
                break;
            case "blue":
                if (count > maxBlue)
                {
                    maxBlue = count;
                }
                break;
            case "green":
                if (count > maxGreen)
                {
                    maxGreen = count;
                }
                break;
        }
    }
    return maxRed * maxBlue * maxGreen;
}

Console.WriteLine($"The sum of possible games is : {possibleSum}");

Console.WriteLine($"The power sum is {powerSum}");
