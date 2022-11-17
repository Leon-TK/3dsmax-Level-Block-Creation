using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CreateLevelBlocksGUI.MyClasses.Interfaces;
using CreateLevelBlocksGUI.MyClasses.Implementations;
using CreateLevelBlocksGUI.MyClasses.Structs.TabData;



namespace CreateLevelBlocksGUI
{
    static class Program
    {

        [STAThread]
        static void Main()
        {

            //Default settings assign
            WallData wStruct = new WallData();
            wStruct.shortWall.width = 1;
            wStruct.shortWall.height = 1;
            wStruct.shortWall.depth = 1;

            wStruct.door.width = 1;
            wStruct.door.height = 1;

            SettingsData sStruct = new SettingsData();
            sStruct.lockSizes = true;
            sStruct.spreadToFolders = false;


            // App setup
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Create form
            MainForm mainForm = new MainForm();

            //Create controller with that implementation

            IController controller = new Impl_MainController(mainForm);

            controller.BindEvents();
            controller.InitTabs();

            Application.Run(mainForm);
            
        }
    }
}

