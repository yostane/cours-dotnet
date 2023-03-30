# Exerices async + api async

## Exo 1

1. Créer un programme qui créé une tâche asyncrone qui génère des nombres aléatoires entre 0 et 20. Cette tâche se termine une fois qu'elle a généré une valeur inférieure à 10.
1. Créer une deuxième tache qui fait le même traitement que la première. Exécuter ces deux tâches en cocurrence.
1. Afficher la somme des deux derniers nombre générés par chacune des tâches.

## exo 2

Créer un projet console avec dotnet cli qui permet d'enregistrer dans un fichier appelé "facts.html" la réponse de [https://www.chucknorrisfacts.fr/facts/alea](https://www.chucknorrisfacts.fr/facts/alea).

Ouvir ce fichier dans un navigateur, que se passe t'il ?

Pour vous aider:

- [Fair des requêtes web avec HTTP Client](https://docs.microsoft.com/fr-fr/dotnet/csharp/tutorials/console-webapiclient#making-web-requests)
- [How to write to a text file (C# Programming Guide)](https://docs.microsoft.com/fr-fr/dotnet/csharp/programming-guide/file-system/how-to-write-to-a-text-file)

## exo 3

Créer un projet console dotnet qui liste le contenu du dossier passé en arugument de ligne de commande.

Modifier le programme de sorte à lister le contenu du dossier dans une tâche asynchrone.

Liens utiles:

- [Directory.GetFiles Méthode](https://docs.microsoft.com/fr-fr/dotnet/api/system.io.directory.getfiles?view=netcore-3.1)
- [Pour passer des arguments avec le cli: dotnet run -- (arguments)](https://www.jerriepelser.com/blog/quick-tip-pass-arguments-to-app-using-dotnet-cli/)

## exo 4

Créer une projet console dotnet qui lance deux tâches asynchrones en concurrence et définit une variable x commune aux deux tâches.

Chacune des tâches lance une boucle for qui itère 100 fois.
La première tâche incrémente x à chaque itération tandis que la deuxième le decrémente à chaque irétarion.

Initialiser x à 0 et afficher sa valeur une fois que les deux tâches asynchrones sont terminées.

Executer le programme plusieurs fois. Que constatez-vous ?

## exo 5 (suite de l'exo 4)

Décrire la fonction `Parallel.For` ?

A votre avis combien vaudra `x` à la fin de ce code ?

Tester le code. Que constatez vous ?

```csharp
int x = 0;
Parallel.For(0, 50, (i, state) =>
{
    if (i >= 25)
    {
        x += 1;
    }
    else
    {
        x -= 1;
    }
});
```
