abstract class YuGiOhCard
{
    public YuGiOhCard(string name, string description, int rank, bool isHidden)
    {
        this.Name = name;
        this.Description = description;
        this.Rank = rank;
        this.IsHidden = isHidden;
    }

    // 1 - créer une variable privée du avec _ en préfixe (backing field)
    private string _Name;
    // 2- définir une propriété publique avec des acccesseurs
    public string Name
    {
        get
        {
            Console.WriteLine("lecture");
            return _Name;
        }
        set
        {
            Console.WriteLine($"ecriture {value}");
            _Name = value;
        }
    }

    private string _Description;
    // synthetiser _Description
    public string Description
    {
        get { return this._Description; }
        set { this._Description = value; }
    }

    public int Rank { get; set; }
    public bool IsHidden { get; set; }
}

class MagicCard : YuGiOhCard
{

    public MagicCard(string effect, string name, string description, int rank, bool isHidden) : base(name, description, rank, isHidden)
    {
        this.Effect = effect;
    }
    public string Effect { get; set; }
}

class AttackCard : YuGiOhCard
{
    public AttackCard(int attack, bool isDefense, string name, string description, int rank, bool isHidden) : base(name, description, rank, isHidden)
    {
        this.Attack = attack;
        this.IsDefense = isDefense;
    }
    public int Attack { get; set; }
    public bool IsDefense { get; set; }
}

AttackCard card = new AttackCard(10000, true, "Exodia", "Dragon aux yeux bleu", 10, false);
string name = card.Name;
Console.WriteLine($"name => {name}");
Console.WriteLine(card.Description);
Console.WriteLine(card.Rank);

MagicCard magicCard = new MagicCard("papillon", "carte magique", "fourchette", 4, true);
Console.WriteLine(magicCard.Name);