using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using HotelProject.WebUI.Models.Role;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.WebUI.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;

        public RoleController(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager ?? throw new ArgumentNullException(nameof(roleManager));
        }

        public IActionResult Index()
        {
            var roles = _roleManager.Roles.ToList();
            return View(roles);
        }

        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(AddRoleViewModel arvm)
        {
            AppRole role = new AppRole()
            {
                Name = arvm.RoleName
            };
            var result = await _roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteRole(int id)
        {
            var value = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            await _roleManager.DeleteAsync(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateRole(int id)
        {
            var value = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            UpdateRoleViewModel urvm = new UpdateRoleViewModel()
            {
                RoleID = value.Id,
                RoleName = value.Name,
            };
            return View(urvm);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRole(UpdateRoleViewModel urvm)
        {
            var value = _roleManager.Roles.FirstOrDefault(x => x.Id == urvm.RoleID);
            value.Name = urvm.RoleName;
            await _roleManager.UpdateAsync(value);
            return RedirectToAction("Index");
        }
    }
}
