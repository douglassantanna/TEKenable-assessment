# Newsletter Signup App

This is a web application that allows users to sign up for a newsletter by completing a simple form. The application consists of an Angular frontend and a .NET Core 7 API backend. The backend uses Entity Framework Core with an in-memory database to handle user signup requests and store the data.

## Features

- Users can submit their email address, reason for signing up, and how they heard about the site.
- The form enforces validation rules for email addresses, reason for signing up, and how they heard about the site.
- The application prevents duplicate email signups.
- Upon successful signup, users receive feedback that they have been signed up to the newsletter.

## Technologies Used

- Angular: Frontend development framework for building the user interface and handling user interactions.
- .NET Core 7: Backend development framework for building the API and handling user signup requests.
- Entity Framework Core: Used for database access and data persistence with an in-memory database.
- Node.js: Required to run the Angular frontend locally.
- .NET 7 SDK: Required to run the .NET Core API locally.
- OpenAPI/Swagger: Provides documentation and a web-based interface for testing the API.

## How to Run the Application Locally

1. Clone the Repository:
   - Clone the project repositoriy to your local machine.

2. Set Up the Angular App:
   - Install Node.js if you haven't already: [Node.js](https://nodejs.org/)
   - Open a terminal or command prompt, navigate to the root directory of your Angular project.
   - Run the following command to install the required dependencies:

     ```
     npm install
     ```

   - After the dependencies are installed, run the Angular app:

     ```
     ng s -o
     ```

   - The Angular app should now be running at `http://localhost:4200`. Open your web browser and visit the URL to access the app.

3. Set Up the .NET Core API:
   - Make sure you have .NET 7 SDK installed on your machine: [Download .NET SDK](https://dotnet.microsoft.com/download/dotnet/7.0)
   - Open a terminal or command prompt, navigate to the root directory of your .NET Core project (where your `.csproj` file is located).
   - To run the .NET Core tests, navigate to the root directory of the .NET Core project and run:

     ```
     dotnet test
     ```

   - The test results will be displayed in the terminal.
   - Run the following command to start the API:

     ```
     dotnet run
     ```

   - The .NET Core API should now be running at `http://localhost:7018`. You can test the API endpoints using tools like Postman or any browser-based REST client.
  
4. Test the Application:
   - With both the Angular app and .NET Core API running, you can now access the application at `http://localhost:4200`.
   - Test the signup functionality, enter the required information in the form, and submit it.
   - Check the console or logs in your .NET Core API to see the signup requests and responses.

5. Test the API with OpenAPI/Swagger:
   - While the .NET Core API is running, open your web browser and visit `http://localhost:7018/swagger/index.html`.
   - Swagger provides a user-friendly interface to explore and test the API endpoints directly from the browser.
   - You can use Swagger to send test requests and view responses without using additional tools.

6. Cleaning Up:
   - If you are done testing, stop both the Angular app and .NET Core API by pressing `Ctrl + C` in their respective terminal windows.
