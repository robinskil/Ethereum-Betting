using System;
using System.Collections.Generic;
using System.Text;

namespace InteractorLayer.RequestModels
{
    public class SlidingPuzzleMoveModel
    {
        public string AddressUser { get; set; }
        public string AddressBet { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }
}
