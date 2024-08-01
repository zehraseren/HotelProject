namespace HotelProject.BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        void TInsert(T t);
        void TDelete(T t);
        void Tupdate(T t);
        List<T> TGetList();
        T TGetByID(int id);
    }
}
