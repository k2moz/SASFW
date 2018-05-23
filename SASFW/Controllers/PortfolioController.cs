using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer;

namespace SASFW.Controllers
{
    public class PortfolioController : Controller
    {
        private DataManager _dataManager;
        private ServicesManager _servicesManager;

        public PortfolioController(DataManager dataManager)
        {
            _dataManager = dataManager;
            _servicesManager = new ServicesManager(dataManager);
        }

        public IActionResult Index()
        {
            ///TODO:3005 - hard code (replace on types dependency)
            var _portfolioDirectory = _servicesManager.Directorys.GetDirectoryViewModelByDirectoryId(3005);
            return View(_portfolioDirectory);
        }

        public IActionResult PortfolioItem(int itemId)
        {
            var _portfolioItem = _servicesManager.Directorys.GetMaterialPageViewModelByMaterialId(itemId);
            return View(_portfolioItem);
        }
    }
}