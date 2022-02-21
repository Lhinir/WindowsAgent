using System;
using System.Diagnostics;

namespace WinAgentConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EventLog log = new
            EventLog("Application");

            foreach (EventLogEntry entry in log.Entries)
            {
                Console.WriteLine("Kullanıcı Adı: " + entry.UserName);
                Console.WriteLine("Kaynak: " + entry.Source);
                Console.WriteLine("Girdi tipi: " + entry.EntryType);
                Console.WriteLine("Olay id'si: " + entry.EventID);
                Console.WriteLine("Mesaj: " + entry.Message);
                Console.WriteLine("--------------------------------------------");
                Console.ReadLine();
            
            }
        }
    }
}
