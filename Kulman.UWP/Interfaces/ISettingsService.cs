using JetBrains.Annotations;

namespace Kulman.UWP.Interfaces
{
    /// <summary>
    /// Interface definition for settings manipulation
    /// </summary>
    public interface ISettingsService
    {
        /// <summary>
        /// Gets a stored value for a given key
        /// </summary>
        /// <param name="key">Key</param>
        /// <returns>Value</returns>
        [CanBeNull]
        object Get([NotNull] string key);

        /// <summary>
        /// Save a key-value pair to settings
        /// Overwrites existing
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="value">Value</param>
        void Set([NotNull] string key, [CanBeNull] object value);

        /// <summary>
        /// Deletes value for a given key
        /// </summary>
        /// <param name="key">Key</param>
        void Clear([NotNull] string key);

        /// <summary>
        /// Clears all settings
        /// </summary>
        void ClearAll();
    }
}
