﻿using E_Commerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.DTOs
{
    public class CategoryDto 
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
    }
}
