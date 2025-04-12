using CamPabuc.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamPabuc.Model.Entity
{
    public class  Manufacturer:IEntity
    {
        public int Id { get; set; }
        public string? FirmName { get; set; }
        public string? Contact { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
    }
}
