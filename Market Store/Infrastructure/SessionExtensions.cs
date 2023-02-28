using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Market_Store.Infrastructure
{
    public  static class SessionExtensions
    {//create setjason
        public static void SetJason(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        
        }
        //create getjason
        public static T GetJason<T>(this ISession session, string key)
        {
            var sessionData = session.GetString(key);
            return sessionData == null ? default(T) : JsonConvert.DeserializeObject<T>(sessionData);

        }
    }
}
