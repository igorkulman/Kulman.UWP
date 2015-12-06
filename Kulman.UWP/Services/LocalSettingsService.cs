using Windows.Storage;
using JetBrains.Annotations;
using Kulman.UWP.Interfaces;

namespace Kulman.UWP.Services
{
    /// <summary>
    /// ISettingsService implementation using isolated storage settings
    /// </summary>
    public class LocalSettingsService : ISettingsService
    {
        /// <summary>
        /// Gets a stored value for a given key
        /// </summary>
        /// <param name="key">Key</param>
        /// <returns>Value</returns>
        [CanBeNull]
        public object Get([NotNull] string key)
        {
            if (ApplicationData.Current.LocalSettings.Values.ContainsKey(key))
            {
                return ApplicationData.Current.LocalSettings.Values[key];
            }

            return null;
        }

        /// <summary>
        /// Save a key-value pair to settings
        /// Overwrites existing
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="value">Value</param>        
        public void Set([NotNull] string key, [CanBeNull] object value)
        {
            if (ApplicationData.Current.LocalSettings.Values.ContainsKey(key))
            {
                ApplicationData.Current.LocalSettings.Values[key] = value;
            }
            else
            {
                ApplicationData.Current.LocalSettings.Values.Add(key, value);
            }
        }

        /// <summary>
        /// Deletes value for a given key
        /// </summary>
        /// <param name="key">Key</param>
        public void Clear([NotNull] string key)
        {
            if (ApplicationData.Current.LocalSettings.Values.ContainsKey(key))
            {
                ApplicationData.Current.LocalSettings.Values.Remove(key);
            }
        }

        /// <summary>
        /// Clears all settings
        /// </summary>
        public void ClearAll()
        {
            ApplicationData.Current.LocalSettings.Values.Clear();
        }
    }
}
