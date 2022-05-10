using SY.Com.Medical.BLL.Platform;
using SY.Com.Medical.Entity;
using SY.Com.Medical.Extension;
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
    /// 业务逻辑层
    /// </summary>
    public class UserManager 
	{
		private UserManagerRepository db;
		public UserManager()
		{
			db = new UserManagerRepository();
		}
		///<summary> 
		///获取详情记录
		///</summary> 
		///<param name="id"></param>
		/// <returns></returns>
		public UserManagerModel get(int id)
		{
			return db.Get(id).EntityToDto<UserManagerModel>();
		}
		///<summary> 
		///获取列表-分页
		///</summary> 
		///<param name="request"></param>
		/// <returns></returns>
		public Tuple<IEnumerable<UserManagerModel>,int> gets(UserManagerRequest request)
		{
			var datas  = db.GetsPage(request.DtoToEntity<UserManagerEntity>(), request.PageSize, request.PageIndex);
			Tuple<IEnumerable<UserManagerModel>, int> result = new(datas.Item1.EntityToDto<UserManagerModel>(), datas.Item2);
			return result;
		}
		///<summary> 
		///新增
		///</summary> 
		///<param name="request"></param>
		/// <returns></returns>
		public int add(UserManagerAdd request)
		{
			return db.Create(request.DtoToEntity<UserManagerEntity>());
		}
		///<summary> 
		///修改
		///</summary> 
		///<param name="request"></param>
		/// <returns></returns>
		public void update(UserManagerUpdate request)
		{
			db.Update(request.DtoToEntity<UserManagerEntity>());
		}
		///<summary> 
		///删除
		///</summary> 
		///<param name="request"></param>
		/// <returns></returns>
		public void delete(UserManagerDelete request)
		{
			db.Delete(request.DtoToEntity<UserManagerEntity>());
		}

		public UserModel Login(LoginRequest request)
		{
			UserManagerEntity entity = db.Get(request.Account);
			if (entity == null)
			{
				throw new DataNotExists("账号不存在");
			}
			if (entity.Pwd != request.Pwd)
			{
				throw new DataLogicFails("密码错误");
			}
			if (entity.IsDelete == Enum.Delete.删除 || entity.IsEnable == Enum.Enable.禁用)
			{
				throw new DataStateException("账户状态异常,请联系管理员");
			}
			UserModel response = new UserModel();
			response.Account = entity.Account;
			response.UserId = entity.Id;
			return response;
		}
	}
} 