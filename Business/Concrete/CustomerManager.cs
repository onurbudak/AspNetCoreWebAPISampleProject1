using Business.Abstract;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Log4Net;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        [LogAspect(typeof(FileLogger))]
        public IResult Add(Customer entity)
        {

            _customerDal.Add(entity);
            return new SuccessResult();
        }

        [LogAspect(typeof(FileLogger))]
        public IResult Delete(Customer entity)
        {

            _customerDal.Delete(entity);
            return new SuccessResult();

        }

        [LogAspect(typeof(FileLogger))]
        public IDataResult<Customer> Get(int id)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(r => r.Id == id));
        }

        [LogAspect(typeof(FileLogger))]
        public IDataResult<List<Customer>> GetAll()
        {

            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll());
        }

        [LogAspect(typeof(FileLogger))]
        public IResult Update(Customer entity)
        {

            _customerDal.Update(entity);
            return new SuccessResult();

        }
    }
}
