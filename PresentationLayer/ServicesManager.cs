using BusinessLayer;
using PresentationLayer.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationLayer
{
    public class ServicesManager
    {
        private DataManager dataManager;
        private DirectoryService _directoryService;

        public ServicesManager(DataManager dataManager)
        {
            this.dataManager = dataManager;
            _directoryService = new DirectoryService(dataManager);
        }

        public DirectoryService Directorys { get { return _directoryService; } }
      
    }
}
