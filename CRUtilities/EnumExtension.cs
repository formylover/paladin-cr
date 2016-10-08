using System;
using System.Linq;

namespace Paladin.CRUtilities
{
    public static partial class EnumExtensions
    {
        private static object GetAttributeValue<T>(Enum value) where T : IBaseAttribute
        {
            if (!Enum.IsDefined(value.GetType(), value))
                throw new ArgumentOutOfRangeException("value", "value is not defined by the enum.");

            var refTypeFieldInfo = value.GetType().GetField(Enum.GetName(value.GetType(), value));
            var customAttribute = refTypeFieldInfo.GetCustomAttributes(typeof(T), false).FirstOrDefault();

            var attr = customAttribute as IBaseAttribute;

            if (attr == null)
                throw new InvalidOperationException(typeof(T).Name + " not found.");

            return attr.Value;
        }
    }
}