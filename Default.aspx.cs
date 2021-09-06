using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using System.Data;
using System.Globalization;

namespace api_project
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
           if (!IsPostBack)
            {
                ddlPais.DataSource = countries();
                ddlPais.DataBind();
            }
       

        }

        protected void ddlPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            string country = ddlPais.SelectedItem.Text;
            country.ToLower();
            country= country.Replace(" ", "-");
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            string jasonUniversidades = (new WebClient()).DownloadString("http://universities.hipolabs.com/search?country=" + country);
            

            gvDatos.DataSource = JsonConvert.DeserializeObject<DataTable>(jasonUniversidades);
            gvDatos.DataBind();

        }

        
        public static List<string> countries()
        {
            List<string> list= new List<string>();
            CultureInfo[] getCultureInfo = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
            foreach (CultureInfo item in getCultureInfo)
            {
                RegionInfo region = new RegionInfo(item.LCID);
                if (!(list.Contains(region.EnglishName))){
                    list.Add(region.EnglishName);
                   
                }
            }
            list.Sort();
            return list;

        }

        protected void gvDatos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}