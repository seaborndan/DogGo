﻿using System;
using System.Collections.Generic;

namespace DogGo.Models.ViewModels
{
    public class WalkerProfileViewModel
    {
        public Walker Walker { get; set; }
        public List<Walks> Walks { get; set; }

        public Neighborhood Neighborhood { get; set; }

        public int TotalWalkTime { get; set; }
    }
}