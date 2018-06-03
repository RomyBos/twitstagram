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

        public ActionResult UserLikes()
        {
            var twitter = new Twitter.Twitter("4rNfhgUrI6yklSBVhmU3U1F8q",
                "kYsjQzU7QVof9USCQHucFi3p2ox61q2GxNVYcDSzTiBzu0C0vT",
                "1001781311051390978-Tj0aXHjC3GSuqGFde9AFp6z9Wjp4i2",
                "BxYSpsScwSW9oxMIozpYpNv7efJhXIihvXduGgUU32S3K");

            string user = "gaslicht_com";
            int count = 5;
            var response = twitter.UserLikes(user, count);
            List<string> likes = new List<string>();
            dynamic tweets = System.Web.Helpers.Json.Decode(response);

            var homeModel = new Home()
            {
                Likes = likes
            };

            foreach (dynamic tweet in tweets)
            {
                string text = tweet.text;
                likes.Add(text);
            }


            ViewBag.Header = "@" + user;

            return View(homeModel);
        }


        public ActionResult UserTimeLine()
        {
            //TODO: Fix input form so user can search for user and amount, instead of hardcoded.


            var twitter = new Twitter.Twitter("4rNfhgUrI6yklSBVhmU3U1F8q",
                "kYsjQzU7QVof9USCQHucFi3p2ox61q2GxNVYcDSzTiBzu0C0vT",
                "1001781311051390978-Tj0aXHjC3GSuqGFde9AFp6z9Wjp4i2",
                "BxYSpsScwSW9oxMIozpYpNv7efJhXIihvXduGgUU32S3K");

            string user = "bencom_group";
            int count = 5;
            var response = twitter.GetTweets(user, count);
            List<string> timeLine = new List<string>();

            dynamic timeline = System.Web.Helpers.Json.Decode(response);

            var homeModel = new Home()
            {
                TimeLine = timeLine
            };

            foreach (dynamic tweet in timeline)
            {
                string text = tweet.text;
                timeLine.Add(text);
            }

            ViewBag.Header = "@" + user;

            return View(homeModel);
        }

        //TODO: DRY, remove repeating parts.
        /*void GetTweetResults()
        {
            var twitter = new Twitter.Twitter("4rNfhgUrI6yklSBVhmU3U1F8q",
                "kYsjQzU7QVof9USCQHucFi3p2ox61q2GxNVYcDSzTiBzu0C0vT",
                "1001781311051390978-Tj0aXHjC3GSuqGFde9AFp6z9Wjp4i2",
                "BxYSpsScwSW9oxMIozpYpNv7efJhXIihvXduGgUU32S3K");

            List<string> timeLine = new List<string>();

            dynamic timeline = System.Web.Helpers.Json.Decode(response);
            //            user = form["username"].ToString();
            var homeModel = new Home()
            {
                TimeLine = timeLine
            };

            foreach (dynamic tweet in timeline)
            {
                string text = tweet.text;
                timeLine.Add(text);
            }
        }*/
    }
}