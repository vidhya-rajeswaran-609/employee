This repo contain source codes for a Employee application with RESTful API Data.

## STEPS

In the project directory, 

### STEP 1 : Open Sql server management studio and run the Tables.sql script in employee/prep folder 

This step creates a CompanyEmployee database and creates Employee and Role tables with the relationships.<br />
This step also inserts employee and role records.
<br />

### STEP 2 : API - run CompanyEmployee solution in employee/api folder

Runs the api in the development mode.
<br />

Update connection string in DefaultConnection pointing to the database
<br />

Open [https://localhost:44352/api/employee](https://localhost:44352/api/employee) to view the list of employees in  the browser.

![Screenshot](api.png)
<br />

### STEP 2 : API - run postman collection

Import the postman collection `employee.postman_collection.json` from the employee/prep folder.
<br />

The api url points to localhost. The collection has requests for employee and roles controller.
<br />

### STEP 2 : API - run postman collection

Import the postman collection `employee.postman_collection.json` from the employee/prep folder.
<br />

The api url points to localhost. The collection has requests for employee and roles controller.
<br />

### STEP 3 : UI - open employee in code editor

navigate to `cd ui` 
<br />

run  `npm install` 
<br />

verify the api url in employee\ui\src\api\server.js. This should point to the localhost api.
<br />

run  `npm start` . This starts the ui on [https://localhost:3000](https://localhost:3000)
<br />

![Screenshot](ui.png)

### STEP 4 : Run tests

for API, cd test project and run the test suite in employee/api/CompanyEmployee.Test
<br />

for UI, cd ui and run `npm test`
<br />





