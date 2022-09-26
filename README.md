Assignment provided by Enterwell to create invoice MVC application.

Development database used in a project is LocalDB. The connection string for configuration of a database location is located on a Web.config.

For a first use build a solution so that the .dlls for tax extension could be copied inside of a InvoiceApplication project. After that they can be used inside the web application.

For this assigment the following frameworks were used:
  - Entity Framework -> For creating database using the Code First approach
  - Identity -> To enable authorization and authentication of a user
  - Unity -> To allow Dependecy Injection inside MVC 5 project
  - Log4net -> To provide logging interface to catch errors
  - FluentValidation -> To create custom validator to validate input data on Views and in Controllers
  - BeginCollectionItem -> Html helper for collecting and passing the list of items to the controller
  
