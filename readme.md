Cycloid gear graphic calculator
===============================

This is a little utility to help in the design of cycloidal drives. It is a port to C# of this python script

    http://www.zincland.com/hypocycloid

with some added features (mainly, the graphical display). This is some quick code I put together one day, but is contains a nice design that allows for easy visualization of any complex formula, so it is rather straightforward to add new gear teeth profile solvers that can be easily visualized as parameters are modified with the sliders and finally exported to DXF. 

![Screenshot](/Screenshots/04.gif)

This is a sample motion simulation of the exported DXF:

![Screenshot](/Screenshots/06.gif)


## Building

Open the solution in Visual Studio (I used 2013) and build. Alternatively, use msbuild: 

    msbuild CycloidGenerator.sln


## Creating new solvers

A solver is just a piece of code that has some input parameters, performs some calculations and draws something out of it. Check a minimal sample in Solvers/SampleSolver.cs for details on how to implement them. 

It comes down to implementing the ISolver interface, providing the paramters needed by the solver and the code that processes those parameters and performs the drawing. 

The SolverManager component already searches the assembly for any ISolver implementations and displays them on the solver combobox.


## License

This code is released under the GPL license. 