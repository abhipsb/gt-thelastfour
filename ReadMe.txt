This file provides the information about the solution for two problems titled "The Last Four" and "The Tie Breaker".
This is a console based application, developed in Visual Studio 2015 environment.

=========================================================================================================
1. Running the application
=========================================================================================================
1.1 Open the CricketChallenge.sln in Visual Studio
1.2 Make sure CricketChallenge.PL is the startup project
1.3 Press F5 or "Ctrl + F5" key to run the application
1.4 A console window will be displayed

=========================================================================================================
2. How to use the application
=========================================================================================================
2.1 On the console window, choose the option by pressing respective number key.

	-> 2.1.1 Pressing number key 1 will start the simulation of problem "The Last Four"
	-> 2.1.2 Pressing number key 2 will start the simulation of problem "The Tie Breaker"
	-> 2.1.3 Pressing number key 3 will close/quit the application

=========================================================================================================
3. Code organization
=========================================================================================================
There are 4 assenblies in the solution i.e CricketChallenge.BL, CricketChallenge.Interface, CricketChallenge.PL and CricketChallenge.BL.Test.Unit

3.1 CricketChallenge.PL [exe]
	-> This is the main executable assembly
	-> It's the Presentation Layer or Ui. All kind of Input/Output is handled here

3.2 CricketChallenge.BL [dll]
	-> This assembly is Business Layer.
	-> A class "CricketMatch" is implemented which simulates both the problems
	-> A class "Team" is implemented which is responsible for team's related behaviour
	-> A class "Player" is implemented which is responsible for player's [a batsman] realted behaviour
	-> A class "ProbabilityGenerator" is implemented which generates possible result of the ball based on player's probability
	-> A class "ResultGetter" is implemented which provides match related various results as formatted string messages
	-> For each of above classes an interface is provided

3.3 CricketChallenge.Interface [dll]
	-> This is assembly acts as an interface between PL and BL
	-> A class "Get" is implemented a kind of factory which creates instances of classes that are in "CricketChallenge.BL" assembly and return respective interfaces

3.4 CricketChallenge.BL.Test.Unit [dll]
	-> This is the Unit Test assembly
	-> Unit Tests run with each build
	-> If all tests are passed then build will be success otherwise failure

Both the layers (PL & BL) are separate and independent and connected via an iterfacing assembly.