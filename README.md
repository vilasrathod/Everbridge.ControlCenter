# Everbridge.ControlCenter

This project provides the WPF client and API server to maintain the DoorController based on */api/door*.
To avoid the Database dependency, it is using xml file as data source
Server run at  https://localhost:5001


Why I have selected Challenge 1 - WPF Client
* I have 9 years of experience with WPF application development. For React Web Client need to spend more time to learning
* WPF offers advanced visual features (animations and video playback) and a standard set of Windows controls as well XML binding and the data template features. It makes developer to develop rich data visualizations application to customer
* PRISM framework and MVVM design pattern help to develop modular, maintainable, testable product in less time


Design of the application
![Architecture Diagram](https://user-images.githubusercontent.com/62507081/133895814-55f9cbda-468b-480c-a794-b5681da2c5c4.jpg)

WPF client is developed with a modular approach. Door Control Module is an independent module which can be plugin to client at run time. It provides the advantages that multiple teams can work parallely at multiple modules, it can be developed, maintained, tested and can be deployed independently.

Modules and Common component can be used for client as well as Server to achieve reusability of code

As part of System design best practices - Separation of concern - Client, Server and Database is developed as separate component, can run on different system


Implemented features

When I connect my client to the server –
  * Then I would like a list of all the doors at the facility.

When reviewing a door within the client –
  * Then I would expect each door to have a customisable label to provide user friendly reference to an individual door
  * And I would like to know whether door is Open or Closed
  * And I would like to know whether door is Locked or Unlocked

When configuring doors within the facility –
  * Then I would like to be able to Add a new door
  * And be able to remove an already existing door
When controlling doors within the facility –
  * Then I would expect to be able to Open a Closed Door
  * And be able to Close an Open door
  * And be able to Lock a Closed Door
  * And be able to Unlock a Locked Door
 
* This architectural support for Multi Client connectivity to server


If you had access to the customer when you were developing this application, what questions would you have asked in relation to your design?

* The requirement expects support for the door management system for Door IOT devices, is there any plan to extend this application to support more different types of IOT devices. This data will help to consider to develop extensible and maintainable applications. 
* What will be the max number of devices and type of devices this application and the size of the Data flow is expected to support for both client and server. This data will help to consider the scalability and reliability factor of application 
* Is there any explicitly requirement for the Security for communication, data handling and authentication and authorization 
* Is there any requirement for support multiple client application theme as well as different language support 

If you were given another more hours, what would you have done next and why

* Make code more readable with adding required comments 
* Add the logging, exception handling to support the product debugging and maintabilirty Add application theme and localization support Try to use parallel multithreading  to optimize the application performance by using the multicore processor 
* Add cache mechanism, load balancer, Message Queuing Protocol, Multithreading synchronization to optimize the Server performance

