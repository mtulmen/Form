﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Entities
{
    public class CategoryEntity : EntityBase
    {
        public string Name { get; set; }

        public string Desc { get; set; }

        public int CatOrder { get; set; }
    }
}
