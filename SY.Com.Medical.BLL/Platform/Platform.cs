using SY.Com.Medical.Entity;
using SY.Com.Medical.Model;
using SY.Com.Medical.Repository.Platform;
using System;
using System.Collections.Generic;
using SY.Com.Medical.Extension;

namespace SY.Com.Medical.BLL.Platform
{
    /// <summary>
    /// 实现平台业务
    /// </summary>
    public class Platform
    {
        private PlatformsRepository db;
        private PlatformsEntity Entity;
        public Platform() : base()
        {
            db = new PlatformsRepository();
        }

        public void initEntity(BaseModel model)
        {
            Entity = model.DtoToEntity<PlatformsEntity>();            
        }

        public BaseResponse<PlatformCRes>  insert()
        {
            int platformid = db.Create(Entity);
            PlatformCRes datas = new PlatformCRes { PlatformId =  platformid}  ;
            BaseResponse<PlatformCRes> result = new BaseResponse<PlatformCRes>() {  Data = datas  };
            return result;
        }

        public BaseResponse<PlatformsEntity> Get()
        {
            PlatformsEntity entity = db.Get(Entity.PlatformId);
            BaseResponse<PlatformsEntity> result = new BaseResponse<PlatformsEntity>() { Data = entity };
            return result;
        }

        public void Update()
        {
            db.Update(Entity);
        }

        public void Delete()
        {
            db.Delete(Entity);
        }

        public IEnumerable<PlatformsEntity> Gets()
        {
            return db.Gets(Entity);
        }

        public Tuple<IEnumerable<PlatformsEntity>, int> Page(int pageSize,int pageIndex)
        {
            return db.GetsPage(Entity, pageSize, pageIndex);
        }

        public void UpdateBatch(IEnumerable<PlatformsEntity> collection)
        {
            db.Update(collection);
        }

        public void InsertBatch(IEnumerable<PlatformsEntity> collection)
        {
            db.Insert(collection);
        }

    }
}
