using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnergyConsumption.Models
{
    public class Device
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public int W { get; set; }
        public double Hour { get; set; }
        public double Day { get; set; }

        public int? HomeID { get; set; }
        public virtual Home Home { get; set; }

    }

    public class Home
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Device> Devices { get; set; }

        public Home()
        {
            Devices = new List<Device>();
        }

        public string ApplicationUserID { get; set; }

        
    }

}