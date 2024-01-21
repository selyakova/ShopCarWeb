using ShopCar.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ShopCar.Core.ServiceInterface
{
    public interface IShopCarServices
    {
        Task<ShopCar> Create(ShopCarDto dto);
        Task<ShopCar> Update(ShopCarDto dto);
        Task<ShopCar> Delete(Guid id);
        Task<ShopCar> GetAsync(Guid id);
    }
}
