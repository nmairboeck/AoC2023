using System.Diagnostics;

var lines = await File.ReadAllLinesAsync("Input.txt");

var sw = new Stopwatch();
sw.Start();

var times = lines[0]["Time:".Length..].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
var distances = lines[1]["Distance: ".Length..].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

var winningProducts = 1;
for (var i = 0; i < times.Length; i++)
{
    var firstWinner = 0;
    var lastWinner = 0;
    for (var j = 0; j < times[i]; j++)
    {
        if ((times[i] - j) * j > distances[i])
        {
            firstWinner = j;
            break;
        }
    }
    for (var j = times[i] - 1; j >= 0; j--)
    {
        if ((times[i] - j) * j > distances[i])
        {
            lastWinner = j;
            break;
        }
    }

    winningProducts *= lastWinner - firstWinner + 1;
}

sw.Stop();

Console.WriteLine($"We have a total of {winningProducts} points. Took: {sw.Elapsed}");

sw.Reset();

sw.Start();
var part2Time = int.Parse(lines[0]["Time:".Length..].Replace(" ", ""));
var part2Distance = long.Parse(lines[1]["Distance: ".Length..].Replace(" ", ""));


var firstWinner2 = 0L;
var lastWinner2 = 0L;

for (long j = 0; j < part2Time; j++)
{
    if ((part2Time - j) * j > part2Distance)
    {
        firstWinner2 = j;
        break;
    }
}
for (long j = part2Time - 1; j >= 0; j--)
{
    if ((part2Time - j) * j > part2Distance)
    {
        lastWinner2 = j;
        break;
    }
}
var winningCount2 = lastWinner2 - firstWinner2 + 1;

sw.Stop();

Console.WriteLine($"The count for part 2 is {winningCount2}. Took {sw.Elapsed}.");