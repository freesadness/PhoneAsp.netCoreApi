﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.Models
{
    public class Phone
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public float ScreenSize { get; set; }
        public string System { get; set; }
    }
}
