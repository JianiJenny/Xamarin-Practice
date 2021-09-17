using System;
using Couchbase.Lite;
using Newtonsoft.Json;

namespace FCBHXamarin.DataAccess.Document_Extensions
{
    public static class DocumentExtensions
    {
        //Takes a document from couchbase local and turns it into an object
        public static T ToObject<T>(this Document document)
        {
            T obj = default(T);

            try
            {
                if (document != null)
                {
                    if (document.ToDictionary()?.Count > 0)
                    {
                        //This makes sure we get polymorphic lists
                        var settings = new JsonSerializerSettings
                        {
                            TypeNameHandling = TypeNameHandling.Auto,
                            MetadataPropertyHandling = MetadataPropertyHandling.ReadAhead
                        };

                        var dictionary = document.ToMutable()?.ToDictionary();

                        if (dictionary != null)
                        {
                            var json = JsonConvert.SerializeObject(dictionary);

                            if (!string.IsNullOrEmpty(json))
                            {
                                obj = JsonConvert.DeserializeObject<T>(json, settings);
                            }
                        }
                    }
                    else
                    {
                        obj = Activator.CreateInstance<T>();
                    }
                }
            }
            catch
            {
                // ignored
            }

            return obj;
        }
    }
}
