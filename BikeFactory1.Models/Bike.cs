using BikeFactory1.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeFactory1.Models
{
    public class Bike
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ESuspensionType SuspensionType { get; set; }
        public ETireType TireType { get; set; }

    }
}
