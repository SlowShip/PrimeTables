# Prime Multiplication Table Generator

## Intro:

### Assumptions:
* Since I'm doing this over the weekend I've have no way of checking requirements with anyone, but the spec says "outputs a multiplication table of the **first *10* prime numbers.**"  
I'm assuming the 10 is a typo and should read ***n* prime numbers**
* I'm assuming the system needs to maintain a decent user experience, and so I am rejecting very large requests that take ages to respond (n > 500). This is easy to turn off if not required.

### How to Run:
The app is just a simple MVC app, if you have Visual Studio installed you should just be able to download and run it dirrectly. 
You will need the NUnit test runner to run the unit tests.

Alternatively you can find a deployed version [here](http://prime-tables.azurewebsites.net)  

### What I'm pleased with:
* I'm quite happy with how the independently the `IMultiplicationTableCalculator's` and `ISequenceGenerator's` opperate. It's actually really easy to plugin a different sequence type (as you can see with the `NaturalsSequenceGenerator` I've implemented).
* I'm quite happy with the `OptimisedPrimesSequenceGenerator`, making it was fun. Though I probably shouldn't have spent so much time on it, as it's not the systems bottle neck. I have kept the old `PrimesSequenceGenerator` for reference. The Optimised version I estimate is around 10-20 times faster based some quick, very unscientific testing I ran with `System.Diagnostics.Stopwatch`

### What I would do with it if you had more time:
* I not happy with the validation I've added. I put it there to avoid large numbers throwing out of memory exceptions, but I could have found a better way to prevent this.
* I would like to expose the view models through an Api, then implement a client app using JavaScript that doesn't load the larger values off the page until the user tries to view them which I think would have been a much better experience and may have solved some issues around the memory exceptions.    
* The app could really easily be converted to return multiplication tables of different sequences, all you need to do is pass a parameter to the controller action and get it to pass it along to the factory. I would like to have a play around with this and see what I can make it do.
* I've hacked the DI a little in `MultiplicationTableViewModelFactoryInstaller`. I would liked to clear this up.
* The site is pretty slow. This is not the fault of the calculations, these happen really quickly. Its actually somewhere between view generation and rendering (possibly bootstrap clientside). I would like to look into this. 
* `OptimisedPrimesSequenceGenerator` needs more unit tests for edge cases, i.e. when the upper bound estimate happens to be a prime number (haven't looked into finding a number that does this yet)
* Investigate different data structures to hold results (right now the 2d array appears to be throwing out of memory exceptions around the n = 1000 mark on my local)

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
* ~~**Look into optimising**~~
  * ~~`n*m == m*n` so only generate half the table~~
  * ~~Optimise prime generation~~