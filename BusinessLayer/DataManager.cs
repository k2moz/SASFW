using BusinessLayer.Interfaces;
using DataLayer.Entities;
using DataLayer.Entities.CommonEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public class DataManager
    {
        //private IUsersRepository _usersRepository;

        private ICustumRepository<User> _usersRepository;
        private ICustumRepository<Directory> _directoryesRepository;
        private ICustumRepository<Material> _materialsRepository;

        private ICustumRepository<CustumContent> _contentRepository;
        private ICustumRepository<CustumField> _fieldsRepository;
        private ICustumRepository<CustumFieldValue> _fieldValuesRepository;

        public DataManager(
            //IUsersRepository usersRepository
            ICustumRepository<User> usersRepository,
            ICustumRepository<Directory> directoryesRepository,
            ICustumRepository<Material> materialsRepository,
            ICustumRepository<CustumContent> contentRepository,
            ICustumRepository<CustumField> fieldsRepository,
            ICustumRepository<CustumFieldValue> fieldValuesRepository
            )
        {
            _usersRepository = usersRepository;
            _materialsRepository = materialsRepository;
            _directoryesRepository = directoryesRepository;
            _contentRepository = contentRepository;
            _fieldsRepository = fieldsRepository;
            _fieldValuesRepository = fieldValuesRepository;
    }

        
        public ICustumRepository<User> Users { get {return  _usersRepository; } }
        public ICustumRepository<Directory> Directorys { get { return _directoryesRepository; } }
        public ICustumRepository<Material> Materials { get { return _materialsRepository; } }
        public ICustumRepository<CustumContent> Contents { get { return _contentRepository; } }
        public ICustumRepository<CustumField> Fields { get { return _fieldsRepository; } }
        public ICustumRepository<CustumFieldValue> FieldsValues { get { return _fieldValuesRepository; } }
}
}
