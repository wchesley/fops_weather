using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using Newtonsoft.Json;


namespace fops_weather_bl
{
    public class WeatherData
    {
        const string db_string = "sql database string";
        
        public static void SaveWeather(string Json_response)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = db_string;
            conn.Open();
            RootObject WeatherData = JsonConvert.DeserializeObject<RootObject>(Json_response);

            using (SqlCommand addNewWeather = conn.CreateCommand())
            {
                string query = $"INSERT INTO * (city, zip, weather, temperature_string, temperature_f, temperature_c, relative_humidity, wind_string, wind_dir, wind_degrees, wind_mph, wind_gusy_mph)";
                query += ""; 
            }
        }
    }
}
