using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreateLevelBlocksGUI.MyClasses.Structs;
using System.Windows.Forms;
namespace CreateLevelBlocksGUI.MyClasses.Controllers
{
    class ViewController
    {
        public ViewController()
        {
            container = new Container();
        }

        public Container container { get; }
        public MainForm mainForm { get; set; }

        public void InitTabs()
        {
            mainForm.LockSizeParent.Text = "Minimal room";
            mainForm.LockSizesCheck.Checked = true;
        }
        public void BindEvents()
        {
            //wall tab
            mainForm.ShortWallWidth.TextChanged += onWallsTabChanged;
            mainForm.ShortWallHeight.TextChanged += onWallsTabChanged;
            mainForm.ShortWallDepth.TextChanged += onWallsTabChanged;
            mainForm.DoorWidth.TextChanged += onWallsTabChanged;
            mainForm.DoorHeight.TextChanged += onWallsTabChanged;
            mainForm.HeadToRoofOffsetHeight.TextChanged += onWallsTabChanged;
            mainForm.WallHoleOffsetHeight.TextChanged += onWallsTabChanged;
            mainForm.WallHoleOffsetWidth.TextChanged += onWallsTabChanged;

            //floor tab
            mainForm.SmallFloorWidth.TextChanged += onFloorsTabChanged;
            mainForm.SmallFloorHeight.TextChanged += onFloorsTabChanged;
            mainForm.SmallFloorDepth.TextChanged += onFloorsTabChanged;
            mainForm.HoleWidth.TextChanged += onFloorsTabChanged;
            mainForm.HoleDepth.TextChanged += onFloorsTabChanged;
            mainForm.FloorHoleOffsetWidth.TextChanged += onFloorsTabChanged;
            mainForm.FloorHoleOffsetDepth.TextChanged += onFloorsTabChanged;

            //misc tab
            mainForm.MinimalRoomSizeWidth.TextChanged += onMiscTabChanged;
            mainForm.MinimalRoomSizeDepth.TextChanged += onMiscTabChanged;
            mainForm.MinimalRoomSizeHeight.TextChanged += onMiscTabChanged;

            //settings tab
            mainForm.LockSizeParent.TextChanged += onSettingsTabChanged;
            mainForm.LockSizesCheck.CheckedChanged += onSettingsTabChanged;
            mainForm.SpreadToFoldersCheck.CheckedChanged += onSettingsTabChanged;
            mainForm.GlobalHoleOffsetCheck.CheckedChanged += onSettingsTabChanged;
            mainForm.GlobalHoleOffsetWidth.TextChanged += onSettingsTabChanged;
            mainForm.GlobalHoleOffsetHeight.TextChanged += onSettingsTabChanged;

            //character tab
            mainForm.CharacterWidth.TextChanged += onCharacterTabChanged;
            mainForm.CharacterDepth.TextChanged += onCharacterTabChanged;
            mainForm.CharacterHeight.TextChanged += onCharacterTabChanged;
        }
        public  void onGlobalHoleOffsetChecked(bool status)
        {
            if (status)
            {
                mainForm.HoleOffsetPanel.Enabled = false;
                mainForm.FloorHoleOffsetPanel.Enabled = false;
                mainForm.GlobalHoleOffsetPanel.Enabled = true;
            }
            else 
            {
                mainForm.HoleOffsetPanel.Enabled = true;
                mainForm.FloorHoleOffsetPanel.Enabled = true;
                mainForm.GlobalHoleOffsetPanel.Enabled = false;
            } 
        }

        public void onLockSizesChecked(bool status)
        {
            if (status)
            {
                string parent = mainForm.LockSizeParent.Text;
                
                if (parent == "Character")
                {
                    //disable elements
                    mainForm.DoorHolePanel.Enabled = false;
                    mainForm.HolePanel.Enabled = false;
                }
                else if (parent == "Minimal room")
                {
                    //disable elements
                    mainForm.ShotWallPanel.Enabled = false;
                    mainForm.SmallFloorPanel.Enabled = false;
                }
                else if (parent == "Short wall")
                {
                    //disable elements
                    mainForm.MinimalRoomSizePanel.Enabled = false;
                    mainForm.SmallFloorPanel.Enabled = false;
                }
                else { return; }

            }
            else
            {
                //reset elements
                mainForm.DoorHolePanel.Enabled = true;
                mainForm.HolePanel.Enabled = true;
                mainForm.ShotWallPanel.Enabled = true;
                mainForm.SmallFloorPanel.Enabled = true;
                mainForm.MinimalRoomSizePanel.Enabled = true;
            }

            
                
        }
        public void onLockSizesParentChanged(string param)
        {
            if(mainForm.LockSizesCheck.Checked)
            {
                
                switch (param)
                {
                    case "Character":
                        //disable elements
                        mainForm.DoorHolePanel.Enabled = false;
                        mainForm.HolePanel.Enabled = false;

                        //reset other
                        mainForm.ShotWallPanel.Enabled = true;
                        mainForm.SmallFloorPanel.Enabled = true;
                        mainForm.MinimalRoomSizePanel.Enabled = true;
                        
                        break;
                    case "Minimal room":
                        //disable elements
                        mainForm.ShotWallPanel.Enabled = false;
                        mainForm.SmallFloorPanel.Enabled = false;

                        //reset other
                        mainForm.MinimalRoomSizePanel.Enabled = true;
                        mainForm.HolePanel.Enabled = true;
                        mainForm.DoorHolePanel.Enabled = true;
                        break;
                    case "Short wall":

                        //disable elements
                        mainForm.MinimalRoomSizePanel.Enabled = false;
                        mainForm.SmallFloorPanel.Enabled = false;

                        //reset other
                        mainForm.DoorHolePanel.Enabled = true;
                        mainForm.HolePanel.Enabled = true;
                        mainForm.ShotWallPanel.Enabled = true;
                        break;
                    default:
                        throw new NotImplementedException();
                }
                
            }
        }

        public void onSpreadToFoldersChecked(bool status)
        {
            //set up spread
        }
        public void onFloorsTabChanged(object sender, EventArgs e)
        {
            if (sender is TextBox)
            {
                TextBox tb = (TextBox)sender;

                switch (tb.Name)
                {
                    //small floor
                    case "SmallFloorWidth":
                        container.floorTab.smallFloor.width = float.Parse(tb.Text);
                        break;
                    case "SmallFloorHeight":
                        container.floorTab.smallFloor.height = float.Parse(tb.Text);
                        break;
                    case "SmallFloorDepth":
                        container.floorTab.smallFloor.depth = float.Parse(tb.Text);
                        break;
                    // hole
                    case "HoleWidth":
                        container.floorTab.holeSize.width = float.Parse(tb.Text);
                        break;
                    case "HoleDepth":
                        container.floorTab.holeSize.depth = float.Parse(tb.Text);
                        break;
                    case "FloorHoleOffsetWidth":
                        container.floorTab.holeOffset.width = float.Parse(tb.Text);
                        break;
                    case "FloorHoleOffsetDepth":
                        container.floorTab.holeOffset.depth = float.Parse(tb.Text);
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
            else {throw new NotImplementedException();}
            
        }

        public void onWallsTabChanged(object sender, EventArgs e)
            {
            if (sender is TextBox)
            {
                TextBox tb = (TextBox)sender;

                switch (tb.Name)
                {
                    //short wall
                    case "ShortWallWidth":
                        container.wallTab.shortWall.width = float.Parse(tb.Text);
                        break;
                    case "ShortWallHeight":
                        container.wallTab.shortWall.height = float.Parse(tb.Text);
                        break;
                    case "ShortWallDepth":
                        container.wallTab.shortWall.depth = float.Parse(tb.Text);
                        break;
                    // door
                    case "DoorWidth":
                        container.wallTab.door.width = float.Parse(tb.Text);
                        break;
                    case "DoorHeight":
                        container.wallTab.door.height = float.Parse(tb.Text);
                        break;
                    case "HeadToRoofOffsetHeight":
                        container.wallTab.headToRoofOffset = float.Parse(tb.Text);
                        break;
                    case "WallHoleOffsetWidth":
                        container.wallTab.holeOffset.width = float.Parse(tb.Text);
                        break;
                    case "WallHoleOffsetHeight":
                        container.wallTab.holeOffset.height = float.Parse(tb.Text);
                        break;
                    default:
                        throw new NotImplementedException();

                };
            }
            else { throw new NotImplementedException(); }
        }

        public void onMiscTabChanged(object sender, EventArgs e)
        {
            if (sender is TextBox)
            {
                TextBox tb = (TextBox)sender;

                switch (tb.Name)
                {
                    //short wall
                    case "MinimalRoomSizeWidth":
                        container.miscTab.roomSize.width = float.Parse(tb.Text);
                        break;
                    case "MinimalRoomSizeHeight":
                        container.miscTab.roomSize.height = float.Parse(tb.Text);
                        break;
                    case "MinimalRoomSizeDepth":
                        container.miscTab.roomSize.depth = float.Parse(tb.Text);
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
            else { throw new NotImplementedException(); }
        }

        public void onSettingsTabChanged(object sender, EventArgs e)
        {

            if (sender is CheckBox)
            {
                CheckBox cb = (CheckBox)sender;

                switch (cb.Name)
                {
                    case "LockSizesCheck":
                        onLockSizesChecked(cb.Checked);
                        break;
                    case "SpreadToFoldersCheck":
                        onSpreadToFoldersChecked(cb.Checked);
                        break;
                    case "GlobalHoleOffsetCheck":
                        onGlobalHoleOffsetChecked(cb.Checked);
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
            else if (sender is ComboBox)
            {
                ComboBox cb = (ComboBox)sender;

                switch (cb.Name)
                {
                    case "LockSizeParent":
                        onLockSizesParentChanged(cb.Text);
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
            else if (sender is TextBox)
            {
                TextBox tb = (TextBox)sender;

                switch (tb.Name)
                {
                    case "GlobalHoleOffsetWidth":
                        container.settingsTab.GlobalHoleOffset.width = float.Parse(tb.Text);
                        break;
                    case "GlobalHoleOffsetHeight":
                        container.settingsTab.GlobalHoleOffset.height = float.Parse(tb.Text);
                        break;

                    default:
                        throw new NotImplementedException();
                }
            }
            else { throw new NotImplementedException(); }

        }

        public void onCharacterTabChanged(object sender, EventArgs e)
        {
                if (sender is TextBox)
                {

                    TextBox tb = (TextBox)sender;

                    switch (tb.Name)
                    {
                        //short wall
                        case "CharacterWidth":
                            container.characterTab.characterSize.width = float.Parse(tb.Text);
                        break;
                        case "CharacterHeight":
                            container.characterTab.characterSize.height = float.Parse(tb.Text);
                        break;
                        case "CharacterDepth":
                            container.characterTab.characterSize.depth = float.Parse(tb.Text);
                        break;
                        default:
                            throw new NotImplementedException();

                    }
                }
                else { throw new NotImplementedException(); }

        }
    }
}
