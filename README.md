# Prime Multiplication Table Generator

## Intro:

### Assumptions:
* Since I'm doing this over the weekend I've have no way of checking requirements with anyone, but the spec says "outputs a multiplication table of the **first *10* prime numbers.**"  
I'm assuming the 10 is a typo and should read ***n* prime numbers**
* I'm assuming the system needs to maintain a decent user experience, and so I am rejecting very large requests that take ages to respond. This is easy to turn off if not required.

### How to Run:
The app is just a simple MVC app, if you have Visual Studio installed you should just be able to download and run it dirrectly. 
You will need the NUnit test runner to run the unit tests.

Alternatively you can find a deployed version [here](http://prime-tables.azurewebsites.net/?TableSize=5)  

### What I'm pleased with:
* I'm quite happy with how the independently the `IMultiplicationTableCalculator's` and `ISequenceGenerator's` opperate. It's actually really easy to plugin a different sequence type (as you can see with the `NaturalsSequenceGenerator` I've implemented).

### What I would do with it if you had more time:
* I not happy with the validation I've added. I put it there to avoid large numbers throwing out of memory exceptions, but I could have found a better way to prevent this.
* I'm also not very happy with the way I implemented the validation, it was a little rushed and I think I can do better.
* I would like to expose the view models through an Api, then implement a client app using JavaScript that doesn't load the larger values off the page until the user tries to view them which I think would have been a much better experience.    
* The app could really easily be converted to return multiplication tables of different sequences, all you need to do is pass a parameter to the controller action and get it to pass it along to the factory. I would like to have a play around with this and see what I can make it do.
* I've hacked the DI a little in `MultiplicationTableViewModelFactoryInstaller`. I would have liked to clear this up.
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
* ~~**Implement Multiplication of sequence + plugin**~~
* ~~**Implement PrimeNumberSequenceGenerator + plugin**~~
* ~~**Update Readme.md**~~
* **Look into optimising**
  * `n*m == m*n` so only generate half the table