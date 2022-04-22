// ----------------------------------------------------------------------------
// Simulering av Dykkerpost
// Bachelor Oppgave våren 2022
// 
// Aahed Diyab, Olav Pete
// ----------------------------------------------------------------------------

using Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using XNode;
using System.Linq;
using System.Text;

namespace Core
{
    public static class Extensions
    {
        public static string Base64Encode(this string text)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(text));
        }

        public static string Base64Decode(this string encoded)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(encoded));
        }

        public static string Compose(this object data)
        {
            return JsonConvert.SerializeObject(data);
        }

        public static string Compose(this (object, object) data)
        {
            return JsonConvert.SerializeObject(data);
        }

        public static string Compose(this (object, object, object) data)
        {
            return JsonConvert.SerializeObject(data);
        }

        public static string Compose(this (object, object, object, object) data)
        {
            return JsonConvert.SerializeObject(data);
        }

        public static string Compose(this (object, object, object, object, object) data)
        {
            return JsonConvert.SerializeObject(data);
        }

        public static object GetOutputValue(this NodePort port)
        {
            return port.Connection != null ? GetInputValue(port.Connection) : null;
        }

        public static object[] GetOutputValues(this NodePort port)
        {
            object[] array = new object[port.ConnectionCount];
            for (int i = 0; i < port.ConnectionCount; i++)
            {
                NodePort other = port.GetConnections()[i];
                array[i] = other != null ? GetInputValue(other) : null;
            }
            return array;
        }

        public static T GetOutputValue<T>(this NodePort port)
        {
            object outputValue = GetOutputValue(port);
            return (outputValue is T t) ? t : default;
        }

        public static T[] GetOutputValues<T>(this NodePort port)
        {
            object[] outputValues = GetOutputValues(port);
            T[] result = new T[outputValues.Length];
            for (int i = 0; i < outputValues.Length; i++)
            {
                if (outputValues[i] is T) result[i] = (T)outputValues[i];
            }
            return result;
        }

        public static object GetInputValue(this NodePort port)
        {
            if (port.direction == NodePort.IO.Output)
            {
                return null;
            }
            return port.node.GetValue(port);
        }

        public static T Parse<T>(this string data)
        {
            return JsonConvert.DeserializeObject<T>(data, new Converter<T>());
        }

        public static (T1,T2) Parse<T1, T2>(this string data)
        {
            return JsonConvert.DeserializeObject<(T1, T2)>(data, new Converter<T1,T2>());
        }

        public static (T1, T2, T3) Parse<T1, T2, T3>(this string data)
        {
            return JsonConvert.DeserializeObject<(T1, T2, T3)>(data, new Converter<T1, T2, T3>());
        }

        public static (T1, T2, T3, T4) Parse<T1, T2, T3, T4>(this string data)
        {
            return JsonConvert.DeserializeObject<(T1, T2, T3, T4)>(data, new Converter<T1, T2, T3, T4>());
        }

        public static (T1, T2, T3, T4, T5) Parse<T1, T2, T3, T4, T5>(this string data)
        {
            return JsonConvert.DeserializeObject<(T1, T2, T3, T4, T5)>(data, new Converter<T1, T2, T3, T4, T5>());
        }

        public class Converter<T> : JsonConverter
        {
            public override bool CanConvert(Type objectType)
            {
                return typeof(T).IsAssignableFrom(objectType);
            }

            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;

                var jobj = Newtonsoft.Json.Linq.JObject.Load(reader);
                var props = jobj.Properties().ToList();

                return jobj[props[0].Name].ToObject<T>();
            }

            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
            }
        }

        public class Converter<T1,T2> : JsonConverter
        {
            public override bool CanConvert(Type objectType)
            {
                return typeof((T1, T2)).IsAssignableFrom(objectType);
            }

            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;

                var jobj = Newtonsoft.Json.Linq.JObject.Load(reader);
                var props = jobj.Properties().ToList();

                return (jobj[props[0].Name].ToObject<T1>(), jobj[props[1].Name].ToObject<T2>());
            }

            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                serializer.Serialize(writer, value);
            }
        }

        public class Converter<T1, T2, T3> : JsonConverter
        {
            public override bool CanConvert(Type objectType)
            {
                return typeof((T1, T2, T3)).IsAssignableFrom(objectType);
            }

            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;

                var jobj = Newtonsoft.Json.Linq.JObject.Load(reader);
                var props = jobj.Properties().ToList();

                return (jobj[props[0].Name].ToObject<T1>(), jobj[props[1].Name].ToObject<T2>(), jobj[props[2].Name].ToObject<T3>());
            }

            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                serializer.Serialize(writer, value);
            }
        }

        public class Converter<T1, T2, T3, T4> : JsonConverter
        {
            public override bool CanConvert(Type objectType)
            {
                return typeof((T1, T2, T3, T4)).IsAssignableFrom(objectType);
            }

            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;

                var jobj = Newtonsoft.Json.Linq.JObject.Load(reader);
                var props = jobj.Properties().ToList();

                return (jobj[props[0].Name].ToObject<T1>(), jobj[props[1].Name].ToObject<T2>(), jobj[props[2].Name].ToObject<T3>(), jobj[props[3].Name].ToObject<T4>());
            }

            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                serializer.Serialize(writer, value);
            }
        }

        public class Converter<T1, T2, T3, T4, T5> : JsonConverter
        {
            public override bool CanConvert(Type objectType)
            {
                return typeof((T1, T2, T3, T4, T5)).IsAssignableFrom(objectType);
            }

            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;

                var jobj = Newtonsoft.Json.Linq.JObject.Load(reader);
                var props = jobj.Properties().ToList();

                return (jobj[props[0].Name].ToObject<T1>(), 
                    jobj[props[1].Name].ToObject<T2>(), 
                    jobj[props[2].Name].ToObject<T3>(), 
                    jobj[props[3].Name].ToObject<T4>(),
                    jobj[props[4].Name].ToObject<T5>());
            }

            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                serializer.Serialize(writer, value);
            }
        }
    }
}