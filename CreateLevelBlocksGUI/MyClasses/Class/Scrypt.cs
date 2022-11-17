using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateLevelBlocksGUI.MyClasses.Class
{
    interface Scrypt
    {
        void SetParams(ScryptParams param);
        void Save();
        string Open();
        void Change();
    }
}
