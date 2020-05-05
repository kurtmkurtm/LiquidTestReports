using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DotLiquid;
using DotLiquid.Util;

namespace LiquidTestReports.Core.Filters
{
    /// <summary>
    /// Extended filters for arrays.
    /// </summary>
    public static class ArrayFilters
    {
        /// <summary>
        /// Filter array on a given property where values match.
        /// </summary>
        /// <param name="input">The enumerable.</param>
        /// <param name="property">The property to map.</param>
        /// <param name="values">Values to filter with.</param>
        /// <returns>Filtered IEnumerable.</returns>
        public static IEnumerable Where(object input, string property, string values)
        {
            if (input == null || string.IsNullOrEmpty(property) || string.IsNullOrEmpty(values))
            {
                return null;
            }

            var filter = values.Split('|');

            List<object> inputList;
            if (input is IEnumerable<Hash> enumerableHash)
            {
                inputList = enumerableHash.Cast<object>().ToList();
            }
            else if (input is IEnumerable enumerableInput)
            {
                inputList = enumerableInput.Flatten().Cast<object>().ToList();
            }
            else
            {
                inputList = new List<object>(new[] { input });
            }

            if (!inputList.Any())
            {
                return inputList;
            }

            if (string.IsNullOrEmpty(property))
            {
                inputList.Sort();
            }
            else if (inputList.All(o => o is IDictionary) && inputList.Any(o => ((IDictionary)o).Contains(property)))
            {
                var filtered = inputList.Where(a => filter.Any(f => ((IDictionary)a)[property].Equals(f)));
                return filtered;
            }
            else if (inputList.All(o => o.RespondTo(property)))
            {
                var filtered = inputList.Where(a => filter.Any(f => a.Send(property).Equals(f)));
                return filtered;
            }

            return inputList;
        }

        // Modified version of dotliquid extension to ignore case for member name
        private static bool RespondTo(this object value, string member, bool ensureNoParameters = true)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            Type type = value.GetType();

            MethodInfo methodInfo = type.GetRuntimeMethod(member, Type.EmptyTypes);
            if (methodInfo != null && (!ensureNoParameters || !methodInfo.GetParameters().Any()))
            {
                return true;
            }

            PropertyInfo propertyInfo = type.GetProperty(member, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            if (propertyInfo != null && propertyInfo.CanRead)
            {
                return true;
            }

            return false;
        }

        // Modified version of dotliquid extension to ignore case for member name
        private static object Send(this object value, string member, object[] parameters = null)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            Type type = value.GetType();

            MethodInfo methodInfo = type.GetRuntimeMethod(member, Type.EmptyTypes);
            if (methodInfo != null)
            {
                return methodInfo.Invoke(value, parameters);
            }

            PropertyInfo propertyInfo = type.GetProperty(member, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            if (propertyInfo != null)
            {
                return propertyInfo.GetValue(value, null);
            }

            return null;
        }
    }
}
