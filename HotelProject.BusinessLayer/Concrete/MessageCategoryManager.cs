using HotelProject.EntityLayer.Concrete;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;

namespace HotelProject.BusinessLayer.Concrete
{
    public class MessageCategoryManager : IMessageCategoryService
    {
        private readonly IMessageCategoryDal _messageCategoryDal;

        public MessageCategoryManager(IMessageCategoryDal messageCategoryDal)
        {
            _messageCategoryDal = messageCategoryDal ?? throw new ArgumentNullException(nameof(messageCategoryDal));
        }

        public void TDelete(MessageCategory t)
        {
            _messageCategoryDal.Delete(t);
        }

        public MessageCategory TGetByID(int id)
        {
            return _messageCategoryDal.GetByID(id);
        }

        public List<MessageCategory> TGetList()
        {
            return _messageCategoryDal.GetList();
        }

        public void TInsert(MessageCategory t)
        {
            _messageCategoryDal.Insert(t);
        }

        public void TUpdate(MessageCategory t)
        {
            _messageCategoryDal.Update(t);
        }
    }
}
