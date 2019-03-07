using APIXULib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APIXUWebSample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult GetWeather(string[] city)
        {
            List<WeatherModel> listOfCities = new List<WeatherModel>();
            if (city == null) {
                return Json(listOfCities, JsonRequestBehavior.AllowGet);
            }
            else
            {
                foreach (var City in city)
                {
                    string key = "eb2a0633229b456ba6093557151106";
                    IRepository repo = new Repository();
                    if (City == "")
                    {
                        //DO NOTHING
                    }
                    else
                    {
                        var GetCityForecastWeatherResult = repo.GetWeatherData(key, GetBy.CityName, City, Days.Three);
                        if (GetCityForecastWeatherResult.current == null && GetCityForecastWeatherResult.location == null)
                        {
                            //DO NOTHING - IF CANT FIND CITY/COUNTRY
                        }
                        else
                        {
                            listOfCities.Add(GetCityForecastWeatherResult);
                        }
                    }
                }
                return Json(listOfCities, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}