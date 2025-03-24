﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.Models
{
    public class Email
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        [Column(TypeName = "varchar(10)")]
        public string EmailAddress { get; set; }
    }
}
