﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dolgozok_adatainak_lekerese
{
    internal class Dolgozok
    {
        public string nev;
        public string neme;
        public string reszleg;
        public int belepesev;
        public int ber;

        public Dolgozok(string nev, string neme, string reszleg, int belepesev, int ber)
        {
            this.nev = nev;
            this.neme = neme;
            this.reszleg = reszleg;
            this.belepesev = belepesev;
            this.ber = ber;
        }
    }
}
