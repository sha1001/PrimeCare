namespace USLBM.Mobile.Common
{
    public interface ILoadFactory<TLoadParam,TEntity>
    {
        TEntity Load(TLoadParam id);
    }
}

