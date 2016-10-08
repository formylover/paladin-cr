using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paladin.CRUtilities
{
    [AttributeUsage(AttributeTargets.Property)]
    public class SettingCategoryNameAttribute : Attribute, IBaseAttribute
    {
        public SettingCategoryNameAttribute(string value)
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
}
