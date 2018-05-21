using BusinessLayer;
using PresentationLayer.ViewModels.Directorys;
using System;
using System.Collections.Generic;
using System.Text;

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
            if(_directory!=null)
            {
                var _materials = dataManager.Materials.Get(x => x.DirectoryId == directoryId && x.Status!= DataLayer.PageStatusEnum.Delete);
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
            if(_material!=null)
            {
                return new MaterialViewModel(_material);
            }
            else { return null; }
        }

        public MaterialViewModel SaveMaterialViewModelToDb(MaterialViewModel material)
        {
            if(material.Material.Id==0)
            {
                dataManager.Materials.CreateItem(material.Material);
            }
            else
            {
                dataManager.Materials.UpdateItem(material.Material);
            }
            return material;
        }
    }
}
