﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RentCar.Models;

namespace RentCar.Models
{
    public class RentCarContext : DbContext
    {
        public RentCarContext (DbContextOptions<RentCarContext> options)
            : base(options)
        {
        }

        public DbSet<RentCar.Models.Cars> Cars { get; set; }

        public DbSet<RentCar.Models.Marka> Marka { get; set; }
    }
}
