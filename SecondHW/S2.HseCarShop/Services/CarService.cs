using S2.HseCarShop.Services.Abstractions;
using S2.HseCarShop.Models.Abstractions;
using S2.HseCarShop.Models;

namespace S2.HseCarShop.Services;

public class CarService : ICarProvider
{
    /// <summary>
    /// Коллекция для хранения автомобилей
    /// </summary>
    private readonly LinkedList<Car> _cars = new();

    /// <summary>
    /// Методя для добавления автомобиля
    /// </summary>
    public void AddCar<TParams>(ICarFactory<TParams> carFactory, TParams carParams)
        where TParams : EngineParamsBase
    {
        var car = carFactory.CreateCar(carParams, Guid.NewGuid());
        _cars.AddLast(car);
    }

    public Car? GetCar(Customer customer)
    {
        Car? fit_car = null;

        foreach (Car car in _cars) {
            if (car.CarFitsCustomer(customer)) {
                fit_car = car;
                break;
            }
        }

        if (fit_car != null)
            _cars.Remove(fit_car);

        return fit_car;
    }
}
