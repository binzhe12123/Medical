using SY.Com.Medical.Entity;
using SY.Com.Medical.Model;
using SY.Com.Medical.Repository.Platform;
using SY.Com.Medical.Extension;
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
        private MenuRepository db;
        public Menu()
        {
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
            entitys.ToList().ForEach(entity => responses.Add(entity.EntityToDto<MenuResponse>()));
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
            entitys.ToList().ForEach(entity => responses.Add(entity.EntityToDto<MenuResponse>()));
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


        /// <summary>
        /// 根据多个角色获取菜单
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public List<MenuTreeResponse> GetEmployee(List<Role> roles)
        {

            return new List<MenuTreeResponse>();
        }


    }
}
