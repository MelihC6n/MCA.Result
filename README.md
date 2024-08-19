# MCA.Result Library

## Overview

Note: This package is prepared for personal development and is not yet intended for use in real projects!

The `MCA.Result` library provides a generic `Result<T>` class that represents the outcome of an operation. It encapsulates both successful and unsuccessful results, including relevant data, error messages, and status codes. This approach is particularly useful in APIs and services where you need to standardize the response format across different operations.

## Features

- **Success and Failure Handling:** Provides a clear distinction between successful and unsuccessful operations.
- **Status Codes:** Supports HTTP status codes to provide additional context for the result.
- **Error Messages:** Allows for single or multiple error messages to be returned when an operation fails.
- **JSON Serialization:** Ensures that irrelevant fields (like `StatusCode`) are ignored during JSON serialization.

## Installation

To use the `MCA.Result` class in your project please download from 'Manage NuGet Packages' screen, otherwise I still don't know other ways. Ensure that you have references to the necessary libraries, such as `System.Text.Json` for JSON serialization.

## Usage

### Success Result

To create a successful result, use the `Succeed` method. This method returns a `Result<T>` object with the `IsSuccessful` flag set to `true` and the `StatusCode` set to `200`.

```csharp
var successResult = Result<string>.Succeed("Operation was successful.");
```

## Failure Result

To create a failure result, use the Failure method. This method allows you to specify an error message and a status code.

### Single Error Message

```csharp
var failureResult = Result<string>.Failure("An error occurred.", 500);
```

### Multiple Error Messages

If you need to return multiple error messages, use the overloaded Failure method:

```csharp
var errorMessages = new List<string> { "Error 1", "Error 2" };
var failureResult = Result<string>.Failure(errorMessages, 400);
```

### Accessing the Result

You can access the properties of the Result<T> object to inspect the outcome of an operation:

```csharp
if (result.IsSuccessful)
{
    Console.WriteLine("Success: " + result.Data);
}
else
{
    Console.WriteLine("Failure: " + string.Join(", ", result.ErrorMessages));
    Console.WriteLine("Status Code: " + result.StatusCode);
}
```
## Contributing

This is still so far away from perfection please don't lose your time here. You can find better things than this one.

## License
This project is licensed under the MIT License - see the LICENSE file for details.

