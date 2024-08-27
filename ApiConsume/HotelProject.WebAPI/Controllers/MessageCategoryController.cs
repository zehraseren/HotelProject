using Microsoft.AspNetCore.Mvc;
using HotelProject.EntityLayer.Concrete;
using HotelProject.BusinessLayer.Abstract;

namespace HotelProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageCategoryController : ControllerBase
    {
        private readonly IMessageCategoryService _messageCategoryService;

        public MessageCategoryController(IMessageCategoryService messageCategoryService)
        {
            _messageCategoryService = messageCategoryService;
        }

        [HttpGet]
        public IActionResult MessageCategoryList()
        {
            var values = _messageCategoryService.TGetList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddMessageCategory(MessageCategory messageCategory)
        {
            _messageCategoryService.TInsert(messageCategory);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMessageCategory(int id)
        {
            var values = _messageCategoryService.TGetByID(id);
            _messageCategoryService.TDelete(values);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateMessageCategory(MessageCategory messageCategory)
        {
            _messageCategoryService.TUpdate(messageCategory);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetMessageCategory(int id)
        {
            var values = _messageCategoryService.TGetByID(id);
            return Ok(values);
        }
    }
}
