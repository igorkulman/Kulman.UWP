using System;
using JetBrains.Annotations;
using Kulman.UWP.Converters.Abstract;

namespace Kulman.UWP.Converters
{
    /// <summary>
    /// Converts give string to upper case
    /// </summary>
    public class UpperCaseConverter : BaseConverter<string, string>
    {
        [ContractAnnotation("null => null")]
        public override string Convert([CanBeNull] string value)
        {
            if (String.IsNullOrEmpty(value)) return null;

            return value.ToUpper();
        }
    }
}
