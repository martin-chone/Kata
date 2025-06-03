# 🧪 Kata : FizzBuzz

## 📋 Objectif

FizzBuzz est un jeu de chiffres simple dans lequel vous comptez, mais remplacez certains numéros par les mots « Fizz » et/ou « Buzz », en respectant certaines règles.

## 🔗 Énoncé

Commencer par créer un convertisseur qui imprime les chiffres de 1 à 200.
- Au lieu de nombres divisibles par 3, la méthode devrait produire « Fizz ».
- Au lieu de nombres divisibles par 5, la méthode devrait produire « Buzz ».
- Au lieu de nombres divisibles par 3 et 5, la méthode devrait afficher « FizzBuzz ».

Puis passer à la nouvelle exigence : 
- Au lieu de nombres divisibles par 3 ou qui contient 3, la méthode devrait produire « Fizz ».
- Au lieu de nombres divisibles par 5 ou qui contient 5, la méthode devrait produire « Buzz ».

## 🧠 Approche adoptée

Approche simple et itérative, en partant des cas les plus simples vers les combinaisons. Chaque règle a été introduite progressivement via des tests.

## ✅ Exemple(s) de test

- 1 → "1"
- 2 → "2"

- 3 → "Fizz" (Divisibles par 3 et contient un 3)
- 6 → "Fizz" (Divisibles par 3)
- 9 → "Fizz" (Divisibles par 3)

- 5 → "Buzz" (Divisibles par 5 et contient un 5)
- 10 → "Buzz" (Divisibles par 5)
- 20 → "Buzz" (Divisibles par 5)

- 60 → "FizzBuzz" (Divisibles par 3 et 5)
- 90 → "FizzBuzz" (Divisibles par 3 et 5)

- 43 → "Fizz" (Contient un 3)
- 52 → "Buzz" (Contient un 5)

- 15 → "FizzBuzz" (Divisibles par 3, divisibles par 5 et contient un 5)
- 135 → "FizzBuzz" (Divisibles par 3, divisibles par 5, contient un 3 et contient un 5)

## 🧪 Tests

Développé en TDD avec **xUnit**.

## 🧰 Technologies

- C# (.NET 6+)
- xUnit
