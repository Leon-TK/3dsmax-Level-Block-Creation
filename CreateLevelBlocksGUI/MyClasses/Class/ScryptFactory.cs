using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreateLevelBlocksGUI.MyClasses.Class.ScryptImpl;
using CreateLevelBlocksGUI.MyClasses.Enum;
namespace CreateLevelBlocksGUI.MyClasses.Class
{
    class ScryptFactory
    {
        public Scrypt CreateScrypt(ScryptParams param)
        {
            ScryptType type = param.type;
            Scrypt scrypt;

            switch (type)
            {
                case ScryptType.ShortWall:
                    scrypt = new Impl_S_Wall();
                    scrypt.SetParams(param);
                    return scrypt;
                case ScryptType.LongWall:
                    scrypt = new Impl_L_Wall();
                    scrypt.SetParams(param);
                    return scrypt;
                case ScryptType.ShortWallWDoor:
                    scrypt = new Impl_S_Wall_Door();
                    scrypt.SetParams(param);
                    return scrypt;
                case ScryptType.LongWallWDoor:
                    scrypt = new Impl_L_Wall_Door();
                    scrypt.SetParams(param);
                    return scrypt;
                case ScryptType.SmallFloor:
                    scrypt = new Impl_S_Floor();
                    scrypt.SetParams(param);
                    return scrypt;
                case ScryptType.BigFloor:
                    scrypt = new Impl_B_Floor();
                    scrypt.SetParams(param);
                    return scrypt;
                case ScryptType.SmallFloorWHole:
                    scrypt = new Impl_S_Floor_Hole();
                    scrypt.SetParams(param);
                    return scrypt;
                case ScryptType.BigFloorWHole:
                    scrypt = new Impl_B_Floor_Hole();
                    scrypt.SetParams(param);
                    return scrypt;
                case ScryptType.DoorCap:
                    scrypt = new Impl_DoorCap();
                    scrypt.SetParams(param);
                    return scrypt;
                case ScryptType.HoleCap:
                    scrypt = new Impl_HoleCap();
                    scrypt.SetParams(param);
                    return scrypt;
                default:
                    throw new NotImplementedException();
            }

            throw new NotImplementedException();
        }
    }
}
