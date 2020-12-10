using BusinessLayer;
using PresentationLayer.Models.Directorys;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PresentationLayer.Models.Directorys;

namespace PresentationLayer.Services
{
    public class DirectoryService
    {
        private DataManager dataManager;
        public DirectoryService(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        /// <summary>
        /// Получить ViewModel Directory c Materials по Id дирректории
        /// </summary>
        /// <param name="directoryId"></param>
        /// <returns></returns>
        public DirectoryViewModel GetDirectoryViewModelByDirectoryId(int directoryId)
        {
            var _directory = dataManager.Directorys.GetItemById(directoryId);
            if (_directory != null)
            {
                var _materials = dataManager.Materials.Get(x => x.DirectoryId == directoryId && x.Status != DataLayer.PageStatusEnum.Delete);
                return new DirectoryViewModel(_directory, _materials);
            }
            else { return null; }
        }

        /// <summary>
        /// Сохранить Деррикторию из модели
        /// </summary>
        /// <param name="directoryViewModel"></param>
        /// <param name="sortedContent"></param>
        /// <returns></returns>
        public DirectoryViewModel SaveDirectoryViewModelToDb(DirectoryViewModel directoryViewModel)
        {
            var _directory = directoryViewModel.Directory;
            _directory.LastUpdateDateTime = DateTime.Now;
            
            if (directoryViewModel.Directory.Id == 0)
            {
                _directory.CreatedDateTime = DateTime.Now;
                dataManager.Directorys.CreateItem(_directory);
            }
            else
            {
                dataManager.Directorys.UpdateItem(_directory);
            }
            directoryViewModel.Directory = _directory;
            return directoryViewModel;
        }

        /// <summary>
        /// Получить MaterialViewModel по id
        /// </summary>
        /// <param name="materialId">Id материала</param>
        /// <returns></returns>
        public MaterialViewModel GetMaterialViewModelByMaterialId(int materialId)
        {
            var _material = dataManager.Materials.GetItemById(materialId);
            if (_material != null)
            {
                return new MaterialViewModel(_material);
            }
            else { return null; }
        }


        public MaterialPageViewModel GetMaterialPageViewModelByMaterialId(int materialId)
        {
            var _materialmodel = GetMaterialViewModelByMaterialId(materialId);
            var _directoryModel = GetDirectoryViewModelByDirectoryId(_materialmodel.Material.DirectoryId);
            var _model = new MaterialPageViewModel()
            {
                Material = _materialmodel,
                Directory = _directoryModel,
            };

            try
            {
                var _prevPage = _directoryModel.Directory.DirectoryPages[_materialmodel.Material.Order.Value - 1];
                _model.PrevMaterialPage = new Models.Common.QuickLinqViewModel()
                {
                    LinkEntity = DataLayer.EntitiesEnum.Page,
                    EntityId = _prevPage.Id,
                    Title = _prevPage.Title,
                    Description = _prevPage.SeoDescription,
                    Preview = _prevPage.smallPreview,
                    CallToAction = "PREVIOUS",
                };
            }
            catch { }
            try
            {
                var _nextPage = _directoryModel.Directory.DirectoryPages[_materialmodel.Material.Order.Value+1];
                _model.PrevMaterialPage = new Models.Common.QuickLinqViewModel()
                {
                    LinkEntity = DataLayer.EntitiesEnum.Page,
                    EntityId = _nextPage.Id,
                    Title = _nextPage.Title,
                    Description = _nextPage.SeoDescription,
                    Preview = _nextPage.smallPreview,
                    CallToAction = "NEXT",
                };
            }
            catch { }
            return _model;
        }

        public MaterialViewModel SaveMaterialViewModelToDb(MaterialViewModel material)
        {
            if (material.Material.Id == 0)
            {
                material.Material.CreatedDateTime = DateTime.Now;
                material.Material.LastUpdateDateTime = DateTime.Now;
                material.Material.Status = DataLayer.PageStatusEnum.Created;
                //material.Material.SeoUrl = material.Material.Title.UrlTransform();

                material.Material.Order = dataManager.Materials.Get(x => x.DirectoryId == material.Material.DirectoryId).Count();
                dataManager.Materials.CreateItem(material.Material);
            }
            else
            {
                material.Material.LastUpdateDateTime = DateTime.Now;
                //material.Material.SeoUrl = material.Material.Title.UrlTransform();
                dataManager.Materials.UpdateItem(material.Material);
            }
            return material;
        }
    }
}
