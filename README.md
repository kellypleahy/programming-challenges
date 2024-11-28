# programming-challenges
Implementations in C# of problems from the Programming Challenges book by Skiena and Revilla

This repo currently implements all the code in a unit test library, as it's not currently meant to be run separately.  It doesn't seem like the "tester" that corresponds to the book sends the "login" email for setup, so there's no way to currently register new users.  For this reason we don't know if new logins can be created or if the checker even supports C# at all, so we'll just write our own tests based on those in the book and anything else we see as useful.

To run the tests, use the IDE or do `dotnet test` from the command line.
