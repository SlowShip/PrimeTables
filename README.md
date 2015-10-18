# Prime Multiplication Table Generator

## Intro:

### Assumptions:
* Since I'm doing this over the weekend I've have no way of checking requirements with anyone, but the spec says "outputs a multiplication table of the **first *10* prime numbers.**"  
I'm assuming the 10 is a typo and should read ***n* prime numbers**
* I'm assuming the system needs to maintain a decent user experience, and so I am rejecting very large requests that take ages to respond. This is easy to turn off if not required.

### How to Run:
*Todo*

### What I'm pleased with:
*Todo*

### What I would do with it if you had more time:
*Todo*

## Work

### Tasks:

* ~~**Repository set-up + initial commit**~~
* ~~**Create site + basic structure**~~
  * ~~Basic Asp.Net app~~
  * ~~Folders for unit tests~~
  * ~~Dependency Injection framework~~
* ~~**Create basic interfaces for task**~~  
  * ~~IPrimeMultiplicationTableViewModelFactory~~ (Decided upon a more generic MultiplicationTableViewModelFactory)   
  * ~~IMultiplicationTableCalculator~~   
  * ~~ISequenceGenerator~~ (Decided upon a more generic CreateSequence(int length) as get next felt to tied to assumed prime generation implementation)
* ~~**Create page wire frame**~~
* ~~**Take input from user**~~
* ~~**Display table of specified size** (handle large tables)~~
  * ~~Create TestMultiplicationTableCalculator and just returns 0's in an int[][]~~
  * ~~Bear in mind tables could be *very* large~~
* **Implement Multiplication of sequence + plugin**
* **Implement PrimeNumberSequenceGenerator + plugin**
* **Update Readme.md**
* **Look into optimising**
  * `n*m == m*n` so only generate half the table
