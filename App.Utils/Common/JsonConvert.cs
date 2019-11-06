using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Utils.Common
{
    public static class JsonConvert
    {
        /// <summary>
        /// convert 1 đối tượng sang string json
        /// </summary>
        /// <param name="obj">đối tượng cần chuyển đổi</param>
        /// <returns>string json</returns>
        public static string SerializeObject(this object obj)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(obj,Formatting.None,new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
        }

        /// <summary>
        /// convert từ string json sang đối tượng
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu muốn convert</typeparam>
        /// <param name="value">string json</param>
        /// <returns>Kiểu dữ liệu muốn convert</returns>
        public static T DeserializeObject<T>(this string value)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(value);
        }
    }
}
