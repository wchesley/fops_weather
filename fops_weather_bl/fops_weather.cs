using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json; 

namespace fops_weather_bl
{
    public partial class fops_weather : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //Check db first, if record in Db is greater than
            //one hour old, fetch new request, 
            //if record is less than one hour, display record. 

                
        }

        protected void FetchNewData(string city)
        {
            city = txt_city; //taken from btn on webpage. 
            string api = "http://api.wunderground.com/api/047d1a51849f71a0/conditions/q/TX/";
            string ApiAddr = api + city + ".json";
            var weather_request = string.Empty;
            using (var client = new WebClient())
            {
                try
                {
                    //fetches new request, saves to database
                    weather_request = client.DownloadString(ApiAddr);
                    WeatherData.SaveWeather(weather_request);
                }
                catch
                {

                }
            }
            //display most recent request from database for specified city. 
            string htmlTable = WeatherData.GetWeather_DB(city);
        }
    }
}
