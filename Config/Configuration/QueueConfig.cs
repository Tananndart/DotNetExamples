namespace ConfigSectionsJson.Configuration
{
    /// <summary>
    /// Пример конфигурации для работы с очередями.
    /// Если в appsettings.json значения для всех или некоторых параметров будет указано в кавычках, то значения автоматически
    /// сконвертируются в указанные типы.
    /// </summary>
    public class QueueConfig
    {
        public string SecretKey { get; set; } = string.Empty;

        public long MessageTTL { get; set; }

        public string QueueConnection { get; set; } = string.Empty;

        public int RetryConnectionCount { get; set; }

        public int FileLifetimeHours { get; set; }
    }
}
