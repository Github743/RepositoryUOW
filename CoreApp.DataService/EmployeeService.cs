using CoreApp.DataProvider;
using CoreApp.DataService.Abstraction;
using CoreApp.DataService.Abstraction.Interfaces;
using CoreApp.Models.Models;
using DTO = CoreApp.Models.DataTransfer;

namespace CoreApp.DataService
{
    public class EmployeeService : BaseEntityService<Employee, DTO.Employee>, IEmployeeService
    {
        private readonly EmployeeDataProvider _dataProvider;

        public EmployeeService(EmployeeDataProvider dataProvider) : base(dataProvider)
        {
            _dataProvider = dataProvider;
        }
    }
}
