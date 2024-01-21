using ShopCar.Core.Domain;
using ShopCar.Core.Dto;

namespace ShopCar.Core.ServiceInterface
{
    public interface IShopCarServices
    {
        Task<ShopCarDomain> Create(ShopCarDto dto);
        Task<ShopCarDomain> Update(ShopCarDto dto);
        Task<ShopCarDomain> Delete(Guid id);
        Task<ShopCarDomain> GetAsync(Guid id);
    }
}
