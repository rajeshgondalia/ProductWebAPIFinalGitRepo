using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductWebAPI_Repository.DTO
{ 
    public class MainMenuModel
    {
        public int MainMenuMstID { get; set; }
        public string MainMenuName { get; set; }

        public List<SubMenuModel> Groups { get; set; }
    }

    public class SubMenuModel
    {
        public Nullable<byte> MainGroupMstID { get; set; }
        public string MainGroupName { get; set; }
        public List<Menu> SubMenu { get; set; }
    }

    public class Menu
    {
        public byte MenuMstID { get; set; }
        public string MenuName { get; set; }
        public byte[] MenuImageByte { get; set; }
        public string MenuImageBase64 { get; set; }
    }
}
