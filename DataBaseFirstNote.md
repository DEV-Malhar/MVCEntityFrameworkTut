#Database First Approach
--------------------------
--------------------------
-> In the database first approach the Entity Framework Core creates model Class and Properties corresponding to the exisitng database 
   object such as tables and columns 

-> The Database First Aproach is Applicable in Scenario where a database already exists for the Application

-> In Every organaization ERD(Entity Relational Diagram) is made befor code wher all databse tables are created


---------------------------------------------------------------------------------------------------------------------------------------
#Diagram
--------
																
			Existing			   *Command*    			    Model Class
			Database	---->   Scaffold DbContext  ---->			+
			Tables											   DbContext Class

---------------------------------------------------------------------------------------------------------------------------------------
#Steps:
---------
   >Step1:

	    -> Import and Install 3 packages in Nuget Manager
			 - Microsoft.EntityframeworkCore.SqlServer
			 - Microsoft.EntityframeworkCore.Tools
			 - Microsoft.EntityframeworkCore.Design
  >Step2:

		-> Execute a command for Scaffold DbContext inside NuGetManager Terminal

	   >command:Will Execute for First Time after Creating Database
	   
		    "Scaffold-DbContext"server=ServerName;database=DatabaseName;trusted_connection=true"
			 Microsoft.EntityFrameworkCoreSqlServer-OutputDir Models " -->
		
		      This Command will generate model class and DbContext class Automatically

	  >command:Will Execute for First Time after Updation or After Adding Table
	   
		    "Scaffold-DbContext"server=ServerName;database=DatabaseName;trusted_connection=true"
						Microsoft.EntityFrameworkCoreSqlServer-OutputDir Models -force " -->
  >Step3:
		 
		 -> Move Connection String from DbCOntext Class to appsettings.json file

  >Step4:

		-> Registring Connection String in Program.cs File
			var provider = builder.Services.BuildServiceProvider();
			var config = provider.GetRequiredService<IConfiguration>();
			builder.Services.AddDbContext<DatabaseFirstASPCore6DbContext>(item => item.UseSqlServer(config.GetConnectionString("dbcs")));
			