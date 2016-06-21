﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace XBoxRentals.Models
{
    public class File
    {
        public int Id { get; set; }

        [Required]
        public string ContentType { get; set; }

        [Required]
        public byte[] Bytes { get; set; }
    }
}