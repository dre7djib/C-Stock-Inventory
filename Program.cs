using System;
using System.Collections.Generic;
using System.Net;

namespace Api
{
    public class SimpleApi
    {
        private static List<Article> articles = new List<Article>();
        private static List<User> users = new List<User>();
        static void Main()
        {
            string url = "http://localhost:8080/";

            using (HttpListener listener = new HttpListener())
            {
                DatabaseConnection db = new DatabaseConnection(); // Instantiate the db object
                listener.Prefixes.Add(url);
                listener.Start();
                Console.WriteLine($"API en cours d'exécution sur {url}");
                db.OpenConnection(); // Open the connection to the database

                while (true)
                {
                    HttpListenerContext context = listener.GetContext();
                    RequestHandler.ProcessRequest(context, articles, users, db);
                }
            }
        }
    }
}
