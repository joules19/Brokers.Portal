﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brokers.Portal.Modules.Users.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
    }
}
