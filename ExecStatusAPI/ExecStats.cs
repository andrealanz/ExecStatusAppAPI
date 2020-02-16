using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.ComponentModel.DataAnnotations;

namespace ExecStatusAPI
{
    public class ExecStats
    {
        //ExecStats constructor
        public ExecStats(string id, string sourcemachine, string appname, string task,
                            int status, int Prop1, int Prop2, int Prop3)
        {
            Id = id;
            SourceMachine = sourcemachine;
            AppName = appname;
            Task = task;
            Status = status;
            prop1 = Prop1;
            prop2 = Prop2;
            prop3 = Prop3;
            
        }

        [Required]
        public string Id { get; set; }

        public DateTime Time { get; set; }
        public string SourceMachine { get; set; }
        public string AppName { get; set; }
        public string Task { get; set; }
        public int Status { get; set; }
        public int prop1 { get; set; }
        public int prop2 { get; set; }
        public int prop3 { get; set; }

        //set Id to the current epoch time
        public void SetCurrentTime()
        {
            TimeSpan time = DateTime.UtcNow - new DateTime(1970, 1, 1);
            Id = ((int)time.TotalSeconds).ToString();
        }

        public void ShowExecStats()
        {
            Console.WriteLine(
              $"AppName: {AppName}\n" +
              $"Id: {Id}\n" +
              $"SourceMachine: {SourceMachine}\n" +
              $"Status: {Status}\n" +
              $"Task: {Task}\n" +
              $"Time: {Time}\n" +
              $"prop1: {prop1}\n" +
              $"prop2: {prop2}\n" +
              $"prop3: {prop3}\n"
            );
            
        }
        
    }
    
}
