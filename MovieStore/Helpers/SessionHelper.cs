using Newtonsoft.Json;

namespace MovieStore.Helpers
{
    public static class SessionHelper
    {
        public static void Set<T>(this ISession session,string key,T value)
        {
            session.SetString(key,JsonConvert.SerializeObject(value));
        }
        public static T Get<T>(this ISession session,string key)
        {
            var Value=session.GetString(key);
            return Value == null ? default : JsonConvert.DeserializeObject<T>(Value);
        }
    }
}
