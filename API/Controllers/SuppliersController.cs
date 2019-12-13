using Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Data.Repository.Interface;
using Data.Model;
using Data.ViewModel;
using API.Service.Interface;
using API.Service;

namespace API.Controllers
{
    public class SuppliersController : ApiController
    {
        //private readonly ISupplierRepository _supplierService;
        ISupplierRepository supplier = new supplierRepository();
        ISupplierService service = new SupplierService();
        // GET: api/Suppliers

        public SuppliersController() { }

        public SuppliersController(ISupplierRepository supplierService)
        {
            supplier = supplierService;
        }
        public IEnumerable<Supplier> Get()
        {
            var data = service.Get();
            return data;
        }

        // GET: api/Suppliers/5
        public Supplier Get(int id)
        {
            var get = service.Get(id);
            return get;
        }

        // POST: api/Suppliers
        [HttpPost]
        public int Post(SupplierVM supplierVM)
        {
            var data = service.Create(supplierVM);
            return data;
        }

        // PUT: api/Suppliers/5
        public void Put(int id, SupplierVM supplierVM)
        {
            service.Update(id, supplierVM);
        }

        // DELETE: api/Suppliers/5
        public void Delete(int id)
        {
            service.Delete(id);
        }
    }
}
