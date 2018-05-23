using CoreApp.DataProvider.Abstratction;
using CoreApp.DataService.Abstraction.Interfaces;
using CoreApp.Models.DataTransfer;
using CoreApp.Models.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp.DataService.Abstraction
{
    public abstract class BaseEntityService<TModel, TDto> : IEntityService<TDto>
                where TDto : DtoBase
                where TModel : BaseEntityModel
    {
        private readonly EntityDataProviderBase<TModel, TDto> _dataProvider;
        protected EntityDataProviderBase<TModel, TDto> DataProvider => _dataProvider;

        protected UnitOfWork Uow { get; set; }

        protected BaseEntityService(EntityDataProviderBase<TModel, TDto> dataProvider)
        {
            _dataProvider = dataProvider;
            Uow = new UnitOfWork();
            if (_dataProvider != null) _dataProvider.Context = Uow.GetContext();
        }

        public int CurrentUserId { get; set; }
        public int CurrentEmployeeId { get; set; }

        public virtual async Task<IEnumerable<TDto>> ListOfDtoAsync() => await DataProvider.ListOfEntitiesAsync();

        #region IDisposable
        public void Dispose() => Uow.Dispose();
        #endregion
    }
}
