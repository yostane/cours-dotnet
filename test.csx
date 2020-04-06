int getNbDigits(int input)
{
    int k = 0;
    for (k = 0; input > 0; k++)
    {
        input /= 10;
    }
    return k == 0 ? 1 : k;
}

int getDigitAtIndex(int input, int index)
{
    int originalIndex = index;
    int lastIndex = getNbDigits(input) - 1;
    index = lastIndex - index; // pour aller de g à d

    if (index < 0 || index > lastIndex)
    {
        throw new IndexOutOfRangeException($"Indice {originalIndex} incorrect!");
    }

    for (int i = 0; input > 0 && i < index; i++)
    {
        input /= 10;
    }
    return input % 10;
}

int getDigitAtIndexSyska(int input, int index)
{
    int originalIndex = index;
    int lastIndex = getNbDigits(input) - 1;
    index = lastIndex - index; // pour aller de g à d

    if (index < 0 || index > lastIndex)
    {
        throw new IndexOutOfRangeException($"Indice {originalIndex} incorrect!");
    }

    int div = input / (int)Math.Pow(10, index);
    return div % 10;
}
// Pow -> Power -> puissance
// 12313132 / 10^2 -> 123131 % 10 -> 1
// 12313132 / 10^5 -> 123 % 10 -> 3

int getDigitAtIndexDroiteAGauche(int input, int index)
{
    int k = 0;
    for (k = 0; input > 0 && k < index; k++)
    {
        input /= 10;
    }
    return input % 10;
}

const int value = 59874;
Console.WriteLine(getDigitAtIndex(value, 0)); // dàg: 4. gàd: 5
Console.WriteLine(getDigitAtIndex(value, 1)); // dàg: 7. gàd: 9
Console.WriteLine(getDigitAtIndex(value, 2)); // dàg: 8. gàd: 8
Console.WriteLine(getDigitAtIndex(value, 3)); // dàg: 9. gàd: 7
Console.WriteLine(getDigitAtIndex(value, 4)); // dàg: 5. gàd: 4

Console.WriteLine(getDigitAtIndexSyska(value, 0)); // dàg: 4. gàd: 5
Console.WriteLine(getDigitAtIndexSyska(value, 1)); // dàg: 7. gàd: 9
Console.WriteLine(getDigitAtIndexSyska(value, 2)); // dàg: 8. gàd: 8
Console.WriteLine(getDigitAtIndexSyska(value, 3)); // dàg: 9. gàd: 7
Console.WriteLine(getDigitAtIndexSyska(value, 4)); // dàg: 5. gàd: 4