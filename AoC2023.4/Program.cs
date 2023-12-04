

var lines = await File.ReadAllLinesAsync("Input.txt");

var cards = lines.Select(l => l.Substring(l.IndexOf(':') + 2).Split('|', StringSplitOptions.RemoveEmptyEntries)).ToList();

var sumPoints = 0;
foreach (var card in cards)
{
    sumPoints += CalculateWinningPoints(card);
}
static int CalculateWinningPoints(string[] card)
{
    var winningNumbers = card[0].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
    var havingNumbers = card[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

    var winningCount = havingNumbers.Where(n => winningNumbers.Contains(n)).Count();

    return (int)Math.Pow(2, winningCount - 1); //pow -1 is 0.5, cast to int is 0    
}


Console.WriteLine($"The sum of points is: {sumPoints}");

var pointsPart2 = 0;
