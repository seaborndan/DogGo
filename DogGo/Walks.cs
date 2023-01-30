using Microsoft.VisualBasic;
using DogGo.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System;

namespace DogGo.Models
{
    public class Walks
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public int Duration { get; set; }
        public int WalkerId { get; set; }
        public int DogId { get; set; }
        public Neighborhood Neighborhood { get; set; }

    }
}