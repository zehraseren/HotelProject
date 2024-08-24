using HotelProject.EntityLayer.Concrete;

namespace HotelProject.DataAccessLayer.Abstract
{
    public interface ISendMessageDal : IGenericDal<SendMessage>
    {
        public int GetSendMessageCount();
    }
}
