using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;

namespace ExecStatusAPI
{
    class ExecStats
    {
        public ExecStats(string id, string sourcemachine, string appname, string task,
                           int status, int prop1, int prop2, int prop3)
        {
            Id = id;
            SourceMachine = sourcemachine;
            AppName = appname;
            Task = task;
            Status = status;
            Prop1 = prop1;
            Prop2 = prop2;
            Prop3 = prop3;
        }
        public string Id { get; set; }

        public string SourceMachine { get; set; }
        public string AppName { get; set; }
        public string Task { get; set; }
        public int Status { get; set; }
        public int Prop1 { get; set; }
        public int Prop2 { get; set; }
        public int Prop3 { get; set; }

        public void SetCurrentTime()
        {
            TimeSpan time = DateTime.UtcNow - new DateTime(1970, 1, 1);
            Id = ((int)time.TotalSeconds).ToString();
        }

        public string GetMessage()
        {
            string message = "{\"Id\": " + Id + ","
               + "\"SourceMachine\": " + SourceMachine + ","
               + "\"AppName\": " + AppName + ","
               + "\"Task\": " + Task + ","
               + "\"Status\": " + Status + ","
               + "\"prop1\": " + Prop1 + ","
               + "\"prop2\": " + Prop2 + ","
               + "\"prop3\": " + Prop3 + "}";

            return message;
        }
    }
    
}
