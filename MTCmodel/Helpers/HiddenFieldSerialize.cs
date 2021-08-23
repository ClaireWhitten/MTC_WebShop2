using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Newtonsoft.Json;
namespace MTCmodel.Helpers
{
    public static class HiddenFieldSerialize
    {
        /// <summary>
        /// Deserialize a value from a hidden HTML Form field which was serialized
        /// with SerializeForHidden to its original type.
        /// </summary>
        /// <typeparam name="T">Type to deserialize to</typeparam>
        /// <param name="value">serialized and HtmlEncoded string from HTML form</param>
        /// <param name="_">Target property only used to simplify detection of T. May be null.</param>
        /// <returns>Deserialized object or null when value was null or empty</returns>
        public static T DeserializeForHidden<T>(this string value, T _)
        {
            if (string.IsNullOrEmpty(value))
                return default;

            return JsonConvert.DeserializeObject<T>(HttpUtility.HtmlDecode(value));
        }

        /// <summary>
        /// Serialize a complex value (like a List) to be stored in a hidden HTML Form field
        /// </summary>
        /// <param name="value">Value to serialize</param>
        /// <returns>Json serialized and HtmlEncoded string</returns>
        public static string SerializeForHidden(this object value)
        {
            if (value == null)
                return null;

            return HttpUtility.HtmlEncode(JsonConvert.SerializeObject(value,
                new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore }));
        }
    }
}
