using ShopCar.Core.Dto;
using ShopCar.Core.ServiceInterface;
using ShopCar.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ShopCar.ApplicationServices.Services
{
    public class ShopCarServices : IShopCarServices
    {
        private readonly CarShopContext _context;

        public ShopCarServices(CarShopContext context)
        {
            _context = context;
        }

        public async Task<Car> Create(ShopCarDto dto)
        {
            Car car = new Car();

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

        public async Task<Car> Update(ShopCarDto dto)
        {
            var domain = new Car()
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

        public async Task<Car> Delete(Guid id)
        {
            var carId = await _context.Cars
                .FirstOrDefaultAsync(x => x.Id == id);

            _context.Cars.Remove(carId);
            await _context.SaveChangesAsync();
            return carId;
        }

        public async Task<Car> GetAsync(Guid id)
        {
            var result = await _context.Cars
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }
    }
}
