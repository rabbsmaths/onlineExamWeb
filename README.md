# onlineExamWeb
OnlineExamWeb allow examiner to create test that students can write online.

#Solution Setup
- Solution was developed using visual studio 2013, to run it you will need visual studio 2013 or later.

- You will need to run the database backup file named 'onlineExamDB.bak' on MS SQL server 2012 or later,
this file can be found inside of this project in this directory 'OnlineExamApplication'.

- Last step you will have  to change the server name and provide cridential to your SQL server. In webconfig file
 current settings are as follows. 
 
 <add name="onlineExamDB" connectionString="Data Source=.\SQLEXPRESS;Initial Catalog=onlineExamDB;Integrated Security=True;
 MultipleActiveResultSets = true"  providerName="System.Data.SqlClient" />
 
 Integrated Security = true, means no credentials used. you will have to replace this with your server username = ?; password =?.
 Data Source is your server where you running provided database.
 
 //
 
 #To use the web
 
 - You have two types of users examiner and student. you must create account for each user and login to explore on the solution.
 
 Thank you.
