
var lines = await File.ReadAllLinesAsync("Input.txt");

var partNumberSum = 0;

for (var i = 0; i < lines.Length; i++)
{
    var line = lines[i];

    var currentNumber = "";
    for (var j = 0; j < line.Length; j++)
    {
        if (char.IsDigit(line[j]))
        {
            currentNumber += line[j];
            //if we are at the end of the line, do the number check, otherwise continue until we hit a non digit
            if (j < line.Length - 1)
            {
                continue;
            }
        }

        if (currentNumber.Length == 0)
        {
            continue;
        }

        var number = int.Parse(currentNumber);

        var start = Math.Max(j - currentNumber.Length - 1, 0);
        var end = Math.Min(j, line.Length - 1);

        var surroundingChars = new List<char>();

        if (i > 0)
        {
            var topLine = lines[i - 1][start..(end + 1)];
            surroundingChars.AddRange(topLine);
        }
        if (i < line.Length - 1)
        {
            var bottomnLine = lines[i + 1][start..(end + 1)];
            surroundingChars.AddRange(bottomnLine);
        }
        //left char 
        surroundingChars.Add(line[start]);
        //right char 
        surroundingChars.Add(line[end]);

        if (surroundingChars.Any(c => c != '.' && !char.IsDigit(c)))
        {
            partNumberSum += number;
        }
        currentNumber = "";
    }
}

Console.WriteLine($"The part number sum is {partNumberSum}");

//part 2
var gearRatioSum = 0;

for (var i = 0; i < lines.Length; i++)
{
    var line = lines[i];
    for (var j = 0; j < line.Length; j++)
    {
        if (line[j] != '*')
        {
            continue;
        }

        List<int> numbers = [];

        var from = j - 1;
        var to = j + 1;

        if (i > 0)
        {
            var topLine = lines[i - 1];
            GetSurroundingNumbers(topLine, from, to, numbers);
        }
        GetSurroundingNumbers(line, from, to, numbers);
        if (i < lines.Length - 1)
        {
            var bottomLine = lines[i + 1];
            GetSurroundingNumbers(bottomLine, from, to, numbers);
        }

        if (numbers.Count == 2)
        {
            gearRatioSum += numbers[0] * numbers[1];
        }
    }
}

void GetSurroundingNumbers(string line, int from, int to, List<int> foundNumers)
{
    var index = from;
    // go to left to find first number, if it starts further left
    while (index > 0 && char.IsDigit(line[index]))
    {
        index--;
    }
    //go right to find start of number and skip other symbols
    while (index < line.Length && !char.IsDigit(line[index]))
    {
        index++;
    }

    var numberString = "";
    //start reading the number
    while (index <= to)
    {
        if (!char.IsDigit(line[index]))
        {
            if (numberString.Length > 0)
            {
                foundNumers.Add(int.Parse(numberString));
            }
            numberString = "";
            index++;
            continue;
        }

        numberString += line[index];
        index++;
    }

    //we are at max index and not currently have a number, return
    if (numberString.Length == 0)
    {
        return;
    }

    //get the rest of the number
    while (index < line.Length && char.IsDigit(line[index]))
    {
        numberString += line[index];
        index++;
    }

    if (numberString.Length > 0)
    {
        foundNumers.Add(int.Parse(numberString));
    }
}

Console.WriteLine($"The sum of gear ratios is {gearRatioSum}");