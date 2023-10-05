using Newtonsoft.Json.Linq;

namespace TallerBiblioteca.Infrastructure.Common.JSON
{
    public static partial class Extensions
    {
        public static T GetOptional<T>(this JToken pJson, string pKey, T pDefault)
        {
            if (((JObject)pJson).ContainsKey(pKey))
            {
                return pJson.Value<T>(pKey);
            }

            return pDefault;
        }

        public static T GetOptional<T>(this JObject pJson, string pKey, T pDefault)
        {
            if (pJson.ContainsKey(pKey))
            {
                return pJson.Value<T>(pKey);
            }

            return pDefault;
        }

        public static JObject GetOptionalObject(this JObject pJson, string pKey)
        {
            return (JObject)GetOptional(pJson, pKey, new JObject());
        }
    }
}
