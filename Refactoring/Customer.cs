using System.Collections.Generic;

namespace Refactoring
{
  /// <summary>
  /// Клиент проката.
  /// </summary>
  internal sealed class Customer
  {
    #region Поля и свойства

    /// <summary>
    /// Имя клиента.
    /// </summary>
    public string Name { get; }

    private readonly List<Rental> rentals = new List<Rental>();

    /// <summary>
    /// Текущие прокаты клиента.
    /// </summary>
    public IEnumerable<Rental> Rentals => this.rentals;

    #endregion

    #region Методы

    /// <summary>
    /// Добавить новый фильм в список текущих прокатов клиента.
    /// </summary>
    /// <param name="rent">Детали о прокате.</param>
    public void AddRent(Rental rent)
    {
      this.rentals.Add(rent);
    }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="name">Имя клиента.</param>
    public Customer(string name)
    {
      this.Name = name;
    }

    #endregion
  }
}
