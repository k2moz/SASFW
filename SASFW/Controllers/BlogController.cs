using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer;

namespace SASFW.Controllers
{
    public class BlogController : Controller
    {
        private DataManager _dataManager;
        private ServicesManager _servicesManager;

        public BlogController(DataManager dataManager)
        {
            _dataManager = dataManager;
            _servicesManager = new ServicesManager(dataManager);
        }

        public IActionResult Index()
        {
            ///TODO:3005 - hard code (replace on types dependency)
            var _blogDirectory = _servicesManager.Directorys.GetDirectoryViewModelByDirectoryId(15);
            return View(_blogDirectory);
        }

        public IActionResult BlogItem(int itemId)
        {
            var _blogItem = _servicesManager.Directorys.GetMaterialPageViewModelByMaterialId(itemId);
            return View(_blogItem);
        }
    }
}