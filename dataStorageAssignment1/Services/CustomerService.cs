using dataStorage.Contexts;
using dataStorage.Models;
using dataStorage.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace dataStorage.Services
{
    internal class CustomerService
    {
        private static DataContext _context = new DataContext();

        public static async Task SaveAsync(Errands errand)
        {
            var _errandEntity = new ErrandEntity
            {
                ErrandTimeCreated = errand.ErrandTimeCreated,
                CustomerDescription = errand.CustomerDescription,
            };

            //var _customerEntity = new CustomerEntity
            //{
            //    FirstName = errand.FirstName,
            //    LastName = errand.LastName,
            //    Email = errand.Email,
            //};

            //var _statusEntity = new ErrandStatusEntity
            //{
            //    Status = errand.Status
            //};

            //var _phoneEntity = new PhoneEntity
            //{
            //    CustomerPhoneNr = errand.CustomerPhoneNr
            //};

            var _customerEntity = await _context.Customers.FirstOrDefaultAsync(x => x.FirstName == errand.FirstName && x.LastName == errand.LastName && x.Email == errand.Email /*&& x.CustomerPhoneNr == errand.CustomerPhoneNr*/);
            //var _phoneEntity = await _context.PhoneNumber.FirstOrDefaultAsync(x => x.CustomerPhoneNr == errand.CustomerPhoneNr);
            var _statusEntity = await _context.ErrandStatus.FirstOrDefaultAsync(x => x.Status == errand.Status);
            var _commentEntity = await _context.CommentEntity.FirstOrDefaultAsync(x => x.TimeEmployeeComment == errand.TimeEmployeeComment && x.EmployeeComment == errand.EmployeeComment );


            if (_customerEntity != null)
                _errandEntity.Customer.Id = _customerEntity.Id;
            else
                _errandEntity.Customer = new CustomerEntity
                {
                    FirstName = errand.FirstName,
                    LastName = errand.LastName,
                    Email = errand.Email,
                    //CustomerPhoneNr = errand.CustomerPhoneNr

                };

            //if (_phoneEntity != null)
            //    _errandEntity.Customer.Id = _phoneEntity.Id;
            //else
            //    _errandEntity.CustomerPhoneNr = new PhoneEntity
            //    {
            //        CustomerPhoneNr = errand.CustomerPhoneNr
            //    };

            if (_commentEntity != null)
                _errandEntity.Customer.Id = _commentEntity.Id;
            else
                _errandEntity.EmployeeComment = new CommentEntity
                {
                    TimeEmployeeComment = errand.TimeEmployeeComment,
                    EmployeeComment = errand.EmployeeComment
                };


            if (_statusEntity != null)
                _errandEntity.Customer.Id = _statusEntity.Id;
            else
                _errandEntity.ErrandStatus = new ErrandStatusEntity
                {
                    Status = errand.Status
                };


            _context.Add(_errandEntity);
            await _context.SaveChangesAsync();
        }


        public static async Task<IEnumerable<Errands>> GetAllAsync()
        {
            var _errands = new List<Errands>();
     

            foreach (var _errand in await _context.Errands.Include(x => x.Customer).ToListAsync())
                _errands.Add(new Errands
                {
                    Id = _errand.Id,
                    FirstName = _errand.Customer.FirstName,
                    LastName = _errand.Customer.LastName,
                    Email = _errand.Customer.Email,
                    //CustomerPhoneNr = _errand.Customer.CustomerPhoneNr,
                    ErrandTimeCreated = _errand.ErrandTimeCreated,
                    CustomerDescription = _errand.CustomerDescription,
                    Status = _errand.ErrandStatus.Status,
                    TimeEmployeeComment = _errand.EmployeeComment.TimeEmployeeComment,
                    EmployeeComment = _errand.EmployeeComment.EmployeeComment   
                });

            return _errands;
        }


        public static async Task<Errands> GetAsync(string Id )
        {
            var _errand = await _context.Errands.Include(x => x.Customer.Id).FirstOrDefaultAsync(x => x.Customer.Id.ToString() == Id);

            if (_errand != null)
                return new Errands
                {
                    Id = _errand.Id,
                    FirstName = _errand.Customer.FirstName,
                    LastName = _errand.Customer.LastName,
                    Email = _errand.Customer.Email,
                    //CustomerPhoneNr = _errand.Customer.CustomerPhoneNr,
                    ErrandTimeCreated = _errand.ErrandTimeCreated,
                    CustomerDescription = _errand.CustomerDescription,
                    Status = _errand.ErrandStatus.Status,
                    TimeEmployeeComment = _errand.EmployeeComment.TimeEmployeeComment,
                    EmployeeComment = _errand.EmployeeComment.EmployeeComment
                };
            else
                return null!;
        }


        public static async Task UpdateAsync(Errands errands)
        {
            var _errandsEntity = await _context.ErrandStatus.Include(x => x.Status).FirstOrDefaultAsync(x => x.Id == errands.Id);

            if (_errandsEntity != null)
            {
                //Errand status -----------------------------------------
                if (!string.IsNullOrEmpty(errands.Status))
                {
                    _errandsEntity.Status = errands.Status;
                }
                    
                _context.Update(_errandsEntity);
                await _context.SaveChangesAsync();
            }
        }

    }
}
