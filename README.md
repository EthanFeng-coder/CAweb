CAweb
CAweb is a .NET API backend for the CA web application. It is configured to run on Ubuntu 22.04.1 and uses a MySQL database for data storage.

Install the necessary dependencies:

sql
Copy code
sudo apt-get update
sudo apt-get install -y mysql-server
sudo apt-get install -y dotnet-sdk-6.0
Create a new MySQL database and import the data from the SQL script included in the repository:

php
Copy code
mysql -u <username> -p <database name> < ca_web_db.sql
Replace <username> with your MySQL username, <database name> with the name of the database you want to create, and ca_web_db.sql with the name of the SQL script.

Start the API:

bash
Copy code
cd CAweb
dotnet run
The API should now be accessible at http://localhost:5000.

Usage
CAweb provides the following endpoints:

GET /api/users: Returns a list of all users.
GET /api/users/{id}: Returns a specific user by ID.
POST /api/users: Creates a new user.
PUT /api/users/{id}: Updates an existing user by ID.
DELETE /api/users/{id}: Deletes a user by ID.
Contributing
If you would like to contribute to CAweb, please submit a pull request or open an issue.
