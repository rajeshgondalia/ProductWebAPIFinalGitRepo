using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductWebAPI_Repository.Data;
using ProductWebAPI_Repository.DTO;

namespace ProductWebAPI_Repository.ServiceContract
{
    public interface IMenu_Repository : IDisposable
    {
        List<MainMenuModel> MenuList(int CrId);
    }
}
