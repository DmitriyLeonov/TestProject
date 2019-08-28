﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TestProject.Models
{
    [Table("Records")]
    public class FormModel
    {
        [Required]
        [Key]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Time { get; set; }
        [Required]
        public string Comment { get; set; }
    }
}