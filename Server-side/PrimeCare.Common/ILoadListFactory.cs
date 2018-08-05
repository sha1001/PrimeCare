using System.Collections.Generic;

namespace USLBM.Mobile.Common
{
    public interface ILoadListFactory<TLoadParam, TEntity>
    {
        List<TEntity> LoadList(TLoadParam id);
    }
}
