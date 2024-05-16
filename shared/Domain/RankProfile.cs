﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class RankProfile
    {
        private double _rank;
        public double Rank
        {
            get { return _rank; }
            set
            {
                if (value < 0.0)
                {
                    _rank = 0.0;
                }
                else if (value > 10.0)
                {
                    _rank = 10.0;
                }
                else
                {
                    _rank = value;
                }
            }
        }
        public Profile Profile { get; set; }
    }
}
