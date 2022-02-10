﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacuumSim.Components
{
    /// <summary>
    ///  Primitive Vacuum Class.
    ///  Holds data for each attribute of the vacuum to be referenced and accessed by the VacuumController class.
    /// </summary>
    public class Vacuum
    {
        public double VacuumSize { get; set; } = 12.8;  // inches
        public double VacuumWidth { get; set; } = 5.8;  // inches. refers to the actual size of the vacuum's "mouth"
        public double VacuumEfficiency { get; set; } = 0.10;    // default efficency will vary by floor. min = 10%, max = 90%
        public double WhiskerWidth { get; set; } = 13.5;    // inches
        public double WhiskerEfficiency { get; set; } = 0.30;   // default efficiency is 30%.
        public int VacuumSpeed { get; set; } = 3;       // inches per second. Default is 3 in/s
        public int VacuumBattery { get; set; } = 150;    // minutes, min = 90, max = 200.
        
        // May change this later, but for now I'll denote which algorithms are selected using a list.
        // IDs can be assigned to each algorithm - 0: Random, 1: Spiral, 2: Snaking, 3: Wall Follow.
        // Allows for multiple algorithms to be selected at once. They will be removed from the list once the
        // Vacuum finishes a run. 
        public List<int> VaccuumAlgorithm { get; set; } 
    }

}
