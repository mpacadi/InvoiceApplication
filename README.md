<h2>Introduction</h2>
Assignment provided by Enterwell to create invoice MVC5 application. Main goal if assigment is to create simple application for creating and displaying invoices. Application was created using the Visual Studion 2022 edition.

<h3>Build</h3>
To build solution use the Visual Studio. Application can be run in VS after the build of a solution is initiated. On build the library projects for extesions are build and their output is copied inside the main MVC project.
To initialise database run in VS terminal the update-database to create new instance of database. For development database the LocalDB was used. Using the Migrations the inital data for Taxes and Product is injected inside the database. Conncetion string for database is defined inside the Web.config.

<h3>Run</h3>
After the build and initialisation of the database, VS can be used to run the application.

<h3>Frameworks</h3>
For this assigment the following frameworks were used:
  - Entity Framework -> For creating database using the Code First approach
  - Identity -> To enable authorization and authentication of a user
  - Unity -> To allow Dependecy Injection inside MVC 5 project
  - Log4net -> To provide logging interface to catch errors
  - FluentValidation -> To create custom validator to validate input data on Views and in Controllers
  - BeginCollectionItem -> Html helper for collecting and passing the list of items to the controller
  
