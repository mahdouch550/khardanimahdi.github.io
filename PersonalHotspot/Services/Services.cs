using System;
using System.Net;
using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;
using Newtonsoft.Json.Linq;
using PersonalHotspot.Areas.Management.Models;

namespace PersonalHotspot.Services
{
    public class Services
    {
        public static string IpToAddress(string ipAddress)
        {
            string output = string.Empty;
            using (WebClient client = new WebClient())
            {
                string apiUrl = "https://freegeoip.app/json/" + ipAddress;
                try
                {
                    string response = client.DownloadString(apiUrl);
                    JObject jsonResponse = JObject.Parse(response);
                    string country = jsonResponse["country_name"].ToString();
                    string city = jsonResponse["city"].ToString();
                    string latitude = jsonResponse["latitude"].ToString();
                    string longitude = jsonResponse["longitude"].ToString();
                    output = "Country: " + country + ", City: " + city + ", Latitude: " + latitude + ", Longitude: " + longitude;
                    Console.WriteLine("Country: " + country);
                    Console.WriteLine("City: " + city);
                    Console.WriteLine("Latitude: " + latitude);
                    Console.WriteLine("Longitude: " + longitude);
                }
                catch (WebException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            return output;
        }

        public static bool SendMail(ContactMessage message)
        {
            MimeMessage email = new();
            email.From.Add(new MailboxAddress(message.Name, message.Email));
            email.To.Add(new MailboxAddress("Mahdi Khardani", "khardani.mahdi.94@gmail.com"));
            email.Subject = "Message from " + message.Name + " - Khardanimahdi.info";
            email.Body = new TextPart(TextFormat.Plain)
            {
                Text = message.Message
            };
            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, useSsl: false);
            smtp.Authenticate("noreply.khardanimahdi@gmail.com", "fddr pbzi edes rghj");
            smtp.Send(email);
            smtp.Disconnect(quit: true);
            return true;
        }
    }
}