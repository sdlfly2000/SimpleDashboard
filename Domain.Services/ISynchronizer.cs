namespace Domain.Services
{
    public interface ISynchronizer<out TReference, in TAspect> 
        where TReference : class 
        where TAspect : class
    {
        void Synchronize(TAspect aspect);

        TReference Add(TAspect aspect);
    }
}
