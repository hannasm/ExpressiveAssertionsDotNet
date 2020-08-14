using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExpressiveAssertions.Rendering
{
    static class TypeBasedParamterNameGenerator
    {
        static Regex _nameRule = new Regex("^[A-Za-z0-9.]*$");
        static string getName(string prefix, HashSet<string> existingNames)
        {
            for (int i = 1; i < 100; i++)
            {
                var testName = prefix + "_" + i.ToString("00");
                if (!existingNames.Contains(testName))
                {
                    existingNames.Add(testName);
                    return testName;
                }
            }
            throw new Exception("Unable to generate name for prefix " + prefix);
        }

        public static string GetName(Type t, HashSet<string> existingNames, int? maxLength = null)
        {
            if (maxLength < 5) { maxLength = 5; }
            var typeName = t.Name;
            if (typeName.Length > maxLength)
            {
                typeName = typeName.Substring(0, (maxLength.Value-3)/2) + "..." + typeName.Substring(typeName.Length - ((maxLength.Value-3)/2));
            }
            typeName = typeName.ToLowerInvariant();
            if (_nameRule.IsMatch(typeName))
            {
                typeName = getName(typeName, existingNames);
            }
            else
            {
                typeName = getName("v", existingNames);
            }

            return typeName;
        }
    }
}
