using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace AoC._2023._1.Benchmarks;

internal static class Program
{
    private static void Main()
    {
        _ = BenchmarkRunner.Run<Day1Benchmark>();
    }
}

[MemoryDiagnoser]
public class Day1Benchmark
{
    private readonly string[] _input;
    private readonly string[] _numberNames =
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

    public Day1Benchmark()
    {
        _input = File.ReadAllLinesAsync("Input.txt").Result;
    }

    [Benchmark]
    public int Part1()
    {
        var result = 0;
        foreach (var line in _input)
        {
            result += (Part1GetFirstDigit(line) * 10) + Part1GetLastDigit(line);
        }

        return result;
    }

    private int Part1GetFirstDigit(string line)
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

    private int Part1GetLastDigit(string line)
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

    [Benchmark]
    public int Part2()
    {
        var result = 0;
        foreach (var line in _input)
        {
            result += (Part2GetFirstDigit(line) * 10) + Part2GetLastDigit(line);
        }

        return result;
    }

    private int Part2GetFirstDigit(string line)
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
                for (var i = 1; i < _numberNames.Length; i++)
                {
                    if (part.StartsWith(_numberNames[i]))
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

    private int Part2GetLastDigit(string line)
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
                for (var i = 1; i < _numberNames.Length; i++)
                {
                    if (part.EndsWith(_numberNames[i]))
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
}
