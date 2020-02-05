﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Domain.Models
{
    public class User : IdentityUser<int>
    {
        public string IdOne { get; set; }
        public string IdTwo { get; set; }
        public ICollection<UserActivity> Activities { get; set; }

    }
}