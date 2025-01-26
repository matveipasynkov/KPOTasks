using S2.HseCarShop.Models;
using S2.HseCarShop.Services.Abstractions;

namespace S2.HseCarShop.Services;

public class HseCarService
{
    /// <summary>
    /// Сервис предоставляющий нам автомобили
    /// </summary>
    private readonly ICarProvider _carProvider;

    /// <summary>
    /// Сервис предоставляющий нам покупателей
    /// </summary>
    private readonly ICustomersProvider _customersProvider;

    /// <summary>
    /// Конструктор класса
    /// </summary>
    public HseCarService(ICarProvider carProvider, ICustomersProvider customersProvider)
    {
        ArgumentNullException.ThrowIfNull(carProvider, nameof(carProvider));
        ArgumentNullException.ThrowIfNull(customersProvider, nameof(customersProvider));

        _carProvider = carProvider;
        _customersProvider = customersProvider;
    }

    public void SellCars()
    {
        var customers = _customersProvider.GetCustomers();

        foreach (Customer customer in customers)
        {
            if (customer.Car != null)
                continue;

            var car = _carProvider.GetCar(customer);

            if (car == null)
                continue;

            customer.Car = car;
        }
    }
}
