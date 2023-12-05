var lines = await File.ReadAllLinesAsync("Input.txt");

List<long> seeds = [];
var seedToSoil = new List<(long destStart, long srcStart, long range)>();
var soilToFertilizer = new List<(long destStart, long srcStart, long range)>();
var fertilizerToWater = new List<(long destStart, long srcStart, long range)>();
var waterToLight = new List<(long destStart, long srcStart, long range)>();
var lightToTemperator = new List<(long destStart, long srcStart, long range)>();
var tempeatorToHumidity = new List<(long destStart, long srcStart, long range)>();
var humidityToLocation = new List<(long destStart, long srcStart, long range)>();

List<(long destStart, long srcStart, long range)> currentMap = null;
for (var i = 0; i < lines.Length; i++)
{
    var line = lines[i];
    if (line.StartsWith("seeds: "))
    {
        seeds = line["seeds: ".Length..].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToList();
        continue;
    }

    if (line.StartsWith("seed-to-soil"))
    {
        currentMap = seedToSoil;
        continue;
    }
    else if (line.StartsWith("soil-to-fertilizer"))
    {
        currentMap = soilToFertilizer;
        continue;
    }
    else if (line.StartsWith("fertilizer-to-water"))
    {
        currentMap = fertilizerToWater;
        continue;
    }
    else if (line.StartsWith("water-to-light"))
    {
        currentMap = waterToLight;
        continue;
    }
    else if (line.StartsWith("light-to-temperature"))
    {
        currentMap = lightToTemperator;
        continue;
    }
    else if (line.StartsWith("temperature-to-humidity"))
    {
        currentMap = tempeatorToHumidity;
        continue;
    }
    else if (line.StartsWith("humidity-to-location"))
    {
        currentMap = humidityToLocation;
        continue;
    }

    while (!string.IsNullOrEmpty(line) && currentMap != null && i < lines.Length)
    {
        var numbers = line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
        if (numbers.Length == 3)
        {
            var destRangeStart = numbers[0];
            var srcRangeStart = numbers[1];
            var rangeCount = numbers[2];

            currentMap.Add((destRangeStart, srcRangeStart, rangeCount));
        }
        i++;
        line = lines[i];
    }
}

var minLocation = long.MaxValue;
foreach (var seed in seeds)
{
    var mapped = seed;

    var map = seedToSoil.FirstOrDefault(x => x.srcStart < mapped && mapped < x.srcStart + x.range);
    if (map != default)
    {
        mapped = mapped - map.srcStart + map.destStart;
    }
    map = soilToFertilizer.FirstOrDefault(x => x.srcStart < mapped && mapped < x.srcStart + x.range);
    if (map != default)
    {
        mapped = mapped - map.srcStart + map.destStart;
    }
    map = fertilizerToWater.FirstOrDefault(x => x.srcStart < mapped && mapped < x.srcStart + x.range);
    if (map != default)
    {
        mapped = mapped - map.srcStart + map.destStart;
    }
    map = waterToLight.FirstOrDefault(x => x.srcStart < mapped && mapped < x.srcStart + x.range);
    if (map != default)
    {
        mapped = mapped - map.srcStart + map.destStart;
    }
    map = lightToTemperator.FirstOrDefault(x => x.srcStart < mapped && mapped < x.srcStart + x.range);
    if (map != default)
    {
        mapped = mapped - map.srcStart + map.destStart;
    }
    map = tempeatorToHumidity.FirstOrDefault(x => x.srcStart < mapped && mapped < x.srcStart + x.range);
    if (map != default)
    {
        mapped = mapped - map.srcStart + map.destStart;
    }
    map = humidityToLocation.FirstOrDefault(x => x.srcStart < mapped && mapped < x.srcStart + x.range);
    if (map != default)
    {
        mapped = mapped - map.srcStart + map.destStart;
    }

    if (mapped < minLocation)
    {
        minLocation = mapped;
    }
}

Console.WriteLine($"The minimum location is {minLocation}");
