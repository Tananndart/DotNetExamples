using ConfigSectionsJson.Configuration;
using Microsoft.Extensions.Configuration;

namespace ConfigSectionsJson
{
    internal class Program
    {
        static void Main()
        {
            var config = new ConfigurationBuilder() 
                .AddJsonFile("appsettings.json") // указываем имя нашего конфига
                .AddEnvironmentVariables()       // добавляем переменные окружения
                .Build();                        // метод построения итогового конфига из нашего конфига и переменных окружения

            // Маппим все свойства и значения ConfigurationBuilder в наши конфигурационные статические классы
            Configurations.SetProperties(config);

            // Показываем, что получилось
            Console.WriteLine("======= Storage =======");
            Console.WriteLine($"SecretKey = {Configurations.StorageConfig.SecretKey}");
            Console.WriteLine($"UriLifetimeSeconds = {Configurations.StorageConfig.UriLifetimeSeconds}");
            Console.WriteLine($"SizeFactor = {Configurations.StorageConfig.SizeFactor}");
            Console.WriteLine($"UsePersistent = {Configurations.StorageConfig.UsePersistent}");
            Console.WriteLine($"FileLifetimeHours = {Configurations.StorageConfig.FileLifetimeHours}");

            Console.WriteLine("======= Queues =======");
            Console.WriteLine($"SecretKey = {Configurations.QueueConfig.SecretKey}");
            Console.WriteLine($"QueueConnection = {Configurations.QueueConfig.QueueConnection}");
            Console.WriteLine($"RetryConnectionCount = {Configurations.QueueConfig.RetryConnectionCount}");
        }
    }
}
