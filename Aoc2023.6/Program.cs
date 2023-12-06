using System.Diagnostics;

var lines = await File.ReadAllLinesAsync("Input.txt");

var sw = new Stopwatch();
sw.Start();

var times = lines[0]["Time:".Length..].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
var distances = lines[1]["Distance: ".Length..].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

var winningProducts = 1;
for (var i = 0; i < times.Length; i++)
{
    var winningcount = 0;

    for (var j = 0; j < times[i]; j++)
    {
        var speed = j;
        var distanceTraveled = (times[i] - j) * speed;
        if (distanceTraveled > distances[i])
        {
            winningcount++;
        }
    }
    winningProducts *= winningcount;
}

sw.Stop();

Console.WriteLine($"We have a total of {winningProducts} points. Took: {sw.Elapsed}");

sw.Reset();

sw.Start();
var part2Time = int.Parse(lines[0]["Time:".Length..].Replace(" ", ""));
var part2Distance = long.Parse(lines[1]["Distance: ".Length..].Replace(" ", ""));

var winningCount2 = 0;

for (long j = 0; j < part2Time; j++)
{
    if ((part2Time - j) * j > part2Distance)
    {
        winningCount2++;
    }
}

sw.Stop();

Console.WriteLine($"The count for part 2 is {winningCount2}. Took {sw.Elapsed}.");