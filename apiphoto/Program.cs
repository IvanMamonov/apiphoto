using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace api
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = $"https://loremflickr.com/320/240";

            var request = WebRequest.Create(url);

            var response = request.GetResponse();
            var httpStatusCode = (response as HttpWebResponse).StatusCode;

            if (httpStatusCode != HttpStatusCode.OK)
            {
                Console.WriteLine(httpStatusCode);
                return;
            }

            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = response.ResponseUri.ToString(),
                UseShellExecute = true
            };
            Process.Start(psi);

            using (WebClient client = new WebClient())
            {
                client.DownloadFile(response.ResponseUri, Directory.GetCurrentDirectory() + "test.jpg");
            }
        }

  //    public static string GetPhotoName(WebResponse response)
  //    {
  //        var s = ReverseString(response.ResponseUri.ToString());
  //        string name = "";
  //        foreach(var c in s)
  //        {
  //            if (c != '/')
  //                name += c;
  //            else
  //            {
  //                break;
  //            }
  //        }
  //        return ReverseString(name).ToString();
  //    }
  //
  //    private  static char[] ReverseString(string name)
  //    {
  //        char[] charArray = name.ToCharArray();
  //        Array.Reverse(charArray);
  //        return charArray;
  //    }
    }
}
