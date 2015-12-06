using Kulman.UWP.Converters.Abstract;

namespace Kulman.UWP.Converters
{
    /// <summary>
    /// Converts true to Visibility.Collapsed
    /// Can be inverted
    /// </summary>
    public class BooleanToVisibilityConverter : BaseVisibilityConverter<bool>
    {
        public bool IsInverted { get; set; }

        protected override bool? ConvertToVisibility(bool value)
        {
            return IsInverted ? !value : value;
        }
    }
}
