﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Group5.Models
{
    public partial class Room
    {
        public int RoomId { get; set; }
        public string Name { get; set; }
        public int? NumberRows { get; set; }
        public int? NumberCols { get; set; }
    }
}
