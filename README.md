# HTTP Status Test Middleware

A simple ASP.NET middleware to add an endpoint in the app to test HTTP Status response. There are many use cases for this middleware, but it's typically used by Ops to test how the host environments react when the app returns specific HTTP status code.

## Prerequisites

The middleware package supports the following .NET SDK versions:

- .NET Core 2.1 (LTS)
- .NET Core 3.1 (LTS)
- .NET 5.0

## Getting Started

1. Install the package `Polyrific.Middleware.HttpStatusTest` from [NuGet](https://www.nuget.org/packages/Polyrific.Middleware.HttpStatusTest)

   ```powershell
   dotnet add package Polyrific.Middleware.HttpStatusTest --version 1.0.0
   ```

2. In the `Startup.cs` of your project, use the `Polyrific.Middleware.HttpStatusTest` namespace

   ```c#
   using Polyrific.Middleware.HttpStatusTest;
   ```

3. In the `Configure()` method of the `Startup` class, call the `UseHttpStatusTest()` extension method

   ```c#
   public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        ...

        app.UseHttpStatusTest();

        ...
    }
   ```

4. Run the app, and make a `GET` request to the test path, e.g. `https://localhost:5001/httpstatus?c=200`. Replace the value of `c` query string with the expected status code of your test.

## Samples

The usage samples can be found in the [test](https://github.com/Polyrific-Inc/httpstatustest/tree/main/test) folder. There are some projects there that target the supported .NET SDK frameworks.

## Feedback

We'd love to hear your feedback or suggestions. Feel free to submit `Issues` or `Pull Request` for future improvement. Thank you!
