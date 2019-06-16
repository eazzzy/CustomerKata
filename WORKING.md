##Assumptions
-Postcode in the example are numeric because these are australian addresses, i have made it string so that we can deal with global postcodes (i.e UK) for when the application is launces globally.


##Design Considerations
-I would never use a csv in this manner as there are many areas of failure, databases address alot of these issues and therefore i have not tried solving all of those issues. For instance file locking might occur when starting to write to this file while also reading from the file at the same time.  Because this excersize does not require any write operations i did not cater for it.
-I used regex to split the csv columns file in order to cater for the special characters in there, using data in better formats will reduce bugs introduced doing custom formatting because of the data structure.
-Used CQRS design paterns for the data layer, in this instance i have only got the CustomerReadDataStore.cs class because we are only reading the data as per the requirement. i would introduce a CustomerWriteDataStore.cs class for write operations so that we could potentialy use difference data sources if the requirement arises.
-I have extracted reading the data from the file out to it own class which can then be replaced by the database layer once the application gets changed to use database instead of csv.
-I have reduced the fields returned by the api to only what is needed by the application, normally i would return all fields from the api for other consumers to filter on their own.
-I extracted the business rules and functionality to a library and left the api as a pass trough only.
-I implemented Swashbuckle and used swagger for the api documentation.

##Features to add:
-When filtered results get below minimum rows per page hide pagination control
-I would add pagination to the api when converting it to database
-Given more time i would add logging to elasticsearch using something like serilog
-Given more time i would add auth
-Must redirect to https
-Given more time i would add ci/cd pipelines.

##Stack
###Backend
-Server side i used dotnet core 2.2
-XUnit
##Frontend
-Vue with bootstrap

##Time Summary
-Design:		1  hour
-Backend:		4  hours
-Frontend:		4  hours
-Testing:		1  hour

Grand Total:	10 hours

##Notes
These kind of tests are challenging as you dont have the full brief. 
What i mean by this is that in a services environment generally you need to follow the spec as is. You should only do what is asked and nothing more. This is because you should not introduce things to the business that is not neccessary. The business only wants the application to do a specific task and want you to deliver it as soon as possible.
On the other hand, in a product environment you are expected to add as much functionality as needed to make the application scalable and introduce lots of features.
In this instance i am following instructions and did not do more than was asked for.
