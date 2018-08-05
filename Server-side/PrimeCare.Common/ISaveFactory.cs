namespace USLBM.Mobile.Common
{
    public interface ISaveFactory<TEntity>
    {
        TEntity Save(TEntity entity);
    }
}
