using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Models.Role;

namespace HotelProject.WebUI.Controllers
{
    public class RoleAssignController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public RoleAssignController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _roleManager = roleManager ?? throw new ArgumentNullException(nameof(roleManager));
        }

        public IActionResult Index()
        {
            var values = _userManager.Users.ToList();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> AssignRole(int id)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
            TempData["userid"] = user.Id;
            var roles = _roleManager.Roles.ToList();
            var userRoles = await _userManager.GetRolesAsync(user);
            List<RoleAssignViewModel> assignments = new List<RoleAssignViewModel>();
            foreach (var item in roles)
            {
                RoleAssignViewModel ravm = new RoleAssignViewModel();
                ravm.RoleID = item.Id;
                ravm.RoleName = item.Name;
                ravm.RoleExist = userRoles.Contains(item.Name);
                assignments.Add(ravm);
            }
            return View(assignments);
        }

        [HttpPost]
        public async Task<IActionResult> AssignRole(List<RoleAssignViewModel> ravm)
        {
            var userid = (int)TempData["userid"];
            var user = _userManager.Users.FirstOrDefault(x => x.Id == userid);
            foreach (var item in ravm)
            {
                if (item.RoleExist)
                {
                    await _userManager.AddToRoleAsync(user, item.RoleName);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, item.RoleName);
                }
            }
            return RedirectToAction("Index");
        }
    }
}
