﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranscendenceChat_UAP.Common;

namespace TranscendenceChat_UAP.Models
{
    public class MenuItem
    {
        public string Icon { get; set; }

        public string Name { get; set; }

        public AlwaysExecutableCommand Command { get; set; }
    }
}
