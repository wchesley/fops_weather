using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using Newtonsoft.Json;

//Written By: Walker Chesley
//06/16/2017

    //last edit: 06/18/2017


namespace fops_weather_bl
{

    //Class for DB stuff. 
    public class WeatherData
    {
        //location for SQL DB 
        const string db_string = "sql database string";
        

        //This method accepts the JSON response directly, then saves date to the databse. 
        public static void SaveWeather(string Json_response)
        {
            //Ready SQL connection, assign DB path 
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = db_string;


            //grabbing data from JsonResponse Class. 
            RootObject WeatherData = JsonConvert.DeserializeObject<RootObject>(Json_response);

            //set up SQL query statement
            string query = "INSERT INTO * (city, zip, weather, temperature_string, temperature_f, temperature_c, relative_humidity, wind_string, wind_dir, wind_degrees, wind_mph, wind_gust_mph, wind_kph, wind_gust_kph, pressure_mb, pressure_in, pressure_trend, dewpoint_string, dewpoint_f, dewpoint_c, heat_index_string, heat_index_f, heat_index_c, windchill_string, windchill_f, windchill_c, feelslike_string, feelslike_f, feelslike_c, visibility_mi, visibility_km, solarradiation, UV, precip_1hr_string, precip_1hr_in, precip_1hr_metric, precip_today_string, precip_today_in, precip_today_metric, icon, icon_url, forecast_url, history_url, ob_url, nowcast)";
            query += "VALUES (@city, @zip, @weather, @temperature_string, @temperature_f, @temperature_c, @relative_humidity, @wind_string, @wind_dir, @wind_degrees, @wind_mph, @wind_gust_mph, @wind_kph, @wind_gust_kph, @pressure_mb, @pressure_in, @pressure_trend, @dewpoint_string, @dewpoint_f, @dewpoint_c, @heat_index_string, @heat_index_f, @heat_index_c, @windchill_string, @windchill_f, @windchill_c, @feelslike_string, @feelslike_f, @feelslike_c, @visibility_mi, @visibility_km, @solarradiation, @UV, @precip_1hr_string, @precip_1hr_in, @precip_1hr_metric, @precip_today_string, @precip_today_in, @precip_today_metric, @icon, @icon_url, @forecast_url, @history_url, @ob_url, @nowcast)";

            using (SqlCommand addNewWeather = conn.CreateCommand())
            {

                //adding value to sql params. 

                addNewWeather.Parameters.AddWithValue("@city", WeatherData.current_observation.display_location.city);

                addNewWeather.Parameters.AddWithValue("@zip", WeatherData.current_observation.display_location.zip);

                addNewWeather.Parameters.AddWithValue("@weather", WeatherData.current_observation.weather);

                addNewWeather.Parameters.AddWithValue("@temperature_string", WeatherData.current_observation.temperature_string);

                addNewWeather.Parameters.AddWithValue("@temperature_f", WeatherData.current_observation.temp_f);

                addNewWeather.Parameters.AddWithValue("@temperature_c", WeatherData.current_observation.temp_c);

                addNewWeather.Parameters.AddWithValue("@relative_humidity", WeatherData.current_observation.relative_humidity);

                addNewWeather.Parameters.AddWithValue("@wind_string", WeatherData.current_observation.wind_string);

                addNewWeather.Parameters.AddWithValue("@wind_dir", WeatherData.current_observation.wind_dir);

                addNewWeather.Parameters.AddWithValue("@wind_degrees", WeatherData.current_observation.wind_degrees);

                addNewWeather.Parameters.AddWithValue("@wind_mph", WeatherData.current_observation.wind_mph);

                addNewWeather.Parameters.AddWithValue("@wind_gust_mph", WeatherData.current_observation.wind_gust_mph);

                addNewWeather.Parameters.AddWithValue("@wind_kph", WeatherData.current_observation.wind_kph);

                addNewWeather.Parameters.AddWithValue("@wind_gust_kph", WeatherData.current_observation.wind_gust_kph);

                addNewWeather.Parameters.AddWithValue("@pressure_mb", WeatherData.current_observation.pressure_mb);

                addNewWeather.Parameters.AddWithValue("@pressure_in", WeatherData.current_observation.pressure_in);

                addNewWeather.Parameters.AddWithValue("@pressure_trend", WeatherData.current_observation.pressure_trend);

                addNewWeather.Parameters.AddWithValue("@dewpoint_string", WeatherData.current_observation.dewpoint_string);

                addNewWeather.Parameters.AddWithValue("@dewpoint_f", WeatherData.current_observation.dewpoint_f);

                addNewWeather.Parameters.AddWithValue("@dewpoint_c", WeatherData.current_observation.dewpoint_c);

                addNewWeather.Parameters.AddWithValue("@heat_index_string", WeatherData.current_observation.heat_index_string);

                addNewWeather.Parameters.AddWithValue("@heat_index_f", WeatherData.current_observation.heat_index_f);

                addNewWeather.Parameters.AddWithValue("@heat_index_c", WeatherData.current_observation.heat_index_c);

                addNewWeather.Parameters.AddWithValue("@windchill_string", WeatherData.current_observation.windchill_string);

                addNewWeather.Parameters.AddWithValue("@windchill_f", WeatherData.current_observation.windchill_f);

                addNewWeather.Parameters.AddWithValue("@windchill_c", WeatherData.current_observation.windchill_c);

                addNewWeather.Parameters.AddWithValue("@feelslike_string", WeatherData.current_observation.feelslike_string);

                addNewWeather.Parameters.AddWithValue("@feelslike_f", WeatherData.current_observation.feelslike_f);

                addNewWeather.Parameters.AddWithValue("@feelslike_c", WeatherData.current_observation.feelslike_c);

                addNewWeather.Parameters.AddWithValue("@visibility_mi", WeatherData.current_observation.visibility_mi);

                addNewWeather.Parameters.AddWithValue("@visibility_km", WeatherData.current_observation.visibility_km);

                addNewWeather.Parameters.AddWithValue("@solarradiation", WeatherData.current_observation.solarradiation);

                addNewWeather.Parameters.AddWithValue("@UV", WeatherData.current_observation.UV);

                addNewWeather.Parameters.AddWithValue("@precip_1hr_string", WeatherData.current_observation.precip_1hr_string);

                addNewWeather.Parameters.AddWithValue("@precip_1hr_in", WeatherData.current_observation.precip_1hr_in);

                addNewWeather.Parameters.AddWithValue("@precip_1hr_metric", WeatherData.current_observation.precip_1hr_metric);

                addNewWeather.Parameters.AddWithValue("@precip_today_string", WeatherData.current_observation.precip_today_string);

                addNewWeather.Parameters.AddWithValue("@precip_today_in", WeatherData.current_observation.precip_today_in);

                addNewWeather.Parameters.AddWithValue("@precip_today_metric", WeatherData.current_observation.precip_today_metric);

                addNewWeather.Parameters.AddWithValue("@icon", WeatherData.current_observation.icon);

                addNewWeather.Parameters.AddWithValue("@icon_url", WeatherData.current_observation.icon_url);

                addNewWeather.Parameters.AddWithValue("@forecast_url", WeatherData.current_observation.forecast_url);

                addNewWeather.Parameters.AddWithValue("@history_url", WeatherData.current_observation.history_url);

                addNewWeather.Parameters.AddWithValue("@ob_url", WeatherData.current_observation.ob_url);

                addNewWeather.Parameters.AddWithValue("@nowcast", WeatherData.current_observation.nowcast);

                conn.Open(); //init connection to SQL DB
                try
                {
                    //Save the data
                    addNewWeather.ExecuteNonQuery();
                }
                catch
                {

                }
                //release connection to SQL DB
                conn.Close();

            }
        }
    }
}
