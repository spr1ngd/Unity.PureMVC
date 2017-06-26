
/*=========================================
* Author: SpringDong
* DateTime:2017/6/16 15:06:19
* Description: Serialize && Deserialize Json Help Class
==========================================*/

using System.IO;
using JsonFx.Json;

namespace SpringFramework
{
    /// <summary>
    /// JsonFx跨平台解析
    /// </summary>
    public static class JsonFxHelper 
    {
        /// <summary>
        /// 反序列化文件流
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static T Deserialize<T>( string filePath )
        {
            using ( TextReader reader = new StreamReader(filePath))
            {
                return JsonReader.Deserialize<T>(reader.ReadToEnd());
            }
        }

        /// <summary>
        /// 反序列化内存流
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="memory"></param>
        /// <returns></returns>
        public static T DeserializeMemory<T>( string memory )
        {
            return JsonReader.Deserialize<T>(memory);
        }

        /// <summary>
        /// 序列化内存流
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string Serialize<T>( T t )
        {
            return JsonWriter.Serialize(t);
        }

        /// <summary>
        /// 序列化文件流
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="filePath"></param>
        public static void Serialize<T>( T t , string filePath )
        {
            using (TextWriter writer = new StreamWriter(filePath))
            {
                string content = JsonWriter.Serialize(t);
                writer.Write(content);
            }
        }
    }
}
