using System;
using System.Diagnostics;
using Newtonsoft.Json;

namespace Nutrimeal.Common
{
    public static class JsonExtentions
    {

        public static TJson FromJson<TJson>(this string jsonString)
        {
            try
            {
               
                return JsonConvert.DeserializeObject<TJson>(jsonString, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }

        public static string ToJson(this object objectToSave)
        {
            try
            {
                if (objectToSave == null) return null;
                var st = new JsonSerializerSettings { StringEscapeHandling = StringEscapeHandling.EscapeHtml };
                return JsonConvert.SerializeObject(objectToSave, Formatting.None, st);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }
    }
}