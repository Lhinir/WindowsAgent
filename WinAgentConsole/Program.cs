﻿using System;
using System.Diagnostics;
using System.Linq;

namespace WinAgentConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EventLog log = new EventLog("Security");
            var entries = log.Entries.Cast<EventLogEntry>().Where(x => x.InstanceId == 4624).Select(x => new
            {
                x.MachineName,
                x.Site,
                x.Source,
                x.UserName,
                x.Message
            }).ToList();
            Console.WriteLine(entries[0].UserName);

        }
       
    }
}
