using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UtilsLibrary
{
    public static class DataHelper
    {
        /// <summary>
        /// read json file with given TYPE content
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <returns>generic TYPE</returns>
        public static T JsonToDictionary<T>(string path)
        {
            try
            {
                FileStream fileStream = new FileStream(path, FileMode.Open);

                StreamReader streamReader = new StreamReader(fileStream);

                string jsonStr = streamReader.ReadToEnd();

                T result = JsonConvert.DeserializeObject<T>(jsonStr);

                streamReader.Dispose();
                fileStream.Dispose();

                return result;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.StackTrace);
                throw;
            }
        }


        /// <summary>
        /// convert json text stream to given TYPE content
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="stream"></param>
        /// <returns>generic TYPE</returns>
        public static T JsonToDictionary<T>(Stream stream)
        {
            try
            {
                StreamReader streamReader = new StreamReader(stream);

                string jsonStr = streamReader.ReadToEnd();

                T result = JsonConvert.DeserializeObject<T>(jsonStr);

                streamReader.Dispose();
                stream.Dispose();

                return result;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.StackTrace);
                throw;
            }
        }


        /// <summary>
        /// read json file and return JSON object
        /// </summary>
        /// <param name="path"></param>
        /// <returns>JSON object</returns>
        public static JObject JsonToObject(string path)
        {
            try
            {
                StreamReader streamReader = File.OpenText(path);

                JsonTextReader jsonReader = new JsonTextReader(streamReader);

                var tempJsonStream = JToken.ReadFrom(jsonReader);

                JObject jsonObject = (JObject)tempJsonStream.ToObject<object>();

                jsonReader.Close();
                streamReader.Dispose();

                return jsonObject;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.StackTrace);
                throw;
            }
        }


        /// <summary>
        /// convert json text stream to JSON object
        /// </summary>
        /// <param name="stream"></param>
        /// <returns>JSON object</returns>
        public static JObject JsonToObject(Stream stream)
        {
            try
            {
                StreamReader streamReader = new StreamReader(stream);

                JsonTextReader jsonReader = new JsonTextReader(streamReader);

                var tempJsonStream = JToken.ReadFrom(jsonReader);

                JObject jsonObject = (JObject)tempJsonStream.ToObject<object>();

                jsonReader.Close();
                streamReader.Dispose();
                stream.Dispose();

                return jsonObject;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.StackTrace);
                throw;
            }
        }
    }
}
