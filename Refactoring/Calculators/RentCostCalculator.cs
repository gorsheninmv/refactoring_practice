namespace Refactoring.Calculators
{
  /// <summary>
  /// Калькулятор стоимости аренды.
  /// </summary>
  internal sealed class RentCostCalculator
  {
    #region Поля и свойства

    /// <summary>
    /// Общая стоимсть аренды.
    /// </summary>
    public double Total { get; private set; }

    #endregion

    #region Методы

    /// <summary>
    /// Рассчитать стоимость аренды.
    /// </summary>
    /// <param name="rent">Аренда.</param>
    /// <returns>Стоимость аренды.</returns>
    public double Calculate(Rental rent)
    {
      return CalculateFixRentCost(rent) + CalculateFloatingRentCost(rent);
    }

    /// <summary>
    /// Добавить стоимость к общей стоимости.
    /// </summary>
    /// <param name="cost">Стоимость аренды.</param>
    public void AddToTotal(double cost)
    {
      this.Total += cost;
    }

    /// <summary>
    /// Рассчитать фиксированную часть платы за прокат фильма.
    /// </summary>
    /// <param name="rent">Детали о прокате.</param>
    /// <returns>Фиксированная часть платы за прокат фильма.</returns>
    private static double CalculateFixRentCost(Rental rent)
    {
      double fixRentCost = rent.Movie.Type switch
      {
        MovieType.Regular => 2,
        MovieType.NewRelease => 0,
        MovieType.Childrens => 1.5,
        _ => throw new InvalidMovieTypeException(rent.Movie.Type)
      };

      return fixRentCost;
    }

    /// <summary>
    /// Рассчитать переменную часть платы за прокат фильма.
    /// </summary>
    /// <param name="rent">Детали о прокате.</param>
    /// <returns>Пераменная часть платы за прокат фильма.</returns>
    private static double CalculateFloatingRentCost(Rental rent)
    {
      uint freePeriodInDays = GetFreePeriodInDays(rent.Movie.Type);

      if (rent.TimeInDays <= freePeriodInDays)
        return 0;

      uint paidPeriodInDays = rent.TimeInDays - freePeriodInDays;
      return paidPeriodInDays * GetCostPerDay(rent.Movie.Type);
    }

    /// <summary>
    /// Получить стоимость проката за день.
    /// </summary>
    /// <param name="movie">Фильм.</param>
    /// <returns>Стоимость проката за день.</returns>
    private static double GetCostPerDay(MovieType movie)
    {
      double costPerDay = movie switch
      {
        MovieType.Regular => 1.5,
        MovieType.NewRelease => 3,
        MovieType.Childrens => 1.5,
        _ => throw new InvalidMovieTypeException(movie)
      };

      return costPerDay;
    }

    /// <summary>
    /// Получить период, который не облагается переменной частью платы за прокат фильма.
    /// </summary>
    /// <param name="movieType">Тип фильма.</param>
    /// <returns>Период, который не облагается переменной частью платы за прокат фильма.</returns>
    private static uint GetFreePeriodInDays(MovieType movieType)
    {
      uint freePeriodInDays = movieType switch
      {
        MovieType.Regular => 2,
        MovieType.NewRelease => 0,
        MovieType.Childrens => 3,
        _ => throw new InvalidMovieTypeException(movieType)
      };

      return freePeriodInDays;
    }

    #endregion
  }
}
