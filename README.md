# TelegramMiniAppHashChecker
## .NET Class library for validating data from Telegram Mini App (WebAppData) 

The only aim of this lib is to verify data came from Telegram when launching Mini App. 

## Installing

```sh
Install-Package TelegramWebAppDataValidator
```

Or add reference into your `.csproj` file:

```xml
<PackageReference Include="TelegramWebAppDataValidator" Version="1.0.0" />
```

## Usage

To validata Telegram WebAppData call `Validate` method from `Validator` class.

```csharp
using TelegramWebAppDataValidator;

string initData = "your_init_data_here";
string token = "your_bot_token_here";
bool isValid = Validator.Validate(initData, token);

if (isValid)
{
    Console.WriteLine("Data is valid.");
}
else
{
    Console.WriteLine("Data is not valid.");
}
```

## Methods

### Validate

```csharp
public static bool Validate(string initData, string token, string cStr = "WebAppData")
```

- **initData**: Data string, received from Telegram.
- **token**: Your Bot Token.
- **cStr**: Constant string used to hash data. "WebAppData" is a default string, do not change it until (if) Telegram changes it's api.

Returns `true`, if validation was successful, and `false` if validation fails.

## License

This library is distributing under the MIT License. 

## Contacts

Reach me via [GitHub Issues](https://github.com/algmironov/TelegramMiniAppHashChecker/issues).

Or via [Telegram](https://t.me/Alexey_G_M)

## Final words

Thanks for using TelegramWebAppDataValidator!