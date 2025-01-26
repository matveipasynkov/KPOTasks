namespace S2.HseCarShop.Models.Abstractions;

/// <summary>
/// Интерфейс для описания двигателя
/// </summary>
public interface IEngine
{
    /// <summary>
    /// Тип двигателя
    /// </summary>
    EngineType Type { get; }
    /// <summary>
    /// Проверка совместимости между двигателем и покупателем.
    /// </summary>
    /// <param name="customer"></param>
    /// <returns></returns>
    bool CheckCompatibility(Customer customer);
}
