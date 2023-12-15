# Пример работы с конфигурационным json файлом и переменными окружения

Пример для обычного консольного приложения, в случае использования ASP .Net реализация будет немного отличаться.

## Пререквизиты (NuGet пакеты):
- Microsoft.Extensions.Configuration.Binder
- Microsoft.Extensions.Configuration.Json
- Microsoft.Extensions.Configuration.EnvironmentVariables


## Концепция
- За интерфейсом `IConfiguration` скрывается экземпляр конфигурации, который был создан с помощью `ConfigurationBuilder`.
- При построении этого экземпляра мы указали `Sources`, т.е. источники всех возможных параметров приложения.
- В `Sources` мы указали json файл `appsettings.json` и переменные окружения.
- При построении экземпляра конфигурации, конфигурационные пакеты парсят json файл и все достпуные переменные окружения.
	- Пример переменной окружения: `Settings:SecretKey`. Где `Settings` - это секция, а `SecretKey` - параметр.
    - Если параметр пустой или отсутствует в `appsettings.json`, то он подтягивается из переменных окружения:
        - из `launchSettings.json`
        - либо их можно выставить тут: `Project Properties > Debug > General`
        - либо из глобальных переменных среды ОС
    - В примере специально параметры `SecretKey` оставлены пустыми, чтобы их значения не светились в репозитории, а подтягивались из переменных окружения разработчика
- Для удобства доступа к параметрам из приложения, мы связываем полученные экземпляром конфигурации параметры с нашими классами.
- При этом мы проверяем существование нужных нам секций
	- Дополнительно, можно сделать более глубокую валидацию всех параметров, а также выставить значения по умолчанию.
- После связывания, мы можем потокбезопасно работать со всеми нужными параметрами через статический класс `Configurations`.

## Что дополнительно почитать:
- https://learn.microsoft.com/en-us/dotnet/core/extensions/configuration
- https://learn.microsoft.com/en-us/dotnet/core/extensions/configuration-providers#environment-variable-configuration-provider
- https://learn.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-6.0#jcp