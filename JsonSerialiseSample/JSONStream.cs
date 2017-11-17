using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace JsonSerialiseSample
{
   public static class JSONStream
    {
        public static T CreateFromJsonStream<T>(Stream stream)
        {
            JsonSerializer serializer = new JsonSerializer();
            T data;
            using (StreamReader streamReader = new StreamReader(stream))
            {
                data = (T)serializer.Deserialize(streamReader, typeof(T));
            }
            return data;
        }

        public static List<Employee> DeseriliseData(string serialisedString)
        {
            using (MemoryStream stream = new MemoryStream(System.Text.Encoding.Default.GetBytes(serialisedString)))
            {
                return CreateFromJsonStream<List<Employee>>(stream);
            }
        }


    }
}
