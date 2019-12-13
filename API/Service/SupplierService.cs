using API.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data.Model;
using Data.ViewModel;
using Data.Repository.Interface;
using Data.Repository;

namespace API.Service
{
    public class SupplierService : ISupplierService
    {
        ISupplierRepository _supplierRepository = new supplierRepository();

        public int Delete(int Id)
        {
            if (string.IsNullOrWhiteSpace(Id.ToString()))
            {
                return 0;
            }
            else
            {
                return _supplierRepository.Delete(Id);
            }
        }

        public IEnumerable<Supplier> Get()
        {
            return _supplierRepository.Get();
        }
        public Supplier Get(int Id)
        {
            return _supplierRepository.Get(Id);
        }

        public int Create(SupplierVM supplierVM)
        {
            if (string.IsNullOrWhiteSpace(supplierVM.Name) || string.IsNullOrWhiteSpace(supplierVM.Email))
            {
                return 0;
            }
            else
            {
                return _supplierRepository.Create(supplierVM);
            }
        }

        public int Update(int id, SupplierVM supplierVM)
        {
            if (string.IsNullOrWhiteSpace(supplierVM.Name) ||
                string.IsNullOrWhiteSpace(supplierVM.Email))
            {
                return 0;
            }
            else
            {
                return _supplierRepository.Update(id, supplierVM);
            }

        }
    }
}