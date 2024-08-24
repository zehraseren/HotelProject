using HotelProject.EntityLayer.Concrete;

namespace HotelProject.BusinessLayer.Abstract
{
    public interface ISendMessageService : IGenericService<SendMessage>
    {
        public int TGetSendMessageCount();
    }
}
