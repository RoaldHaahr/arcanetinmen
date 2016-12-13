﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArcaneTinmen.ViewModels
{
    public class ShippingDetails
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
        public int Zip { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
    }

}