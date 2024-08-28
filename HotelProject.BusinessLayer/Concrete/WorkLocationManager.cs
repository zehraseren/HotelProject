using HotelProject.EntityLayer.Concrete;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;

namespace HotelProject.BusinessLayer.Concrete
{
    public class WorkLocationManager : IWorkLocationService
    {
        private readonly IWorkLocationDal _workLocationDal;

        public WorkLocationManager(IWorkLocationDal workLocationDal)
        {
            _workLocationDal = workLocationDal ?? throw new ArgumentNullException(nameof(workLocationDal));
        }

        public void TDelete(WorkLocation t)
        {
            _workLocationDal.Delete(t);
        }

        public WorkLocation TGetByID(int id)
        {
            return _workLocationDal.GetByID(id);
        }

        public List<WorkLocation> TGetList()
        {
            return _workLocationDal.GetList();
        }

        public void TInsert(WorkLocation t)
        {
            _workLocationDal.Insert(t);
        }

        public void TUpdate(WorkLocation t)
        {
            _workLocationDal.Update(t);
        }
    }
}
