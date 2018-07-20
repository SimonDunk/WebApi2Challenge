# WebApi2Challenge

## About
A RESTful web service that performs CRUD operations for a product entity.

## Software Requirements
* Visual Studio 2017 15.7.3 or later
* ASP.NET and web development workload
* .NET Core cross-platform development
* .NET Core 2.1 SDK
* Postman

##How to use
* Open the project in Visual Studio
* Press Ctrl + F5 to launch the app
* The URL in the browser should look something like this https://localhost:44382/api/values
* it should display ["value1","value2"] if working correctly
* Modify the URL to https://localhost:44382/api/product to view all products in JSON format
* You can look at individual products if you add the product id to the end of the link eg https://localhost:44382/api/product/bb6605b6-cd83-4d8f-9f1c-2e187b0d6d6a 
* 

## Using Postman to test the API
* Open Postman
* Import the Collection from the Postman folder in the main directory of the repository
* Import the Enviornment from the same folder
* Edit port number in the url key of the ProductAPIEnvironment to be the same as the one in the link from above
* Press Ctrl + Shift + R
* Click on the ProductApiTest Collection
* Click Run ProductApiTest
* The results will be shown

## TODO
* Apply some form of authentication
* Add filtering to the GET products route
* Create a light weight UI for querying the API

## BUGS
* 
