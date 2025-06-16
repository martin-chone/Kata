# 🧠 Kata : Mastermind

## 📋 Objectif

Implémenter la logique du jeu **Mastermind**, en simulant le rôle du *code maker* :  
Répondre à une combinaison proposée par un joueur en indiquant :

- Le nombre de **couleurs bien placées** (bonne couleur à la bonne position)
- Le nombre de **couleurs mal placées** (bonne couleur à la mauvaise position)

## 🔗 Énoncé

> À partir d’une combinaison secrète (ex. : `["blue", "red", "green"]`) et d’une proposition (ex. : `["red", "blue", "green"]`),  
> le système doit retourner un résultat du type : `1 bien placé, 2 mal placés`.

[Énoncé sur codingdojo.org](https://codingdojo.org/kata/Mastermind)

## 🧠 Approche adoptée

Développement progressif en TDD, en commençant par la détection des **bien placés**, puis des **mal placés**.

Bonus -> Ajout d'une contrainte : éviter les surcomptes (doublons gérés proprement) [A préciser...].

## ✅ Exemple(s) de test

| Secret                        | Guess                          | Résultat attendu         |
|------------------------------|--------------------------------|--------------------------|
| `["blue"]`                   | `["blue"]`                     | `1 bien placé, 0 mal placé` |
| `["blue"]`                   | `["red"]`                      | `0 bien placé, 0 mal placé` |
| `["red", "yellow"]`          | `["blue", "red"]`              | `0 bien placé, 1 mal placé` |
| `["blue", "red", "green", "pink"]` | `["yellow", "red", "blue", "purple"]` | `1 bien placé, 1 mal placé` |

## 🧪 Tests

Développé en **TDD** avec la librairie **xUnit**.

## 🧰 Technologies

- C# (.NET 6+)
- xUnit
