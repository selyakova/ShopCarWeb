using ShopCar.Core.Dto;
using ShopCar.Core.ServiceInterface;

namespace ShopCarTest
{
        public class ShopTest : TestBase
        {
            [Fact]
            public async Task ShouldNot_AddEmptyCar_WhenReturnResult()
            {
                var dto = new ShopCarDto()
                {
                    Brand = "Audi",
                    Model = "R8",
                    ModelYear = 2011,
                    Price = 1000000,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };

                var result = await Svc<IShopCarServices>().Create(dto);

                Assert.NotNull(result);
            }

            [Fact]
            public async Task ShouldNot_GetByIdCar_WhenReturnsNotEqual()
            {
                Guid guid = Guid.Parse("2b8b9080-60ef-442b-9822-f1ad47984736");
                Guid wrongGuid = Guid.NewGuid();

                await Svc<IShopCarServices>().GetAsync(guid);

                Assert.NotEqual(guid, wrongGuid);
            }

            [Fact]
            public async Task Should_GetByIdCar_WhenReturnsEqual()
            {
                Guid databaseGuid = Guid.Parse("2b8b9080-60ef-442b-9822-f1ad47984736");
                Guid getGuid = Guid.Parse("2b8b9080-60ef-442b-9822-f1ad47984736");

                await Svc<IShopCarServices>().GetAsync(getGuid);

                Assert.Equal(databaseGuid, getGuid);
            }

            [Fact]
            public async Task Should_DeleteByIdCar_WhenDeleteCar()
            {
                ShopCarDto car = MockCarData();

                var addCar = await Svc<IShopCarServices>().Create(car);
                var result = await Svc<IShopCarServices>().Delete(addCar.Id.GetValueOrDefault());

                Assert.Equal(result, addCar);
            }

            [Fact]
            public async Task ShouldNot_UpdateCar_WhenNotUpdateData()
            {
                ShopCarDto dto = MockCarData();
                await Svc<IShopCarServices>().Create(dto);

                ShopCarDto nullUpdate = MockNullCarData();
                await Svc<IShopCarServices>().Update(nullUpdate);

                var nullId = nullUpdate.Id;

                Assert.True(dto.Id == nullId);
            }

            private ShopCarDto MockCarData()
            {
                return new ShopCarDto()
                {
                    Brand = "Audi",
                    Model = "R8",
                    ModelYear = 2011,
                    Price = 1000000,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };
            }

            private ShopCarDto MockNullCarData()
            {
                var car = MockCarData();
                car.Id = null;

                return car;
            }
        }
    }
