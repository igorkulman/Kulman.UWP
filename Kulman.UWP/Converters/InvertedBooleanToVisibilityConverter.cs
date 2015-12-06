using Kulman.UWP.Converters.Abstract;

namespace Kulman.UWP.Converters
{
    public class InvertedBooleanToVisibilityConverter: BaseVisibilityConverter<bool>
    {
        protected override bool? ConvertToVisibility(bool value)
        {
            return !value;
        }
    }
}
