using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateLevelBlocksGUI.MyClasses.Interfaces
{
    interface IController
    {
 
        //Loop "Maya" with -params through all .mel scripts
        void Start();

        void BindEvents();
        void InitTabs();
    }
}
