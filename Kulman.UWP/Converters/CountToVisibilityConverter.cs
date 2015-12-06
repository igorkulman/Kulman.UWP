using Kulman.UWP.Converters.Abstract;

namespace Kulman.UWP.Converters
{
    public class CountToVisibilityConverter: BaseVisibilityConverter<int>
    {
        public bool IsInverted { get; set; }

        protected override bool? ConvertToVisibility(int value)
        {
            return (IsInverted) ? value==0 : value > 0;
        }
    }
}
