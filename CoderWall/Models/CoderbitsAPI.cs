using coderwall_api;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;

namespace CoderWall.Models
{
    public class CoderbitsAPI
    {
        private string _userName;
        private CoderbitsModel _coderbitsData;

        public CoderbitsAPI(string userName)
        {
            string apiCall = "http://coderbits.com/" + userName + ".json";
            doWebRequest(apiCall);
            _userName = userName;
        }

        private void doWebRequest(string apicall)
        {
            string url = apicall;

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(apicall);
            request.Method = "GET";
            request.ContentType = "application/json; charset=utf-8";

            HttpWebResponse response = null;

            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException Ex)
            {
                if (Ex.Message.Contains("404"))
                    throw new NotFoundException("User:" + _userName + " or service (http://coderbits.com/) not Found.");
            }

            TextReader temp = new StreamReader(response.GetResponseStream());
            string data = temp.ReadToEnd();

            temp.Close();

            var serializer = new JavaScriptSerializer();
            serializer.RegisterConverters(new[] { new DynamicJsonConverter() });

            dynamic obj = serializer.Deserialize(data, typeof(object));

            _coderbitsData = new CoderbitsModel();
            _coderbitsData.UserName = obj.username;
            _coderbitsData.Title = obj.title;

            
            foreach (var badge in obj.badges)
            {
                var coderbadge = new CoderBitsBadge { Id = badge.id, Description = badge.description, IsEarned = (bool)badge.earned, Name = badge.name, ImageLink = badge.image_link };
                _coderbitsData.Badges.Add(coderbadge);
            }
        }

        public CoderbitsModel GetInfo()
        {
            return _coderbitsData;
        }
    }
}