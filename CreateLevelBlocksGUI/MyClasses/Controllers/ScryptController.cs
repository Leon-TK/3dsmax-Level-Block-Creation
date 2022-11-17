using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using CreateLevelBlocksGUI.MyClasses.Class;
using CreateLevelBlocksGUI.MyClasses.Structs;
using CreateLevelBlocksGUI.MyClasses.Structs.Misc;
using CreateLevelBlocksGUI.MyClasses.Class.ScryptImpl;

namespace CreateLevelBlocksGUI.MyClasses.Controllers
{
    class ScryptController
    {
        ScryptFactory scryptFactory;
        List<Scrypt> scrypts;

        void ProcessScrypts()
        {
            foreach (Scrypt scrypt in scrypts)
            {
                scrypt.Save();
            }
        }

        public void CreateScrypts(Container container)
        {

            //shortwall
            scrypts.Add(scryptFactory.CreateScrypt(CreateShortWallParams(container)));

            //short wall with door
            scrypts.Add(scryptFactory.CreateScrypt(CreateShortWallWithHoleParams(container)));

            //long wall
            scrypts.Add(scryptFactory.CreateScrypt(CreateLongWallParams(container)));

            //long wall with door
            
            scrypts.Add(scryptFactory.CreateScrypt(CreateLongWallWithHoleParams(container)));

            //door cap
            
            scrypts.Add(scryptFactory.CreateScrypt(CreateDoorCapParams(container)));

            //small floor
            
            scrypts.Add(scryptFactory.CreateScrypt(CreateSmallFloorParams(container)));

            //small floor with hole
            
            scrypts.Add(scryptFactory.CreateScrypt(CreateSmallFloorWithHoleParams(container)));

            //big floor
            
            scrypts.Add(scryptFactory.CreateScrypt(CreateBigFloorParams(container)));

            //big door with hole
            
            scrypts.Add(scryptFactory.CreateScrypt(CreateBigFloorWithHoleParams(container)));

            //hole cap
            
            scrypts.Add(scryptFactory.CreateScrypt(CreateHoleCapParams(container)));

        }

        ScryptParams CreateShortWallParams(Container container)
        {
            ScryptParams param = new ScryptParams();

            param.type = Enum.ScryptType.ShortWall;
            param.shapeSize = container.wallTab.shortWall;
            param.name = "ShortWall_" + param.shapeSize.width.ToString() + "x" + param.shapeSize.height.ToString() + "x" + param.shapeSize.depth.ToString();
            param.path = "none";

            return param;
        }
        ScryptParams CreateShortWallWithHoleParams(Container container)
        {
            ScryptParams param = new ScryptParams();
            param.type = Enum.ScryptType.ShortWallWDoor;
            param.shapeSize = container.wallTab.shortWall;
            param.holeSize = container.wallTab.door;
            param.name = "ShortWallWithDoor_" + param.shapeSize.width.ToString() + "x" + param.shapeSize.height.ToString() + "x" + param.shapeSize.depth.ToString();
            param.path = "none";
            return param;
        }
        ScryptParams CreateLongWallParams(Container container)
        {
            ScryptParams param = new ScryptParams();
            Size shortWallSize = container.wallTab.shortWall;
            param.type = Enum.ScryptType.LongWall;
            param.shapeSize.width = shortWallSize.width + (shortWallSize.depth * 2.0f);
            param.shapeSize.height = shortWallSize.height;
            param.shapeSize.depth = shortWallSize.depth;
            param.name = "LongWall_" + param.shapeSize.width.ToString() + "x" + param.shapeSize.height.ToString() + "x" + param.shapeSize.depth.ToString();
            param.path = "none";
            return param;
        }
        ScryptParams CreateLongWallWithHoleParams(Container container)
        {
            ScryptParams param = new ScryptParams();
            param.type = Enum.ScryptType.LongWallWDoor;
            param.shapeSize.width = container.wallTab.shortWall.width + (container.wallTab.shortWall.depth * 2.0f);
            param.shapeSize.height = container.wallTab.shortWall.height;
            param.shapeSize.depth = container.wallTab.shortWall.depth;
            param.holeSize.width = container.wallTab.door.width;
            param.holeSize.height = container.wallTab.door.height;
            param.holeSize.depth = container.wallTab.shortWall.depth;
            param.name = "LongWallWithDoor_" + param.shapeSize.width.ToString() + "x" + param.shapeSize.height.ToString() + "x" + param.shapeSize.depth.ToString();
            param.path = "none";
            return param;
        }

        ScryptParams CreateSmallFloorParams(Container container)
        {
            ScryptParams param = new ScryptParams();
            param.type = Enum.ScryptType.SmallFloor;
            param.shapeSize.width = container.wallTab.shortWall.width;
            param.shapeSize.depth = container.wallTab.shortWall.width;
            param.shapeSize.height = container.wallTab.shortWall.depth;
            param.name = "SmallFloor_" + param.shapeSize.width.ToString() + "x" + param.shapeSize.height.ToString() + "x" + param.shapeSize.depth.ToString();
            param.path = "none";
            return param;
        }
        ScryptParams CreateSmallFloorWithHoleParams(Container container)
        {
            ScryptParams param = new ScryptParams();
            param.type = Enum.ScryptType.SmallFloorWHole;
            param.shapeSize.width = container.wallTab.shortWall.width;
            param.shapeSize.depth = container.wallTab.shortWall.width;
            param.shapeSize.height = container.wallTab.shortWall.depth;
            param.holeSize.width = container.wallTab.door.width;
            param.holeSize.depth = container.wallTab.door.width;
            param.holeSize.height = param.shapeSize.height;
            param.name = "SmallFloorWithHole_" + param.shapeSize.width.ToString() + "x" + param.shapeSize.height.ToString() + "x" + param.shapeSize.depth.ToString();
            param.path = "none";
            return param;
        }
        ScryptParams CreateBigFloorParams(Container container)
        {
            ScryptParams param = new ScryptParams();
            param.type = Enum.ScryptType.BigFloor;
            param.shapeSize.width = container.wallTab.shortWall.width + (container.wallTab.shortWall.depth * 2.0f);
            param.shapeSize.depth = container.wallTab.shortWall.width + (container.wallTab.shortWall.depth * 2.0f);
            param.shapeSize.height = container.wallTab.shortWall.depth;
            param.name = "BigFloor_" + param.shapeSize.width.ToString() + "x" + param.shapeSize.height.ToString() + "x" + param.shapeSize.depth.ToString();
            param.path = "none";
            return param;
        }
        ScryptParams CreateBigFloorWithHoleParams(Container container)
        {
            ScryptParams param = new ScryptParams();
            param.type = Enum.ScryptType.BigFloorWHole;
            param.shapeSize.width = container.wallTab.shortWall.width + (container.wallTab.shortWall.depth * 2.0f);
            param.shapeSize.depth = container.wallTab.shortWall.width + (container.wallTab.shortWall.depth * 2.0f);
            param.shapeSize.height = container.wallTab.shortWall.depth;
            param.holeSize.width = container.wallTab.door.width;
            param.holeSize.depth = container.wallTab.door.width;
            param.holeSize.height = param.shapeSize.height;
            param.name = "BigFloorWithHole_" + param.shapeSize.width.ToString() + "x" + param.shapeSize.height.ToString() + "x" + param.shapeSize.depth.ToString();
            param.path = "none";
            return param;
        }

        ScryptParams CreateDoorCapParams(Container container)
        {
            ScryptParams param = new ScryptParams();
            param.type = Enum.ScryptType.DoorCap;
            param.shapeSize = container.wallTab.door;
            param.shapeSize.depth = container.wallTab.shortWall.depth;
            param.name = "DoorCap_" + param.shapeSize.width.ToString() + "x" + param.shapeSize.height.ToString() + "x" + param.shapeSize.depth.ToString();
            param.path = "none";
            return param;
        }

        ScryptParams CreateHoleCapParams(Container container)
        {
            ScryptParams param = new ScryptParams();
            param.type = Enum.ScryptType.HoleCap;
            param.shapeSize.width = container.wallTab.door.width;
            param.shapeSize.depth = container.wallTab.door.width;
            param.shapeSize.height = container.wallTab.shortWall.depth;
            param.name = "HoleCap_" + param.shapeSize.width.ToString() + "x" + param.shapeSize.height.ToString() + "x" + param.shapeSize.depth.ToString();
            param.path = "none";
            return param;
        }

    }
}
