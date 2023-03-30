enum Meteo { Pluie, Neige, Soleil, Nuages, Tempete, Drache, Vent }

enum CategorieAge { Bebe, Adolescent, Adulte, Vieux }

Meteo etatDuJour = Meteo.Soleil;

CategorieAge categorieAge = CategorieAge.Adulte;

switch (categorieAge)
{
    case CategorieAge.Adolescent:
        break;
    case CategorieAge.Adulte:
        break;
    case CategorieAge.Bebe:
        break;
    case CategorieAge.Vieux:
        break;
}

switch (categorieAge)
{
    case CategorieAge.Adolescent:
        break;
    case CategorieAge.Adulte:
        break;
    default:
        break;
}
