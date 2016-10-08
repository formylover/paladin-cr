using System;

namespace Paladin.CRUtilities
{
    [AttributeUsage(AttributeTargets.Field)]
    public class DisplayNameAttribute : Attribute, IBaseAttribute
    {
        public DisplayNameAttribute(string value)
        {
            this._value = value;
        }

        #region IBaseAttribute Members

        private object _value;
        public object Value
        {
            get { return _value; }
        }

        #endregion
    }
    public static partial class EnumExtensions
    {
        public static string GetDisplayNameAttributeValue(this Enum value)
        {
            var result = GetAttributeValue<DisplayNameAttribute>(value);

            if (result == null)
                return null;

            return result.ToString();
        }
    }
}