using DataLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationLayer.Models.Common
{
    public class QuickLinqViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string CallToAction { get; set; }
        public string Preview { get; set; }
        public EntitiesEnum LinkEntity { get; set; }
        public int EntityId { get; set; }
        
    }
}
