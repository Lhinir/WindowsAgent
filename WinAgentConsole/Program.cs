using System;
using System.Diagnostics;

namespace WinAgentConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Konsol Rengi
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            #endregion

            EventLog log = new
            EventLog("Application");

            DateTime dt = DateTime.Now.AddHours(-5.00);
            Console.WriteLine(dt.ToString());

            string karar = "";
            menu:
            foreach (EventLogEntry entry in log.Entries)
            {
                if (entry.TimeGenerated >= dt)
                {
                    Console.WriteLine("Kullanıcı Adı: " + entry.UserName);
                    Console.WriteLine("Kaynak: " + entry.Source);
                    Console.WriteLine("Girdi tipi: " + entry.EntryType);
                    Console.WriteLine("Olay id'si: " + entry.EventID);
                    Console.WriteLine("Mesaj: " + entry.Message);
                    Console.WriteLine("Oluşturulma Zamanı: " + entry.TimeGenerated);
                    Console.WriteLine("--------------------------------------------");
                }
            }
            secim:
            Console.WriteLine("Gösterilecek olay kalmadı. Yenilemek ister misiniz ? E/H");
            karar = Console.ReadLine();
            if (karar is "e" or "E")
            {
                goto menu;
            }
            else if (karar is "h" or "H")
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Yanlış bir tuşlama yaptınız. Lütfen E yada H basınız.");
                goto secim;
            }
        }
    }
}
