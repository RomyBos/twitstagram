using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using Twitstagram.Models;

namespace Twitstagram.Controllers
{
    public class HomeController : Controller
    {


        public ActionResult Index()
        {

            var twitter = new Twitter.Twitter("4rNfhgUrI6yklSBVhmU3U1F8q", "kYsjQzU7QVof9USCQHucFi3p2ox61q2GxNVYcDSzTiBzu0C0vT", "1001781311051390978-Tj0aXHjC3GSuqGFde9AFp6z9Wjp4i2", "BxYSpsScwSW9oxMIozpYpNv7efJhXIihvXduGgUU32S3K");
            string user = "bencom_group";

            var response = twitter.GetTweets(user, 5);

            List<string> TimeLine = new List<string>();

            dynamic timeline = System.Web.Helpers.Json.Decode(response);


            

            foreach (dynamic tweet in timeline)
            {
                string text = tweet.text;
                TimeLine.Add(text);

            }

            string twitterfeed = string.Join(System.Environment.NewLine, TimeLine);

            ViewBag.Header = "@" + user;
            ViewBag.Message = (twitterfeed);

            return View();
        } 



    }

}