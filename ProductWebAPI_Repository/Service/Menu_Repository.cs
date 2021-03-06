using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductWebAPI_Repository.ServiceContract;
using System.Data.Entity;
using ProductWebAPI_Repository.Data;
using System.Data;
using System.Data.SqlClient;
using ProductWebAPI_Repository.DataServices;
using ProductWebAPI_Repository.DTO;
using System.Security.Claims;

namespace ProductWebAPI_Repository.Service
{
    public class Menu_Repository : IMenu_Repository, IDisposable
    {
        private MED_GENMEDEntities context;
        public Menu_Repository(MED_GENMEDEntities _context)
        {
            context = _context;
        }
        public Menu_Repository()
        {
            context = new MED_GENMEDEntities();
        }

        public List<MainMenuModel> MenuList(int CrId)
        {
            try
            {
                List<MainMenuModel> MainMenuList = new List<MainMenuModel>();  
                var menudata = (from C in context.CounterDets.Where(x => x.CrId == CrId)
                                join M in context.MainMenuMsts.Where(x => x.Valid == 1) on C.MainMenuMstID equals M.MainMenuMstID
                                select new MainMenuModel
                                {
                                    MainMenuMstID = M.MainMenuMstID,
                                    MainMenuName = M.MainMenuName,
                                    Groups = (from S in context.MainGroupMsts.Where(x => x.MainMenuMstID == M.MainMenuMstID && x.Valid == 1)
                                              select new SubMenuModel
                                              {
                                                  MainGroupMstID = S.MainGroupMstID,
                                                  MainGroupName = S.MainGroupName,
                                                  SubMenu = context.MenuMsts.Where(x => x.MainMenuMstID == C.MainMenuMstID &&
                                                                                        x.MainGroupMstID == S.MainGroupMstID && x.Valid == 1).
                                                                                        Select(c => new Menu()
                                                                                        {
                                                                                            MenuMstID = c.MenuMstID,
                                                                                            MenuName = c.MenuName,
                                                                                            MenuImageByte = c.MenuImage 
                                                                                        }).ToList()
                                              }).ToList()
                                }).ToList();

                foreach (var M in menudata)
                {
                    MainMenuModel mData = new MainMenuModel();
                    var checkExists = MainMenuList.Where(x => x.MainMenuMstID == M.MainMenuMstID).FirstOrDefault();
                    if (checkExists == null)
                    {
                        mData.MainMenuMstID = M.MainMenuMstID;
                        mData.MainMenuName = M.MainMenuName;
                        List<SubMenuModel> GroupList = new List<SubMenuModel>();
                        foreach (var G in M.Groups)
                        {
                            SubMenuModel sData = new SubMenuModel();
                            sData.MainGroupMstID = G.MainGroupMstID;
                            sData.MainGroupName = G.MainGroupName;
                            List<Menu> MenuList = new List<Menu>();
                            foreach (var I in G.SubMenu)
                            {
                                Menu iData = new Menu();
                                iData.MenuMstID = I.MenuMstID;
                                iData.MenuName = I.MenuName;
                                iData.MenuImageByte = null;
                                iData.MenuImageBase64 = I.MenuImageByte == null ? string.Empty : "data:image/png;base64," + Convert.ToBase64String(I.MenuImageByte);
                                MenuList.Add(iData); 
                            }
                            sData.SubMenu = MenuList;
                            GroupList.Add(sData); 
                        }
                        mData.Groups = GroupList;
                        MainMenuList.Add(mData);
                    }
                }
                return MainMenuList;
            }
            catch (Exception ex)
            {
                ex.SetLog("MenuList,Menu_Repository");
                throw;
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    context.Dispose();
                }

                disposedValue = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
