using SY.Com.Medical.Entity;
using SY.Com.Medical.Model;
using SY.Com.Medical.Repository.Platform;

namespace SY.Com.Medical.BLL.Platform
{
    /// <summary>
    /// 实现平台业务
    /// </summary>
    public class Platform : CURDObject<PlatformsEntity>
    {
        public Platform() : base()
        {
            Entity = new PlatformsEntity();
            db = new PlatformsRepository();
        }

        public void initEntity(PlatformCReq model)
        {
            this.ModelToBLL<PlatformsEntity, PlatformCReq>(model);
        }

        public BaseResponse<PlatformCRes>  insert()
        {
            int platformid = base.Create(Entity);
            PlatformCRes datas = new PlatformCRes { PlatformId =  platformid}  ;
            BaseResponse<PlatformCRes> result = new BaseResponse<PlatformCRes>() {  Data = datas  };
            return result;
        }

    }
}
