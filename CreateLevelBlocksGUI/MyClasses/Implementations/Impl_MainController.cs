using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using CreateLevelBlocksGUI.MyClasses.Interfaces;
using CreateLevelBlocksGUI.MyClasses.Structs;
using CreateLevelBlocksGUI.MyClasses.Controllers;

namespace CreateLevelBlocksGUI.MyClasses.Implementations
{
    class Impl_MainController : IController
    {
        ScryptController scryptController;
        MayaController mayaController;
        ViewController viewController;

        public Impl_MainController(MainForm form)
        {
            scryptController = new ScryptController();
            mayaController = new MayaController();
            viewController = new ViewController();
            viewController.mainForm = form;
        }

        public void BindEvents()
        {
            viewController.BindEvents();
        }

        public void InitTabs()
        {
            viewController.InitTabs();
        }

        public void Start()
        {
            scryptController.CreateScrypts(viewController.container);
            //create all scrypt objs
            //save scrypt
            //launch maya with all scrypt
        }
    }
}
