﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SergRasKoin.Storage.Models
{
    public class Course
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)] 
        public Guid Isnnode { get; set; }

        public double course {  get; set; }

        public DateTime dateTime { get; set; }
    }
}
