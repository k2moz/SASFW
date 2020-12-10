using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer;
using PresentationLayer.Models.Directorys;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using DataLayer.Entities.CommonEntities;
using Microsoft.AspNetCore.Authorization;
using DataLayer.Entities;

namespace SASFW.Controllers
{
    [Authorize(Policy = "AdminOnly")]
    //[DisableRequestSizeLimit]
    public class AdminController : Controller
    {
        private DataManager _dataManager;
        private ServicesManager _servicesManager;


        public AdminController(DataManager dataManager)
        {
            _dataManager = dataManager;
            _servicesManager = new ServicesManager(dataManager);
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DirictorysEditor()
        {
            return View();
        }

        #region Api

        public JsonResult getDirectoryesList()
        {
            var _directorys = _dataManager.Directorys.GetAllItems();
            List<DirectoryViewModel> directorysModelsList = new List<DirectoryViewModel>();
            foreach (var item in _directorys.Where(x => x.Status != DataLayer.PageStatusEnum.Delete))
            {
                directorysModelsList.Add(_servicesManager.Directorys.GetDirectoryViewModelByDirectoryId(item.Id));
            }
            return Json(directorysModelsList);
        }

        #region Directory

        public JsonResult saveDirectory(string directoryJson)
        {
            var directory = JsonConvert.DeserializeObject<DirectoryViewModel>(directoryJson);
            directory.Directory.LastUpdateDateTime = DateTime.Now;
            _servicesManager.Directorys.SaveDirectoryViewModelToDb(directory);
            return Json(directory);
        }

        public JsonResult removeDirectory(string directoryJson)
        {
            var directory = JsonConvert.DeserializeObject<DirectoryViewModel>(directoryJson);
            directory.Directory.Status = DataLayer.PageStatusEnum.Delete;
            _servicesManager.Directorys.SaveDirectoryViewModelToDb(directory);
            return Json(directory);
        }

        public JsonResult getDirectory(int directoryId)
        {
            return Json(_servicesManager.Directorys.GetDirectoryViewModelByDirectoryId(directoryId));
        }


        #endregion


        #region Materials

        public JsonResult getMaterial(int materialId)
        {
            return Json(_servicesManager.Directorys.GetMaterialViewModelByMaterialId(materialId));
        }

        public JsonResult saveMaterial(string materialJson)
        {
            var material = JsonConvert.DeserializeObject<MaterialViewModel>(materialJson);
            _servicesManager.Directorys.SaveMaterialViewModelToDb(material);
            return Json(material);
        }

        public JsonResult removeMaterial(string materialJson)
        {
            var material = JsonConvert.DeserializeObject<MaterialViewModel>(materialJson);
            material.Material.Status = DataLayer.PageStatusEnum.Delete;
            _servicesManager.Directorys.SaveMaterialViewModelToDb(material);
            return Json(material);
        }

        //[DisableRequestSizeLimit]
        //[RequestSizeLimit(100_000_000)]
        public JsonResult updateMaterial(string materialJson)
        {
            var material = JsonConvert.DeserializeObject<MaterialViewModel>(materialJson);
            _servicesManager.Directorys.SaveMaterialViewModelToDb(material);
            return Json(material);
        }

        public JsonResult materialsSort(string jsonMaterials)
        {
            try
            {
                JObject o = JObject.Parse(jsonMaterials);
                Material materialFrom = JsonConvert.DeserializeObject<Material>(o["materialFrom"].ToString());
                Material materialTo = JsonConvert.DeserializeObject<Material>(o["materialTo"].ToString());

                var _buffer = materialFrom.Order;
                materialFrom.Order = materialTo.Order;
                materialTo.Order = _buffer;

                _dataManager.Materials.UpdateItem(materialFrom);
                _dataManager.Materials.UpdateItem(materialTo);
                return Json(true);
            }
            catch (Exception e)
            {
                throw new Exception("WTF");
            }
        }
        #endregion


        #endregion
        public IActionResult MaterialsEditor()
        {
            return View();
        }

        public IActionResult CustumFieldsEditor()
        {
            return View();
        }

        public IActionResult TypesEditor()
        {
            return View();
        }

    }
}