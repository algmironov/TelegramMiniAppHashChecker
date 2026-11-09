# TelegramMiniAppHashChecker 🔐

**A .NET library for validating Telegram Mini App initialization data (`initData`).**

[![NuGet](https://img.shields.io/nuget/v/TelegramWebAppDataValidator?logo=nuget&label=NuGet)](https://www.nuget.org/packages/TelegramWebAppDataValidator)
![License](https://img.shields.io/badge/License-MIT-blue)

This repository contains the library published as **`TelegramWebAppDataValidator`** on NuGet. It exposes a small API for checking the hash associated with initialization data supplied to a Telegram Mini App.

> **Security notice:** This is an existing implementation, not a security-audited component. Its compatibility with the latest Telegram specification, freshness/replay protection, and constant-time hash comparison have **not** been independently verified as part of this documentation update. Review the implementation and Telegram's current requirements before relying on it for authentication or authorization.

## Installation

```bash
dotnet add package TelegramWebAppDataValidator
```

Or use NuGet Package Manager:

```powershell
Install-Package TelegramWebAppDataValidator
```

See the [NuGet package page](https://www.nuget.org/packages/TelegramWebAppDataValidator) for available versions.

## Basic usage

```csharp
using TelegramWebAppDataValidator;

string initData = "your_init_data_here";
string botToken = "your_bot_token_here";

bool isValid = Validator.Validate(initData, botToken);

if (isValid)
{
    Console.WriteLine("Hash validation succeeded.");
}
else
{
    Console.WriteLine("Hash validation failed.");
}
```

The example demonstrates the library's existing API; it is **not** a complete production authentication flow. Keep your bot token on a trusted backend and never expose it in frontend code or commit it to source control.

## API

```csharp
public static bool Validate(
    string initData,
    string token,
    string cStr = "WebAppData")
```

| Parameter | Description |
|---|---|
| `initData` | Initialization data provided by Telegram Mini Apps |
| `token` | Your Telegram bot token; handle it as a secret |
| `cStr` | Internal validation constant; normally leave the default `WebAppData` unchanged |

Returns a boolean indicating whether the implemented hash check succeeded.

**Important:** A successful hash check alone does not establish that data is recent or safe from replay. Applications should also enforce an appropriate age limit using `auth_date` and follow the latest [Telegram Mini Apps documentation](https://core.telegram.org/bots/webapps#validating-data-received-via-the-mini-app).

## Maintenance notes

Before using this library in a security-sensitive production system, the implementation should be reviewed for:

- Correct parsing and canonicalization of Telegram `initData`.
- Compliance with Telegram's current HMAC validation algorithm.
- Constant-time comparison of computed and supplied hashes.
- Validation of `auth_date` and replay/freshness requirements.
- Malformed input handling and tests against official test vectors.

These are **review items**, not claims that the current implementation already satisfies them.

## License

MIT.

## Feedback

Report issues or propose improvements through [GitHub Issues](https://github.com/algmironov/TelegramMiniAppHashChecker/issues).
