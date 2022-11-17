using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreateLevelBlocksGUI.MyClasses.Structs.TabData;

namespace CreateLevelBlocksGUI.MyClasses.Structs
{
    class Container
    {
        
        public FloorsData floorTab;
        public MiscData miscTab;
        public WallData wallTab;
        public SettingsData settingsTab;
        public CharacterData characterTab;

        public Container()
        {
            this.floorTab = new FloorsData();
            this.miscTab = new MiscData();
            this.wallTab = new WallData();
            this.settingsTab = new SettingsData();
            this.characterTab = new CharacterData();
        }

        void SaveData()
        {

        }
    }
}
