using DataLayer.Entities.CommonEntities;
using PresentationLayer.Models.Common;
using PresentationLayer.Models.Directorys;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationLayer.Models.Directorys
{
    public class MaterialPageViewModel
    {
        public DirectoryViewModel Directory { get; set; }
        public MaterialViewModel Material { get; set; }
        public QuickLinqViewModel NextMaterialPage { get; set; }
        public QuickLinqViewModel PrevMaterialPage { get; set; }
    }
}
