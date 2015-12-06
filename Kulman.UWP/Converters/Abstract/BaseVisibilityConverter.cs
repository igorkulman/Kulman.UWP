using Windows.UI.Xaml;

namespace Kulman.UWP.Converters.Abstract
{
	public abstract class BaseVisibilityConverter<TFrom> : BaseConverter<TFrom, Visibility?>
	{
		protected abstract bool? ConvertToVisibility(TFrom value);

		public sealed override Visibility? Convert(TFrom value)
		{
			var visible = ConvertToVisibility(value);

			if(visible.HasValue)
			{
				return visible.Value ? Visibility.Visible : Visibility.Collapsed;
			}
			else
			{
				return null;
			}
		}
	}
}
