# CollectLoad

1) First API have two action 

    a)SaveCpuFeed : this save data in memory

    b)GetCpuFeed  : read data from memory based on provided filters


    Code is testable ,extendible and maintainable 


2) This API Query first API have only one method which takes two parameters time duration and Server name.


    Report API geting first API end point from web.config 

    <add key="IntegrationUrl" value="http://localhost:62921/api/feed" />
    (if first api port is not 62921 , web.config key "IntegrationUrl"  should be changed accordingly)


    This API is designed as per CQRS pattern. This design will help in segrgating command ,query and event. 
    Modern micro services are designed using CQRS so that read and write functionality can be auto scalled independantly.

Swagger is integrated in both API for better understanding.​
to Use swagger UI :  run application change the URL to http://localhost:{port}/swagger
