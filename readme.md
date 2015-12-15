Cycloid gear graphic calculator
===============================

This is a little utility to help in the design of cycloidal drives. It is a port to C# of this python script

    http://www.zincland.com/hypocycloid

with some added features (mainly, the graphical display). This is some quick code I put together one day, but is contains a nice design that allows for easy visualization of any complex formula, so it is rather straightforward to add new gear teeth profile solvers that can be easily visualized as parameters are modified with the sliders and finally exported to DXF. 

Here is a screenshot of an early version: 

![Screenshot](/Screenshots/03.png)


## Installing

The instalation is pretty straigforward, just unzip and run the .exe. 


## Building

Open the solution in Visual Studio (I used 2013) and build. Alternatively, use msbuild: 

    msbuild CycloidGenerator.sln


## Creating new solvers

A solver is just a piece of code that has some input parameters, performs some calculations and draws something out of it. Check a minimal sample in Solvers/SampleSolver.cs for details on how to implement them. 

Uncomment the line 

    SetSolver(new SampleSolver() { Angle = 60 });

in MainForm.cs to see it in action. 