using Newtonsoft.Json;

namespace PersonalityTest.Infrasturcture
{
    public static class ExtensionMethods
    {
        public static T? DeepCopy<T>(this object obj)
        {
            if (obj == null)
            {
                return default;
            }

            var serialize = JsonConvert.SerializeObject(obj);
            var returnObject = JsonConvert.DeserializeObject<T>(serialize);
            return returnObject;
        }
    }
}
