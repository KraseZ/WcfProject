using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace WcfService1
{
    public class ReadSites
    {
        public static List<SnotelData> ReadSite(string link)
        {
            List<SnotelData> myData = new List<SnotelData>();
            if (File.Exists(link))
            {
                StreamReader reader = new StreamReader(File.OpenRead(link));
                int lineNum = 0, day = 0;
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] values = line.Split(',');
                    SnotelData data = new SnotelData();
                    int length = 0;
                    if (values[0] == "") { }
                    else if (values[0].StartsWith("#"))
                    {
                        switch (lineNum)
                        {
                            case 0:
                                length = values[0].Length;
                                data.Site = values[0].Substring(2, length - 8);
                                data.Id = Int32.Parse(values[0].Substring(length - 4, 3));
                                break;
                            case 1:
                                length = values[0].Length;
                                data.Elevation = Double.Parse(values[0].Substring(length - 8, 5));
                                break;
                        }
                    }
                    else if (lineNum > 7)
                    {
                        data.Date = values[0];
                        data.SnowWater = Double.Parse(values[1]);
                        data.AirTemp = Double.Parse(values[5]);
                        data.Preciption = Double.Parse(values[6]);
                        day++;
                        
                    }
                    lineNum++;
                    myData.Add(data);
                }
            }
            return myData;
        }
    }
}