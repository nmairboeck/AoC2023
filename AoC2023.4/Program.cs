

using System.Diagnostics;

var lines = await File.ReadAllLinesAsync("Input.txt");


var cards = lines
    .Select(l => l[(l.IndexOf(':') + 2)..].Split('|', StringSplitOptions.RemoveEmptyEntries).Select(x => x.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray()).ToArray())
    .ToList();

var stopwatch = new Stopwatch();

stopwatch.Start();
var sumPoints = 0;
foreach (var card in cards)
{
    sumPoints += CalculateWinningPoints(card);
}
static int CalculateWinningPoints(int[][] card)
{
    var winningNumbers = card[0];
    var havingNumbers = card[1];

    var winningCount = havingNumbers.Count(n => winningNumbers.Contains(n));

    return (int)Math.Pow(2, winningCount - 1); //pow -1 is 0.5, cast to int is 0    
}

stopwatch.Stop();
Console.WriteLine($"The sum of points is: {sumPoints}. Part 1 took {stopwatch.Elapsed}.");

stopwatch.Reset();
stopwatch.Start();

var sumCards = 0;
Dictionary<int, int> winningCountsPerCard = [];

for (var i = 0; i < cards.Count; i++)
{
    sumCards += CalculateWinningPointsRecursive(cards, i, winningCountsPerCard);
}


static int CalculateWinningPointsRecursive(List<int[][]> cards, int start, Dictionary<int, int> winningCountsPerCard)
{
    var sum = 0;
    sum++;
    var card = cards[start];
    var winningNumbers = card[0];
    var havingNumbers = card[1];

    if (!winningCountsPerCard.TryGetValue(start, out var winningCount))
    {
        winningCount = havingNumbers.Count(winningNumbers.Contains);
        winningCountsPerCard[start] = winningCount;
    }

    for (var j = 1; j <= winningCount; j++)
    {
        sum += CalculateWinningPointsRecursive(cards, start + j, winningCountsPerCard);
    }


    return sum;
}

stopwatch.Stop();
Console.WriteLine($"The sum of total cards is {sumCards}. Part 2 took {stopwatch.Elapsed}");