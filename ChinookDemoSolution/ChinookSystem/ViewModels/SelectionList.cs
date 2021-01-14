using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinookSystem.ViewModels
{
    //this class will be used as a generic container for data that 
    // will load a dropdown list
    //this value field will represent an integer PK 
    //the display field will represent the display string of the DDL
    public class SelectionList
    {
        public int ValueField { get; set; }
        public string DisplayField { get; set; }
    }
}
