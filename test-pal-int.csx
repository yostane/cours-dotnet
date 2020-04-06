int GetNbDigits(int input)
{
    int k = 0;
    for (k = 0; input > 0; k++)
    {
        input /= 10;
    }
    return k == 0 ? 1 : k;
}

int GetDigitAtIndex(int input, int index)
{
    int originalIndex = index;
    int lastIndex = GetNbDigits(input) - 1;
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

int GetDigitAtIndexSyska(int input, int index)
{
    int originalIndex = index;
    int lastIndex = GetNbDigits(input) - 1;
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

int GetDigitAtIndexDroiteAGauche(int input, int index)
{
    int k = 0;
    for (k = 0; input > 0 && k < index; k++)
    {
        input /= 10;
    }
    return input % 10;
}

const int value = 59874;
Console.WriteLine(GetDigitAtIndex(value, 0)); // dàg: 4. gàd: 5
Console.WriteLine(GetDigitAtIndex(value, 1)); // dàg: 7. gàd: 9
Console.WriteLine(GetDigitAtIndex(value, 2)); // dàg: 8. gàd: 8
Console.WriteLine(GetDigitAtIndex(value, 3)); // dàg: 9. gàd: 7
Console.WriteLine(GetDigitAtIndex(value, 4)); // dàg: 5. gàd: 4

Console.WriteLine(GetDigitAtIndexSyska(value, 0)); // dàg: 4. gàd: 5
Console.WriteLine(GetDigitAtIndexSyska(value, 1)); // dàg: 7. gàd: 9
Console.WriteLine(GetDigitAtIndexSyska(value, 2)); // dàg: 8. gàd: 8
Console.WriteLine(GetDigitAtIndexSyska(value, 3)); // dàg: 9. gàd: 7
Console.WriteLine(GetDigitAtIndexSyska(value, 4)); // dàg: 5. gàd: 4