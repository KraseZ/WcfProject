using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService1
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        List<SnotelData> GetData(string link);

    }

    [DataContract]
    public class SnotelData
    {
        string site;
        int id;
        double elevation;
        string date;
        double snowWater;
        double snowDepth;
        double preciption;
        double airTemp;

        [DataMember]
        public string Site
        {
            get { return site; }
            set { site = value; }
        }

        [DataMember]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [DataMember]
        public double Elevation
        {
            get { return elevation; }
            set { elevation = value; }
        }

        [DataMember]
        public string Date
        {
            get { return date; }
            set { date = value; }
        }

        [DataMember]
        public double SnowWater
        {
            get { return snowWater; }
            set { snowWater = value; }
        }

        [DataMember]
        public double SnowDepth
        {
            get { return snowDepth; }
            set { snowDepth = value; }
        }

        [DataMember]
        public double Preciption
        {
            get { return preciption; }
            set { preciption = value; }
        }

        [DataMember]
        public double AirTemp
        {
            get { return airTemp; }
            set { airTemp = value; }
        }
    }
}
