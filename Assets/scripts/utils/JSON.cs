using System.Collections.Generic;
using JsonFx.Json;
using JsonFx.Serialization;
using System;
using System.Linq;

public class JSON
{
    static JsonReader reader = new JsonReader ();

    public static TReturn Parse<TReturn> (string _source) where TReturn : class
    {
        return reader.Read (_source) as TReturn;
    }

    public static Dictionary<string, object> Parse (string _source)
    {
        return reader.Read <Dictionary<string, object>> (_source);
    }

    public static string Stringify (object _data)
    {
        var jsonSettings = new DataWriterSettings ();
        jsonSettings.PrettyPrint = true;
        return new JsonWriter (jsonSettings).Write (_data);
    }

    public static TReturnType Get<TReturnType> (string _key, Dictionary<string, object> _source)
    {
        var path = _key.Split ('.');
        Dictionary<string, object> ptr = _source;
        for (var i = 0; i < path.Length; i++) {
            var key = path [i];
            object value;
            if (!ptr.TryGetValue (key, out value)) {
                var failedPath = String.Join (".", path.ToList ().GetRange (0, i + 1).ToArray ());
                throw new MissingFieldException (string.Format ("Missed required config field: \"{0}\"", failedPath));
            }
            if (i == path.Length - 1)
                return (TReturnType)value;
            else
                ptr = (Dictionary<string, object>)value;
        }
        throw new MissingFieldException (string.Format ("Missed required config field: \"{0}\"", _key));
    }
}