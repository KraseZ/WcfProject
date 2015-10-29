using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService1
{
    public class Service1 : IService1
    {
        public List<SnotelData> GetData(string link)
        {
            List<SnotelData> myData;
            myData = ReadSites.ReadSite(link);
            return myData;
        }

    }
}
