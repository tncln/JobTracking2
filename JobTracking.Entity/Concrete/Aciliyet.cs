using JobTracking.Entity.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobTracking.Entity.Concrete
{
    public class Aciliyet:ITablo
    {
        public int Id { get; set; }
        public string Tanim { get; set; }

        public List<Gorev> Gorevler { get; set; }
    }
}
