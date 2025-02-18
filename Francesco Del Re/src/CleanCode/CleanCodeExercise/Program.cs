using CleanCodeExercise.DuplicateCode;
using CleanCodeExercise.ExceptionHandling;
using CleanCodeExercise.NamingConvention;

// Esercizio 1: Nomenclatura e chiarezza
var badExample = new BadNamingExample();
badExample.ProcessOrder("12345", 5);

// Esercizio 1 - Correzione
var goodExample = new GoodNamingExample();
goodExample.ProcessCustomerOrder("12345", 5);

// Esercizio 2: Eliminazione di codice duplicato
var duplicateExample = new DuplicateCodeExample();
duplicateExample.ProcessData();

// Esercizio 2 - Correzione
var refactoredExample = new RefactoredCodeExample();
refactoredExample.ProcessData();

// Esercizio 3: Gestione delle eccezioni
var exceptionExample = new ExceptionHandlingExample();
exceptionExample.ReadFile("file.txt");

// Esercizio 3 - Correzione
var improvedExample = new ImprovedExceptionHandlingExample();
improvedExample.ReadFile("file.txt");
