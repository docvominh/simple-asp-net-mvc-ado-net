using DataObject.DTO;
using DataObject.ViewModel;
using Services.User;
using System.Web.Mvc;

namespace simple_mvc_adonet.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserServices userServices;

        public UserController(IUserServices userServices)
        {
            this.userServices = userServices;
        }

        // GET: User
        public ActionResult List()
        {
            UserIndexModel model = new UserIndexModel()
            {
                ListUser = userServices.FindAll(),
                User = new UserDTO()
            };

            return View(model);
        }

        // GET: User
        public ActionResult CreateView()
        {
            return View();
        }

        // GET: User
        [HttpPost]
        public ActionResult Create()
        {
            return View();
        }

        // GET: User
        [HttpPost]
        public ActionResult Search(SearchUserConditionModel condition)
        {
            return View();
        }
    }
}