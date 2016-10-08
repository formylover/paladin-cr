using Styx.WoWInternals;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Paladin.CRUtilities
{
    public static class SettingsUtilities
    {
        public static Dictionary<int, Tuple<bool, string, string, string>> GetPropertyDictionary(Styx.Helpers.Settings objectType)
        {
            var retval = new Dictionary<int, Tuple<bool, string, string, string>>();

            var propertyList = objectType.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

            if (propertyList != null)
            {
                foreach (var propertyInfo in propertyList)
                {
                    if (
                        Attribute.IsDefined(propertyInfo, typeof(SettingCategoryNameAttribute)) &&
                        Attribute.IsDefined(propertyInfo, typeof(SettingGroupNameAttribute)) &&
                        Attribute.IsDefined(propertyInfo, typeof(SettingSpellIDAttribute))
                        )
                    {
                        var spellID = GetSpellIDAttributeValue(propertyInfo);
                        var displayName = GetSettingNameAttributeValue(propertyInfo, spellID);
                        var categoryName = GetCategoryNameAttributeValue(propertyInfo);
                        var groupName = GetGroupNameAttributeValue(propertyInfo);
                        var propertyValue = (bool)propertyInfo.GetValue(objectType);

                        retval.Add(spellID, new Tuple<bool, string, string, string>(propertyValue, displayName, categoryName, groupName));

                    }
                }
            }

            return retval;
        }

        public static void SetPropertyValue(Styx.Helpers.Settings objectType, bool value, int spellID)
        {
            var propertyList = objectType.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

            if (propertyList != null)
            {
                foreach (var propertyInfo in propertyList)
                {
                    if (!Attribute.IsDefined(propertyInfo, typeof(SettingSpellIDAttribute)))
                    {
                        continue;
                    }
                    var spell = GetSpellIDAttributeValue(propertyInfo);
                    if (spell == spellID)
                    {
                        propertyInfo.SetValue(objectType, value);
                        return;
                    }
                }
            }
        }

        private static int GetSpellIDAttributeValue(PropertyInfo value)
        {
            var attributeInstance = Attribute.GetCustomAttribute(value, typeof(SettingSpellIDAttribute));
            if (attributeInstance != null)
            {
                foreach (PropertyInfo info in typeof(SettingSpellIDAttribute).GetProperties())
                {
                    if (info.CanRead && string.Compare(info.Name, "Value", StringComparison.InvariantCultureIgnoreCase) == 0)
                    {
                        return (int)info.GetValue(attributeInstance, null);
                    }
                }
            }
            return 0;
        }

        private static string GetCategoryNameAttributeValue(PropertyInfo value)
        {
            var attributeInstance = Attribute.GetCustomAttribute(value, typeof(SettingCategoryNameAttribute));
            if (attributeInstance != null)
            {
                foreach (PropertyInfo info in typeof(SettingCategoryNameAttribute).GetProperties())
                {
                    if (info.CanRead && string.Compare(info.Name, "Value", StringComparison.InvariantCultureIgnoreCase) == 0)
                    {
                        return info.GetValue(attributeInstance, null).ToString();
                    }
                }
            }
            return string.Empty;
        }

        private static string GetGroupNameAttributeValue(PropertyInfo value)
        {
            var attributeInstance = Attribute.GetCustomAttribute(value, typeof(SettingGroupNameAttribute));
            if (attributeInstance != null)
            {
                foreach (PropertyInfo info in typeof(SettingGroupNameAttribute).GetProperties())
                {
                    if (info.CanRead && string.Compare(info.Name, "Value", StringComparison.InvariantCultureIgnoreCase) == 0)
                    {
                        return info.GetValue(attributeInstance, null).ToString();
                    }
                }
            }
            return string.Empty;
        }

        private static string GetSettingNameAttributeValue(PropertyInfo value, int spellID)
        {
            var attributeInstance = Attribute.GetCustomAttribute(value, typeof(SettingNameAttribute));
            if (attributeInstance != null)
            {
                foreach (PropertyInfo info in typeof(SettingNameAttribute).GetProperties())
                {
                    if (info.CanRead && string.Compare(info.Name, "Value", StringComparison.InvariantCultureIgnoreCase) == 0)
                    {
                        var spell = WoWSpell.FromId(spellID);

                        if (spell == null)
                        {
                            Helpers.Logger.PrintLog("Spell with ID " + spellID + " not found");
                            return string.Empty;
                        }

                        return spell.LocalizedName + " (" + info.GetValue(attributeInstance, null).ToString() + ")";
                    }
                }
            }
            return string.Empty;
        }
    }
}
