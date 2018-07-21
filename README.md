# WebApi2Challenge

## About API
A RESTful web service that performs CRUD operations for a product entity.

| CRUD Operation | API Command | Action | Complete |
| -------------- | ----------- | ------ | -------- |
| GET | /api/product | Lists all products in JSON format | [x] |
| GET | /api/product/{id} | Lists a specific product by id | [x] |
| GET | /api/product/{model} | Lists all products with the same model name | [] |
| GET | /api/product/{brand} | Lists all products with the same brand name | [] |
| GET | /api/product/{description} | Lists all products with the same description | [] |
| POST | /api/product | Adds a new item via JSON formatted text | [x] |
| PUT | /api/product/{id} | Update an existing product via id in JSON formatted text | [x] |
| DELETE | /api/product/{id} | Delete a product by id | [x] |
| --- |


## Software Requirements
* [Visual Studio 2017 15.7.3 or later] (https://visualstudio.microsoft.com/downloads/)
* ASP.NET and web development workload for Visual Studio
* .NET Core cross-platform development for Visual Studio
* [.NET Core 2.1 SDK] (https://www.microsoft.com/net/download)
* [Postman] (https://www.getpostman.com/apps)

## How to use
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

## Important files
* Startup.cs
	* database context is registered with dependency injection (DI) container
	* The context is registered with DI are available to the controllers
	* specifies an in memory database and is injected into the service container

* Product.cs
	* Model of the data to be used by the controller and context

* ProductContext.cs
	* coordinates entity framework functionality for a model

* ProductController.cs
	* uses the model to modify the database/context 
	* stores all routes and performs their implemntation

## TODO
* Apply some form of authentication
* Add filtering to the GET products route
* Create a light weight UI for querying the API

## BUGS
* 
