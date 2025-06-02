# 🧪 Kata : FizzBuzz

## 📋 Objectif

FizzBuzz est un jeu de chiffres simple dans lequel vous comptez, mais remplacez certains numéros par les mots « Fizz » et/ou « Buzz », en respectant certaines règles.

## 🔗 Énoncé

Créez un convertisseur qui imprime les chiffres de 1 à 100, séparés par des sauts de ligne.
- Au lieu de nombres divisibles par 3, la méthode devrait produire « Fizz ».
- Au lieu de nombres divisibles par 5, la méthode devrait produire « Buzz ».
- Au lieu de nombres divisibles par 3 et 5, la méthode devrait afficher « FizzBuzz ».

Il y a une étape suivante : 
- Au lieu de chiffres contenant un trois, imprimez « Fizz ».
- Au lieu de chiffres avec un cinq, imprimez « Buzz ».
- Au lieu de chiffres contenant un trois et un cinq, imprimez « FizzBuzz ».

## 🧠 Approche adoptée

Approche simple et itérative, en partant des cas les plus simples vers les combinaisons. Chaque règle a été introduite progressivement via des tests.

## ✅ Exemple(s) de test

- 1 → "1"
- 3 → "FizzFizz" (Divisibles par 3 et contient un 3)
- 5 → "BuzzBuzz" (Divisibles par 5 et contient un 5)
- 15 → "FizzBuzzBuzz" (Divisibles par 3, divisibles par 5 et contient un 5)

## 🧪 Tests

Développé en TDD avec **xUnit**.

## 🧰 Technologies

- C# (.NET 6+)
- xUnit
