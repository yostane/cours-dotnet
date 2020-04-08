struct CD
{
    public CD(int capacite)
    {
        Capacite = capacite;
    }

    public int Capacite { get; set; }

    public void Tourner()
    {
        Console.WriteLine("Chargement...");
    }
}

class CDClass
{
    public int Capacite { get; set; }
}

Console.WriteLine($"struct -> Type valeur");
CD cd1;
cd1.Capacite = 700;
CD cd2 = cd1;

Console.WriteLine($"avant modification");
Console.WriteLine($"cd1 -> {cd1.Capacite} MB");
Console.WriteLine($"cd2 -> {cd2.Capacite} MB");

cd2.Capacite = 100;
Console.WriteLine($"Après modification");
Console.WriteLine($"cd1 -> {cd1.Capacite} MB");
Console.WriteLine($"cd2 -> {cd2.Capacite} MB");


Console.WriteLine($"class -> Type référence");
CDClass cdClass1 = new CDClass();
cdClass1.Capacite = 700;
CDClass cdClass2 = cdClass1;

Console.WriteLine($"avant modification");
Console.WriteLine($"cd1 -> {cdClass1.Capacite} MB");
Console.WriteLine($"cd2 -> {cdClass2.Capacite} MB");

cdClass2.Capacite = 100;
Console.WriteLine($"Après modification");
Console.WriteLine($"cd1 -> {cdClass1.Capacite} MB");
Console.WriteLine($"cd2 -> {cdClass2.Capacite} MB");

void ModifyValueType(CD cd)
{
    cd.Capacite = 2;
    Console.WriteLine($"Inside {cd.Capacite}");
}

void ModifyReferenceType(CDClass cd)
{
    cd.Capacite = 5;
    Console.WriteLine($"Inside {cd.Capacite}");
}

Console.WriteLine($"Before {cd1.Capacite}");
ModifyValueType(cd1);
Console.WriteLine($"Outside {cd1.Capacite}");

Console.WriteLine($"Before {cdClass1.Capacite}");
ModifyReferenceType(cdClass1);
Console.WriteLine($"Outside {cdClass1.Capacite}");

void Modify(int x)
{
    x = 5;
}

void ModifyRef(ref int x)
{
    x = 5;
}

int y = 10;
Modify(y);
Console.WriteLine($"y => {y}");

ModifyRef(ref y);
Console.WriteLine($"y => {y}");
