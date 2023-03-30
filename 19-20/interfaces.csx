// personne peut avoir plusieurs traits, skills
// Flingueur, Sniper, épéitse, soigneur

interface IEpeiste
{
    void Brandir();

    int PuissanceEpee { get; set; }
}

interface ISoigneur
{
    void Soigner();
}

interface IFlingueur
{
    void Tirer();
}

class Paladin : IEpeiste, ISoigneur
{
    public void Brandir()
    {
        Console.WriteLine("Je sors mon épée de lumière");
    }

    public void Soigner()
    {
        Console.WriteLine("Je suis en train de healer");
    }

    public int PuissanceEpee { get; set; }
}


// Je ne peux pas instantier un interface
//var a = new IEpeiste(); -> erreur

Paladin pal = new Paladin();
pal.Brandir();
Console.WriteLine(pal.PuissanceEpee);
IEpeiste epeiste = pal;
ISoigneur soigneur = pal;

// créer une classe CowBoyMystique qui implémente les 
// interfaces IFlingueur et ISoigneur

class CowBoyMystique : IFlingueur, ISoigneur
{
    public void Soigner()
    {
        Console.WriteLine("Je suis en train de healer");
    }

    public void Tirer()
    {
        Console.WriteLine("BANG BANG");
    }
}
CowBoyMystique boyMystique = new CowBoyMystique();

List<ISoigneur> soigneurs = new List<ISoigneur> { boyMystique, pal };
foreach (var s in soigneurs)
{
    s.Soigner();
}

void UtiliserPistolet(IFlingueur flingueur)
{
    flingueur.Tirer();
}

UtiliserPistolet(boyMystique);
// UtiliserPistolet(pal); -> erreur

// is
bool isInt = 8 is int;
Console.WriteLine(isInt);

// class CowBoyMystique : IFlingueur, ISoigneur
// class Paladin : IEpeiste, ISoigneur
void AppliquerSoins(ISoigneur soigneur)
{
    Console.WriteLine($"est ISoigneur: {soigneur is ISoigneur}");
    Console.WriteLine($"est CowBoyMystique: {soigneur is CowBoyMystique}");
    Console.WriteLine($"est Paladin: {soigneur is Paladin}");
    Console.WriteLine($"est IFlingueur: {soigneur is IFlingueur}");
    if (soigneur is CowBoyMystique)
    {
        CowBoyMystique c = (CowBoyMystique)soigneur;
        c.Tirer();
    }
    else
    {
        Console.WriteLine("Peux pas tirer :/ sniff sniff");
    }
}

Console.WriteLine("CowBoyMystique ->");
AppliquerSoins(boyMystique);
Console.WriteLine("Paladin ->");
AppliquerSoins(pal);

