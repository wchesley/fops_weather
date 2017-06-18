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

            var sql = "";
            
            var output = "<table>";
            output += "<tr>";
            output += "<th>Current Temperature </th>";
            output += $"<td>{weather_response.current_observation.temperature_string}</td>";
            output += "</tr><tr>"; 
            output +="<th>Wind Speed</th>";
            output +=$"<td>{weather_response.current_observation.wind_string}</td";
            output +="</tr>";
            output += "</table>";    
        }

        protected void FetchNewData(string city)
        {
            string city = txt_city;
            string api = "http://api.wunderground.com/api/047d1a51849f71a0/conditions/q/TX/";
            string ApiAddr = api + city + ".json";
            var weather_request = string.Empty;
            using (var client = new WebClient())
            {
                try
                {
                    weather_request = client.DownloadString(ApiAddr);

                }
                catch
                {

                }
            }
            RootObject weather_response = JsonConvert.DeserializeObject<RootObject>(weather_request);
        }
    }
}
