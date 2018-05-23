using DataLayer.Entities.CommonEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationLayer.Models.Directorys
{
    public class MaterialViewModel
    {
        public Material Material { get; set; }
       
        public MaterialViewModel() { }
        public MaterialViewModel(Material material)
        {
            Material = material;
        }
    }
}
