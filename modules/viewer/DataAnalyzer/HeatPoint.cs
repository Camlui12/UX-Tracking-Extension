﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lades.WebTracer
{
    public class HeatPoint
    {
        public HeatPoint()
        {
            X = Y = Z = 0;
        }
        public double X;
        public double Y;
        public double Z;
        public int type = 0;
    }
}
