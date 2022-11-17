using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreateLevelBlocksGUI.MyClasses.Structs.Misc;
namespace CreateLevelBlocksGUI.MyClasses.Structs.TabData
{
    class SettingsData : BaseTabData
    {

        public bool lockSizes;
        public string lockParent;
        public bool spreadToFolders;
        public bool useGlobalHoleOffset;
        public Size GlobalHoleOffset;
    }
}
