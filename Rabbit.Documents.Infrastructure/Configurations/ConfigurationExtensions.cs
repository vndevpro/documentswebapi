using Microsoft.Extensions.Configuration;

namespace Rabbit.Documents.Infrastructure.Configurations
{
    public static class ConfigurationExtensions
    {
        /// <summary>
        /// Get a configuration section and bind it to a specified type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="configuration"></param>
        /// <param name="sectionName"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static T GetSection<T>(this IConfiguration configuration, string sectionName) where T : new()
        {
            var section = configuration.GetSection(sectionName);

            if (section == null)
            {
                throw new ArgumentNullException(nameof(section), $"Configuration section '{sectionName}' not found.");
            }

            var options = new T();
            section.Bind(options);

            return options;
        }
    }
}
