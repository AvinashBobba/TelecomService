# TelecomService
A web API to convert the E.164 formatted phone numbers into user readable phone numbers.

An Application layer which holds the business logic of the application . 

The domain layer holds the system objects(class) . 

For Testing purpose, xUnit is being used and is used to cover the business cases . 

Application is configured with both exception handling and logging and swagger and security using Api key . 



How to run the application : 

    **Optional**

    (Remove the ApiKey from json file)
    (SETUP : Add "ApiKey": <yoursecretkey> Json object in appSettings file (or) Add an enviroment variable ApiKey = <yoursecretkey> (or) You can add your own secret manager passing your Guid in .csproj file )

Step 1 : Download the solution as zip and extract the solution . 
    
Step 2 : Select the API as the application and click F5 or click run button on visual studio (It is specific to the tools being used)

Step 3 : Application is passed an E164 formatted mobile number which in return gives us user readable formatted number. 

(or)

Running Using Docker : (SETUP: Api key is provided as the environment variable for the docker compose)

STEP 1 : Open the solution folder and open command prompt to run the STEP 2 

STEP 2 : docker-compose up -d

STEP 3 : Run  docker-compose ps command and check for the port 

STEP 4 : Use the localhost and port to access the swagger 