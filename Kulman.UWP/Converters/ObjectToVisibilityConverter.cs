using System;
using System.Collections;
using System.Linq;
using JetBrains.Annotations;
using Kulman.UWP.Converters.Abstract;

namespace Kulman.UWP.Converters
{
    public class ObjectToVisibilityConverter : BaseVisibilityConverter<object>
    {
        protected override bool? ConvertToVisibility([CanBeNull] object value)
        {
            if (value is string)
            {
                return !String.IsNullOrWhiteSpace((string)value);
            }

            if (value is IEnumerable)
            {
                return ((IEnumerable)value).Cast<object>().Any();
            }

            return value != null;
        }
    }
}
