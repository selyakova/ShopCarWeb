using Microsoft.EntityFrameworkCore;
using ShopCar.Core.Domain;
using ShopCar.Core.Dto;
using ShopCar.Core.ServiceInterface;
using ShopCar.Data;

namespace ShopCar.ApplicationServices.Services
{
    public class ShopCarServices : IShopCarServices
    {
        private readonly CarShopContext _context;

        public ShopCarServices(CarShopContext context)
        {
            _context = context;
        }

        public async Task<ShopCarDomain> Create(ShopCarDto dto)
        {
            ShopCarDomain car = new ShopCarDomain();

            car.Id = Guid.NewGuid();
            car.Brand = dto.Brand;
            car.Model = dto.Model;
            car.ModelYear = dto.ModelYear;
            car.Price = dto.Price;
            car.CreatedAt = DateTime.Now;
            car.UpdatedAt = DateTime.Now;

            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();
            return car;
        }

        public async Task<ShopCarDomain> Update(ShopCarDto dto)
        {
            var domain = new ShopCarDomain()
            {
                Id = dto.Id,
                Brand = dto.Brand,
                Model = dto.Model,
                ModelYear = dto.ModelYear,
                Price = dto.Price,
                CreatedAt = dto.CreatedAt,
                UpdatedAt = DateTime.Now
            };

            _context.Cars.Update(domain);
            await _context.SaveChangesAsync();
            return domain;
        }

        public async Task<ShopCarDomain> Delete(Guid id)
        {
            var carId = await _context.Cars
                .FirstOrDefaultAsync(x => x.Id == id);

            _context.Cars.Remove(carId);
            await _context.SaveChangesAsync();
            return carId;
        }

        public async Task<ShopCarDomain> GetAsync(Guid id)
        {
            var result = await _context.Cars
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }
    }
}
