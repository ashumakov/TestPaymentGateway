# TestPaymentGateway
Payment gateway test project.
It contains payment gateway API implementation. 

## Prerequisites
* .NET Core 3.1 
* Visual Studio 2019

## Installation steps
* Downnload code from the repositry
* Open PaymentGateway.sln in Visual Studio and build it
* Edit connection string in project PaymentGateway.Hosts.WebApi -> appsettings.json
* Run migration in order to setup DB
```C#
   Update-Database -Args "[FullPath]\appsettings.json"
```
* Run PaymentGateway.Hosts.WebApi project. It will open swagger UI

## Api Description

### Authentication
API is using signature authentication. HTTP header `Signature` should contains SHA512 hash of the JSON body surrounded with `SignatureKey`.
 
> E.g. SignatureKey = "test" <br />
> Json body = {\"someproProperty\":\"somevalue\"} <br />
> Combined string for hash would be    <br />
> SHA512("test{"someproProperty":"somevalue"}test") == "5feb29155dcbb5709fb09da442ec74dde182ef023216cc8aa5f761add4ff3a58059d1b79fcd9f80329380be7b2818a27c9ee2cdd4722a4486eb3b23691b37bc7"

### Basic request
Signature header `4bc589edde0b5fd820d8d016e35ebae2bc875d8c498ebc95e90c7741ce7c46c7b001afed1f497b35ad267b5a20acaed9021e376b7635563a85af80e044dd65af`
```JSON
{
  "merchantId": "daf008ed-beff-44c0-a67b-f256e650fe5f",
  "card": {
    "cardNumber": "4111111111111111",
    "cardSecurityCode": "123",
    "cardHolderName": "string",
    "expirationDate": "11/22"
  },
  "amount": {
    "currency": "USD",
    "value": 31
  }
}
```

## Author
> Alexander Shumakov
>- Email: shumer100@gmail.com
