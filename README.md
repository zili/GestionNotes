# GestionNotes

Application console C# (.NET 8) de gestion des notes pour 4 étudiants, illustrant les bases de la POO.

## Fonctionnalités
- Saisie des noms des 4 étudiants
- Saisie d'un nombre illimité de notes par étudiant (entre 0 et 20, ligne vide pour terminer ; `12,5` et `12.5` acceptés)
- Calcul de la moyenne
- Classement (ex æquo = même rang, ex. 1, 2, 2, 4) et affichage ordonné
- Les étudiants sans note ne sont pas classés et apparaissent en fin de liste

## Structure
| Fichier | Rôle |
|---|---|
| `Etudiant.cs` | Nom, notes (encapsulées), moyenne, rang |
| `Classe.cs` | Ensemble des étudiants et calcul du classement |
| `Program.cs` | Saisies et affichage console |

## Exécution
```bash
dotnet run
```
