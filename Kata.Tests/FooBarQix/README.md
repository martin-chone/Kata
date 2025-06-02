# 🧪 Kata : FooBarQix

## 📋 Objectif

Transformer un nombre selon des règles basées sur ses diviseurs et ses chiffres.

## 🔗 Énoncé

[Énoncé sur codingdojo.org](https://codingdojo.org/kata/FooBarQix)

## 🧠 Approche adoptée

Les règles sont intégrées progressivement avec des tests spécifiques pour chaque règle :
- Divisible par 3 → "Foo", 5 → "Bar", 7 → "Qix"
- Contient 3 → "Foo", 5 → "Bar", 7 → "Qix"

Règle bonus : 
- Chaque 0 doit être remplacé par un caractère "*"

## ✅ Exemple(s) de test

- 3 → "FooFoo"
- 5 → "BarBar"
- 15 → "FooBarBar"

## 🧪 Tests

Développé en TDD avec **xUnit**.

## 🧰 Technologies

- C# (.NET 6+)
- xUnit