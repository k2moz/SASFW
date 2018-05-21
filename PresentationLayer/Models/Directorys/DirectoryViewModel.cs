using BusinessLayer;
using DataLayer.Entities.CommonEntities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PresentationLayer.ViewModels.Directorys
{
    [Serializable]
    public class DirectoryViewModel
    {
        public Directory Directory { get; set; }
        public Dictionary<string, List<MaterialViewModel>> Materials { get; set; }
        //public List<MaterialViewModel> Materials {get;set;}


        public DirectoryViewModel()
        {

        }
        public DirectoryViewModel(Directory directory, IEnumerable<Material> materials)
        {

            Directory = directory;
            Materials = new Dictionary<string, List<MaterialViewModel>>();
            var _currentCategoty = "";
            if (materials.Count() > 0)
                foreach (var item in (List<Material>)materials.OrderBy(x => x.Order))
                {
                    if (!string.IsNullOrEmpty(_currentCategoty) && _currentCategoty != item.Category)
                    {
                        _currentCategoty = item.Category;
                        Materials.Add(_currentCategoty, new List<MaterialViewModel>());
                    }
                    else { continue; }

                    var _categoryList = (List<Material>)materials.Where(x => x.Category == _currentCategoty).OrderBy(x => x.Order);
                    foreach (var subItem in _categoryList)
                    {
                        var _materialModel = new MaterialViewModel(subItem);
                        Materials[_currentCategoty].Add(_materialModel);
                    }
                }
            else
            {
                Materials.Add("", new List<MaterialViewModel>());
            }
        }
    }

    //public class DirectoryEditModel
    //{

    //    public Directory Directory { get; set; }
    //    public List<MaterialViewModel> Materials { get; set; }

    //    public DirectoryViewModel() { }
    //    public DirectoryViewModel(Directory directory, IEnumerable<Material> materials)
    //    {
    //        Directory = directory;
    //        foreach (var item in materials)
    //        {
    //            Materials.Add(new MaterialViewModel(item));
    //        }
    //    }
    //}
}
