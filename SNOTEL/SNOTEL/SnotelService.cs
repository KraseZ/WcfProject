using System;
using System.Collections.Generic;
using System.Timers;
using System.IO;

namespace SnotelServiceDesign
{
    class SnotelConsumer
    {
        static void Main(string[] args)
        {
            SNOTEL.ServiceReference1.Service1Client client = new SNOTEL.ServiceReference1.Service1Client();
            List<SNOTEL.ServiceReference1.SnotelData[]> sites = new List<SNOTEL.ServiceReference1.SnotelData[]>();

            sites.Add(client.GetData(@"D:\MesaLakesJan2015.csv"));
            sites.Add(client.GetData(@"D:\SlumgullionJan2015.csv"));

            int dataNum;
            foreach (var site in sites)
            {
                //I am using dataNum to read List 0, 1 spots because List 0 has Name and Id, while List 1 has Elevation
                dataNum = 0;
                foreach (var s in site)
                {
                    if (dataNum == 0) // List 0 has Name and ID stored
                    {
                        Console.WriteLine("\nSite Name: " + s.Site);
                        Console.WriteLine("Site ID: " + s.Id);
                        dataNum++;
                    }
                    else if (dataNum == 1) // List 1 has Elevation stored
                    {
                        Console.WriteLine("Elevation: " + s.Elevation);
                        Console.WriteLine("Date\t      Snow Water Avg-AirTemp Precipitation");
                        dataNum++; // dataNum goes to 2 so the program can ignore it 
                    }
                    if (s.Date != null) Console.WriteLine(s.Date + "\t" + s.SnowWater + "\t " + s.AirTemp + "\t\t" + s.Preciption);
                }
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            client.Close();

        }
    }
}