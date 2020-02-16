using System;
using System.Net;
using System.IO;

namespace ExecStatusAPI
{
    class ExecStatusApp
    {
        public string API_ENDPOINT = "https://execstatusapp20191220061912.azurewebsites.net/api/";
        public string app_exec_stat_get()
        {
            WebRequest wrGetURL;
            wrGetURL = WebRequest.Create(API_ENDPOINT + "ExecStats");

            Stream data = wrGetURL.GetResponse().GetResponseStream();
            StreamReader data_reader = new StreamReader(data);

            string message = data_reader.ReadToEnd();

            data.Close();
            return message;
        }

        public string app_exec_stat_get_id(string id)
        {
            WebRequest wrGetURL;
            wrGetURL = WebRequest.Create(API_ENDPOINT + "ExecStats/" + id);

            Stream data = wrGetURL.GetResponse().GetResponseStream();
            StreamReader data_reader = new StreamReader(data);

            string message = data_reader.ReadToEnd();

            data.Close();
            return message;
        }

        /*
         public string app_exec_stat_post(ExecStats data)
         {

             var request = (HttpWebRequest)WebRequest.Create(API_ENDPOINT + "ExecStats");
             request.ContentType = "application/json";
             request.Method = "POST";

             StreamWriter wr_stream = new StreamWriter(request.GetRequestStream());
             wr_stream.Write(data.GetMessage());

             HttpWebResponse response = (HttpWebResponse) request.GetResponse();
             StreamReader r_stream = new StreamReader(response)
             
        }
        */
        static void Main()
        {
            ExecStatusApp test = new ExecStatusApp();
            test.app_exec_stat_get();
        }
    }
}
