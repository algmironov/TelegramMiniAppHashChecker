# TelegramWebAppDataValidator

TelegramWebAppDataValidator — это библиотека для валидации данных, полученных от Telegram при входе в Mini App.

## Установка

Для установки библиотеки через NuGet, выполните следующую команду в консоли управления пакетами:

```sh
Install-Package TelegramWebAppDataValidator
```

Или добавьте ссылку на пакет в ваш `.csproj` файл:

```xml
<PackageReference Include="TelegramWebAppDataValidator" Version="1.0.0" />
```

## Использование

Для валидации данных, полученных от Telegram, используйте метод `Validate` класса `Validator`.

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

## Методы

### Validate

```csharp
public static bool Validate(string initData, string token, string cStr = "WebAppData")
```

- **initData**: Строка данных, полученных от Telegram.
- **token**: Токен вашего бота.
- **cStr**: Строка, используемая для создания секретного ключа. По умолчанию "WebAppData" - изменять не надо! (Если только Телеграм не поменяет api)

Возвращает `true`, если данные действительно получены от Telegram, и `false` в противном случае.

## Лицензия

Эта библиотека распространяется под лицензией MIT. Подробности смотрите в файле LICENSE.

## Контакты

Если у вас есть вопросы или предложения, пожалуйста, свяжитесь с нами через [GitHub Issues](https://github.com/algmironov/TelegramMiniAppHashChecker/issues).

Или через [Telegram](https://t.me/Alexey_G_M) 

## Благодарности

Спасибо за использование TelegramWebAppDataValidator!