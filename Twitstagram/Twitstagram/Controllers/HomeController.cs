using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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

            return View();
        }

        // GET: TwitterSearch
        public ActionResult TwitterSearch()
        {
            var twitter = new Twitter.Twitter("4rNfhgUrI6yklSBVhmU3U1F8q",
                "kYsjQzU7QVof9USCQHucFi3p2ox61q2GxNVYcDSzTiBzu0C0vT",
                "1001781311051390978-Tj0aXHjC3GSuqGFde9AFp6z9Wjp4i2",
                "BxYSpsScwSW9oxMIozpYpNv7efJhXIihvXduGgUU32S3K");

            string p = "bencom";

            List<string> TimeLineSearch = new List<string>();
            var response = twitter.SearchTweets(p);

            dynamic timelinesearch = System.Web.Helpers.Json.Decode(response);
            //            user = form["username"].ToString();

            foreach (dynamic tweet in timelinesearch)
            {
                string text = tweet.text;
                TimeLineSearch.Add(text);
            }


            ViewBag.Header = p;
            ViewBag.Message = (TimeLineSearch);

            return View();
        }



        // GET: UserTimeLine
        public ActionResult UserTimeLine()
        {
            //TODO: Fix input form so user can search for user and amount, insteadc of hardcoded.

            var twitter = new Twitter.Twitter("4rNfhgUrI6yklSBVhmU3U1F8q",
                "kYsjQzU7QVof9USCQHucFi3p2ox61q2GxNVYcDSzTiBzu0C0vT",
                "1001781311051390978-Tj0aXHjC3GSuqGFde9AFp6z9Wjp4i2",
                "BxYSpsScwSW9oxMIozpYpNv7efJhXIihvXduGgUU32S3K");

            string user = "bencom_group";
            var response = twitter.GetTweets(user, 5);

            List<string> TimeLine = new List<string>();

            dynamic timeline = System.Web.Helpers.Json.Decode(response);
            //            user = form["username"].ToString();

            foreach (dynamic tweet in timeline)
            {
                string text = tweet.text;
                TimeLine.Add(text);
            }


            ViewBag.Header = "@" + user;
            ViewBag.Message = (TimeLine);

            return View();
        }
        //        [HttpPost]
        //        public ActionResult Index(FormCollection form)
        //        {


        //        }

    }


}