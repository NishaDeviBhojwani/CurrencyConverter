# CurrencyConverter

## Task:
This application converts a currency (dollars) from numbers into words. <br/>
e.g. <br/>
25,1: twenty-five dollars and ten cents<br/>
0,01: one cent<br/>
45 100: forty-five thousand one hundred dollars<br/>

### Prerequisites
-> .Net 6 https://dotnet.microsoft.com/en-us/download/dotnet/6.0 <br />
-> Npm <br/>

### How to Run the Project
- Backend Project -- Server <br/>
-> Clone the repository <br />
-> At the CurrencyConverter directory, restore required packages by running: `dotnet restore` <br />
-> Build the solution `dotnet build` <br />
-> Run project `dotnet run` <br />
-> Launch https://localhost:{port}/swagger in your browser to view the Swagger documentation. <br />

- Frontend Project -- Client <br/>
-> cd client/currency-converter-app <br/>
-> Build client project : cd currency-converter-app <br/>
-> Run project: npm start <br/>