﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A.CMD.Entity
{
    internal class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
         public int Id { get; set; }
         public string FirstName { get; set; }
         public string LastName { get; set; }
         public int Age { get; set; }

        public Customer() { }
        
    }
}
