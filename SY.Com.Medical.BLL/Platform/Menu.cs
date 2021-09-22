using SY.Com.Medical.Entity;
using SY.Com.Medical.Model;
using SY.Com.Medical.Repository.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Medical.BLL.Platform
{
    /// <summary>
    /// 菜单
    /// </summary>
    public class Menu
    {
        private CURDObject<MenuEntity> curdObj;
        private MenuRepository db;
        public Menu()
        {
            curdObj = new CURDObject<MenuEntity>();
            curdObj.Entity = new MenuEntity();
            curdObj.db = new MenuRepository();
            db = new MenuRepository();
        }

        /// <summary>
        /// 获取系统菜单一维
        /// </summary>
        /// <returns></returns>
        public List<MenuResponse> GetSystem()
        {
            List<MenuResponse> responses = new List<MenuResponse>();
            var entitys = db.getSystem();
            entitys.ToList().ForEach(entity => responses.Add(entity.EntityToModel<MenuResponse>()));
            return responses;
        }

        /// <summary>
        /// 获取系统菜单树
        /// </summary>
        /// <returns></returns>
        public List<MenuTreeResponse> GetSystemTree()
        {
            List<MenuResponse> responses = new List<MenuResponse>();
            List<MenuTreeResponse> responses2 = new List<MenuTreeResponse>();
            var entitys = db.getSystem();
            entitys.ToList().ForEach(entity => responses.Add(entity.EntityToModel<MenuResponse>()));
            responses.ForEach(x =>
            {
                if (x.MenuParent != 0)
                {
                    responses2.Find(y => y.MenuId == x.MenuParent).SubMenu.Add(x);
                }
                else
                {
                    responses2.Add(new MenuTreeResponse
                    {
                        MenuId = x.MenuId,
                        MenuName = x.MenuName,
                        MenuRoute = x.MenuRoute,
                        MenuParent = x.MenuParent,
                        SubMenu = new List<MenuResponse>()
                    });
                }
            });
            return responses2;
        }




    }
}
