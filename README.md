Purpose
=======
To provide a set of custom C# data structures to complete code katas.

Data Structures
===============

Nodes and Edges
---------------
Basic Node and Edge objects based on a 2-dimensional plane. A Node is made up of a 'x' and 'y' coordinate. An Edge is made up of two Node objects.

Build
=====
A NuGet is available at (location to be provided).

Requirements
------------
* NAnt and NAntContrib extension is installed
* NuGet.exe is in PATH

build.bat
---------
Builds the DataStructures project, restoring any NuGet packages as needed.

build-test.bat
--------------
Builds the DataStructures project, and runs the associated unit tests. Automatically opens an HTML report after the tests have finished.

clean.bat
---------
Deletes the `bin` and `_testoutput` folders.

nuget-restore.bat
-----------------
Restores any missing NuGet packages.

test.bat
--------
Runs all the unit tests.
