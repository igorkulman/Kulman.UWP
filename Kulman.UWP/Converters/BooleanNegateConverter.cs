using Kulman.UWP.Converters.Abstract;

namespace Kulman.UWP.Converters
{
    /// <summary>
    /// Negates a boolean value
    /// </summary>
    public class BooleanNegateConverter : BaseConverter<bool?,bool?>
    {
        public override bool? Convert(bool? value)
        {
            if (value == null) return true;
            return !value.Value;
        }
    }
}
