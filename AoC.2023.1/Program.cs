
using System.Diagnostics;

//write welcome message
Console.WriteLine("Advent of Code 2023.1");

var input = await ReadInput();

Stopwatch sw = new();
sw.Start();
var part1 = Part1(input);
sw.Stop();

Console.WriteLine($"Part 1: {part1}. Calculation took: {sw.Elapsed}");

sw.Reset();

string[] numberNames =
[
    "",
    "one",
    "two",
    "three",
    "four",
    "five",
    "six",
    "seven",
    "eight",
    "nine"
];

sw.Start();

var part2 = Part2(input);

sw.Stop();

Console.WriteLine($"Part 2: {part2}. Calculation took: {sw.Elapsed}");

Console.WriteLine("Done");

async Task<string[]> ReadInput()
{
    return await File.ReadAllLinesAsync("Input.txt");
}

int Part1(string[] input)
{
    var result = 0;
    foreach (var line in input)
    {
        result += (Part1GetFirstDigit(line) * 10) + Part1GetLastDigit(line);
    }

    return result;
}

int Part1GetFirstDigit(string line)
{
    for (var i = 0; i < line.Length; i++)
    {
        if (char.IsDigit(line[i]))
        {
            return line[i] - 48;
        }
    }
    return -1;
}
int Part1GetLastDigit(string line)
{
    for (var i = line.Length - 1; i >= 0; i--)
    {
        if (char.IsDigit(line[i]))
        {
            return line[i] - 48;
        }
    }
    return -1;
}

int Part2(string[] input)
{
    var result = 0;
    foreach (var line in input)
    {
        result += (Part2GetFirstDigit(line) * 10) + Part2GetLastDigit(line);
    }

    return result;
}

int Part2GetFirstDigit(string line)
{
    var part = line.AsSpan();
    do
    {
        if (char.IsDigit(part[0]))
        {
            return part[0] - 48;
        }
        else
        {
            for (var i = 1; i < numberNames.Length; i++)
            {
                if (part.StartsWith(numberNames[i]))
                {
                    return i;
                }
            }
        }
        part = part[1..];
    }
    while (part.Length > 0);

    return -1;
}
int Part2GetLastDigit(string line)
{
    var part = line.AsSpan();
    do
    {
        if (char.IsDigit(part[^1]))
        {
            return part[^1] - 48;
        }
        else
        {
            for (var i = 1; i < numberNames.Length; i++)
            {
                if (part.EndsWith(numberNames[i]))
                {
                    return i;
                }
            }
        }
        part = part[..^1];
    }
    while (part.Length > 0);

    return -1;
}
