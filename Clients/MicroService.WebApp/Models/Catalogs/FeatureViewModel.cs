﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MicroService.WebApp.Models.Catalogs
{
    public class FeatureViewModel
    {
        [Display(Name = "Kurs süre")]
        public int Duration { get; set; }
    }
}