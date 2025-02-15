﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserrManagementIdentity.Models
{
    public class User :IdentityUser
    {
        [Required , MaxLength(100)]
        public string FirstName { get; set; }
        [Required, MaxLength(100)]

        public string LastName { get; set; }

        public Byte[] ProfilePic  { get; set; }
    }
}
