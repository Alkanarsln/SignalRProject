﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRWebUI.Dtos.DiscountDtos
{
    public class CreateDiscountDto
    {
        public string Title { get; set; }
        public string Amount { get; set; }
        public string description { get; set; }
        public string ImageUrl { get; set; }
    }
}