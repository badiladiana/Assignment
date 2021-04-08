# Assignment

Dear Reviewer,

  Here you can find my proposed solution for the full stack assignment. I had a lot of fun implementing this and even though it is by far not as complete as I would've wanted,
I would like to share with you my view of how I would layer the architecture and build my solution, trying to have in mind what would be applicable for the real life
scenarios in the same time.
  I spent a full day working on the assignment and this is what I was able to complete in that time frame. That being said, here is a small introduction about what i did:
  
Technologies and tools used:
 .net core framework 2.1
 Visual studio 2019
 Git
  
  I decided to implement my solution in the .net core framework, so I've created an ASP.net core web app for this exercise. Once you open the solution, you will be able to see 
3 projects. Assignment which is MVC Web app, and 2 class library projects FundaAPIClient and ServiceManager. 

ServiceManager.
  The MVC is the client, and its controllers should not be concerned where the requested data comes from. It can be from a DB, from an Api, etc. For that purpose I created
the ServiceManager layer. This project deals with calling the data from API and converts the complex model coming from API to a more simple DTO class that is focusing only on 
the makelaar's (which is what we need to feed our client). Here I decided to add a litle server side caching using System.Runtime.Caching. I made an assumption from a business
perspective that the top 10 real estate agents don't change that often, so I added a 30 min cache on the retrieved data. That should mitigate the number of requests per minute issue.
I implemented both a cached version of data retrieval and also non cached.

FundaAPIClient.
  This class library is what actually makes the call to our API. From a security perspesctive, I took a very simple approach in regards to the APIkey that was given in the exercise.
It is stored using the secret manager, so that the actual value doesn't end up in git. There are more complex solutions out there, but I considered that for this purpose it should
be enough. In case of running the app, secret has to be set, all you have to do is run “dotnet user-secret set "Assignment:ApiKey" "valueOfKey" --project pathToWebProjectAssignemnt “

Assignment.
   The web project itself, is a simple MVC solution, which calls the ServiceManager to retrieve the top 10 makelaar's. There is a small Manager folder in there as well which
 helps with mapping and converting the DTO to the actual ViewModel,removing that responsibility from the controller. On the front end side, a very simple razor view which contains
the table with top 10 agents and a checkbox that allows the user to select objects with our without garden. For the rest of parameters, like city(Amsterdam) I decided no have fixed values.
 
   My purpose was to be able to show you how I see the separation of concerns in this particular case, try to have a good optimization of API call, have security in mind for sensitive things
like APIkeys, have a business point of view in mind and build a simple but hopefully logical solution.

Future necesary improvements for this solution:
- implement DI properly, now it's simple version just to showcase a form of inversion of control
- add unit test project
- styling UI, imprvoing js 

 Thank you for your time!
 Diana
  
  
