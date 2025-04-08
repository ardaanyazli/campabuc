using CamPabuc.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamPabuc.Model.Entity
{
    public class  ShoeCategory:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
