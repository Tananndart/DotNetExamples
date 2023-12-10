namespace ConfigSectionsJson.Configuration
{
    /// <summary>
    /// Пример конфигурации для работы с очередями.
    /// Если в appsettings.json значения для всех или некоторых параметров будет указано в кавычках, то значения автоматически
    /// сконвертируются в указанные типы.
    /// </summary>
    public class StorageConfig
    {
        public string SecretKey { get; set; } = string.Empty;

        public long UriLifetimeSeconds { get; set; }

        public float SizeFactor { get; set; }

        public bool UsePersistent { get; set; }

        public int FileLifetimeHours { get; set; }
    }
}
