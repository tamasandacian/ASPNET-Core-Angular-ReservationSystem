using System.Collections.Generic;
using webapi.Helpers;
using webapi.Models.ViewModels;
using System.Linq;

namespace webapi.Services
{
    public interface IFieldService 
    {
        List<FieldVM> GetListOfFields();
    }

    public class FieldService : IFieldService
    {

        private readonly DBContext _dbContext;

        public FieldService(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<FieldVM> GetListOfFields()
        {

            var listOfFields = (from f in _dbContext.Fields
                                join fd in _dbContext.FieldDetails 
                                on f.FieldId equals fd.FieldId
                                select new FieldVM{
                                   FieldId = f.FieldId,
                                   Title = f.Title,
                                   ImageURL = f.ImageURL,
                                   PathURL = f.PathURL,
                                   PriceHour = f.PriceHour,
                                   Description = fd.Description,
                                   Address = fd.Address,
                                   StartProgram = fd.StartProgram,
                                   EndProgram = fd.EndProgram
                                }).ToList();
        
            return listOfFields;
        }
    }
}