using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Twitstagram.Controllers
{
    public class HomeController : Controller
    {

    public ActionResult Index()
        {

            var twitter = new Twitter.Twitter("4rNfhgUrI6yklSBVhmU3U1F8q", "kYsjQzU7QVof9USCQHucFi3p2ox61q2GxNVYcDSzTiBzu0C0vT", "1001781311051390978-Tj0aXHjC3GSuqGFde9AFp6z9Wjp4i2", "BxYSpsScwSW9oxMIozpYpNv7efJhXIihvXduGgUU32S3K");

            //twitter.PostStatusUpdate(status, 54.35,-0.2);
            var response = twitter.GetTweets("romybos_", 5);

            dynamic timeline = System.Web.Helpers.Json.Decode(response);

            foreach (var tweet in timeline)
            {
                string text = timeLineMention["text"].ToString();
                Models.Home.TimeLine.Add(text);
            }

            return View();
        }  

    }

}