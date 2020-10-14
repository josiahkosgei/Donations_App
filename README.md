# Donations App & Api

***`Donations App(Donations_App)`***:  Is the application where a donor to enter his/her names, email or phone number and amount and complete the donation via PesaPal API

***`Donations Api(Donations_Api) or 3rd Party Web Service`***:  Is the 3rd party system that will be used as a backend to store all payments (Pending,Failed and Completed)

## Project Requirements

* .NET Core 3.1
* SQLExpress Server
* Visual Studio 2019
* .NET Core CLI

### How To Run The Project

* Clone the repository and rebuild to restore the Nuget Packages
* Run terminal(Powershelll/cmd) from ***`Donations_Api`*** Directory and execute ***`dotnet ef database update`*** command To Run the Migrations against local SQL Server Instance
* Run the Application, Multiple Projects will run at the same time

    * Donation App will run at https://localhost:44323/ and
    * 3rd Party Web Service at https://localhost:44328/

* On https://localhost:44323/ Fill the Donors Details and Complete the Checkout process
* Register and Login on https://localhost:44328/ to access Transactions locally

Make necessary configuration changes on `Donations_App\appsettings.json`