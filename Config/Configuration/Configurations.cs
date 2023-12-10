using Microsoft.Extensions.Configuration;

namespace ConfigSectionsJson.Configuration
{
    /// <summary>
    /// Статический класс, который является endpoint-ом для работы со всеми параметрами конфигурации приложения.
    /// Перед использованием необходимо вызвать метод SetProperties(IConfiguration).
    /// </summary>
    public static class Configurations
    {
        /// <summary>
        /// Свойство для доступа к параметрам из секции Storage.
        /// Инициализируем пустым экземпляром, чтобы исключить появление NullReferenceException.
        /// </summary>
        public static StorageConfig StorageConfig { get; private set; } = new StorageConfig();

        /// <summary>
        /// Свойство для доступа к параметрам из секции Queues.
        /// Инициализируем пустым экземпляром, чтобы исключить появление NullReferenceException.
        /// </summary>
        public static QueueConfig QueueConfig { get; private set; } = new QueueConfig();

        /// <summary>
        /// Заполняет все свойства во всех секциях из конфигурационного менеджера.
        /// Неободимо вызвать перед использованием, при инициализации приложения.
        /// Чтобы не усложнять, нет защиты от дурака на случай, если пользователь забыл вызвать этот метод.
        /// </summary>
        /// <param name="configuration">Конфигурационный менеджер.</param>
        public static void SetProperties(IConfiguration configuration)
        {
            StorageConfig = GetSection<StorageConfig>(configuration, "Storage");
            QueueConfig = GetSection<QueueConfig>(configuration, "Queues");
        }

        /// <summary>
        /// Получить экземпляр класса, отражающего секцию конфига со всеми заполненными параметрами.
        /// Тут же проверяем на доступность секцию и, в случае отсутствия, генерируем InvalidOperationException.
        /// </summary>
        /// <typeparam name="T">Класс, отражающий секцию конфига.</typeparam>
        /// <param name="configuration">Конфигурационный менеджер.</param>
        /// <param name="sectionName">Наименование секции в конфиге.</param>
        /// <returns>Экземпляр класса, отражающий секцию конфига со всеми заполненными параметрами.</returns>
        /// <exception cref="InvalidOperationException">В случае отсутствия секции в конфигурационном менеджере.</exception>
        private static T GetSection<T>(IConfiguration configuration, string sectionName)
        {
            return configuration.GetSection(sectionName).Get<T>()
                ?? throw new InvalidOperationException($"Not found section {nameof(T)} in configuration.");
        }
    }
}
