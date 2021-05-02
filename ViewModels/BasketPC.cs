using EZPCBuilder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZPCBuilder.ViewModels
{
    public class BasketPC
    {
        public int PCID { get; set; }
        public int BasketID { get; set; }
        public virtual PC pc { get; set; }
    }
}
