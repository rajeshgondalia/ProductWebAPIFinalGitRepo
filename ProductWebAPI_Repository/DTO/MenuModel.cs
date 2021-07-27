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

        public List<SubMenuModel> SubMenuList { get; set; }
    }

    public class SubMenuModel
    {
        public Nullable<byte> MainGroupMstID { get; set; }
        public string MainGroupName { get; set; }
    }
}
