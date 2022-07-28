# Json Converter

Asp.Net 6 project with dotnet MVC template for transforming json inputs into xml outputs.  

## Build & Run

This project requires dotnet 6. Simply run ```dotnet run``` in this directory or ```dotnet publish```
to explore without _development launch profile_.  

## More About Project

I tried to keep the project simple.

### Routing, Main Page and Converter Page

For routing I used MVC template's conventions.

I didn't build a complex landing page. But typically for a service,
there could be a nice landing page. For this reason I left ```HomeController``` empty and 
set ```JsonController``` for default route.

Default action returns a basic html page describing how to use which url. JsonController's ToXml action
is where the request for transforming gets handled. It uses JsonConverterService.

In JsonController, an action can be implemented for returning html response with JsonConverterService.
But it was optional so i only implemented returning raw xml.

### Converter Mechanism

Transformation happens in ```JsonConverterService```. I used Newtonsoft.Json library. This library doesnt provide 
async transformation, so I used ```Task.Run()``` to benefit from multicore's power.

### Logging

For logging, I challenged myself and used a library that I've never used before: NLog.
I experienced how to log different levels seperately, how to dynamically name log files and how to
customize log message layout with NLog.

Main directory for log files is ```logs/<yyyy-MM-dd>``` in build directory. One log file for logging everything (Trace level),
including request and response bodies, named _detailedlogs.txt_ and one for only errors named _errorlogs.txt_.

### Error Handling

I created ```ErrorController``` for global exception handling. For user friendly messages, I created my custom exception 
```UserFriendlyException```.

Error pages in _development lunch profile_ is different, they also include stack trace. To see public error pages, 
one should examine project with ```dotnet publish```.

Also I used [http cats](https://http.cat/) in error pages to make them fun :)
