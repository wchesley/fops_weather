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
        const string server_string = "Server=[server_name];Database=[database_name];Trusted_Connection=[true];";

        string db_name = ""; //to allow dynamic selection of db Table?

        //variables for temp storage, to be pushed ot webpage 
        public string temperature_string { get; set; }
        public string wind_string { get; set; }
        public string precip_today_string { get; set; }
        public string precip_1hr_string { get; set; }
        public string feelslike_string { get; set; }
        public string weather { get; set; }
        public string observation_time { get; set; }
        public string city { get; set; }
        public string forecast_url { get; set; }
        double timeframe = 1.00;


        //This method accepts the JSON response directly, then saves date to the databse. 
        public static void SaveWeather(string Json_response)
        {
            //currently set up for Wunderground API 
            //Ready SQL connection, assign DB path 
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = server_string; 


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
      

        //Read data from DB, displays as HTML table
        public static string GetWeather_DB(string CITY_TABLE)
        {
            //Currently for Wunderground API 
            string db_name = CITY_TABLE;
            string output_table = "";
            var sql = $"SELECT * FROM {db_name} ORDER BY 'date added' DESC LIMIT 1";
            using (SqlConnection conn = new SqlConnection(server_string))
            {

                conn.Open();
                using (SqlCommand read_command = new SqlCommand(sql, conn))
                using (SqlDataReader read_weather = read_command.ExecuteReader())
                {
                    if (read_weather != null)
                    {
                        while (read_weather.Read())
                        {
                            string temperature_string = read_weather["temperature_string"].ToString();
                            string wind_string = read_weather["wind_string"].ToString();
                            string precip_today_string = read_weather["precip_today_string"].ToString();
                            string precip_1hr_string = read_weather["precip_1hr_string"].ToString();
                            string feelslike_string = read_weather["feelslike_string"].ToString();
                            string city = read_weather["city"].ToString();
                            string forecast_url = read_weather["forecast_url"].ToString();
                            string observation_time = read_weather["observation_time"].ToString();
                            string weather = read_weather["weather"].ToString();

                            output_table = DisplayWeather(temperature_string, precip_1hr_string, precip_today_string, observation_time, feelslike_string, wind_string, weather, city, forecast_url);
                        }
                    }
                    else // read_weather == null 
                    {
                        output_table = "<p>No Data Returned</p>";
                    }
                }
            }
            return output_table;
        }

        public static string DisplayWeather(string temperature_string, string precip_1hr_string, string precip_today_string, string observation_time, string feelslike_string, string weather, string wind_string, string city, string forecast_url)
        {
            //push results to webpage as HTML table 
            string output = "<table>";
            output += "<tr>";
            output += "<th>Current Weather</th>";
            output += $"<td>{feelslike_string}</td>";
            output += "</tr>";
            output += "<tr>";
            output += "<th>Temperature</th>";
            output += $"<td>{temperature_string}</td>";
            output += "</tr>";
            output += "<tr>";
            output += "<th>Rainfall today</th>";
            output += $"<td>{precip_today_string}</td>";
            output += "</tr>";
            output += "<tr>";
            output += "<th>Rainfall in the past hour</th>";
            output += $"<td>{precip_1hr_string}</td>";
            output += "</tr>";
            output += "<tr>";
            output += "<th>Wind</th>";
            output += $"<th>{wind_string}</th>";
            output += "</tr>";
            output += "<tr>";
            output += "<th>Weather</th>";
            output += $"<td>{weather}</td>";
            output += "</tr>";
            output += "<tr>";
            output += "<th>Observed Time</th>";
            output += $"<tr>{observation_time}</tr>";
            output += "</tr>";
            output += "<tr>";
            output += "<th>Forecast URL</th>";
            output += $"<tr>{forecast_url}</tr>";
            output += "</tr>";
            output += "</table>";

            return output;
        }




    }
}
