namespace Refactoring.Calculators
{
  /// <summary>
  /// Калькулятор очков за аренду.
  /// </summary>
  internal sealed class RentScoreCalculator
  {
    #region Константы

    /// <summary>
    /// Очки за аренду.
    /// </summary>
    private const uint RentScore = 1;

    #endregion

    #region Поля и свойства

    /// <summary>
    /// Общее количество очков.
    /// </summary>
    public uint Total { get; private set; }

    #endregion

    #region Методы

    /// <summary>
    /// Рассчитать очки за аренду.
    /// </summary>
    /// <param name="rent">Аренда.</param>
    /// <returns>Заработанные очки.</returns>
    public uint Calculate(Rental rent)
    {
      return RentScore + CalculateRentBonusScore(rent);
    }

    /// <summary>
    /// Добавить очки к общему количеству очков.
    /// </summary>
    /// <param name="score">Очки.</param>
    public void AddToTotal(uint score)
    {
      this.Total += score;
    }

    /// <summary>
    /// Рассчитать бонусные очки за прокат фильма.
    /// </summary>
    /// <param name="rent">Детали о прокате.</param>
    /// <returns>Бонусные очки за прокат.</returns>
    private static uint CalculateRentBonusScore(Rental rent)
    {
      uint rentBonusScore = rent.Movie.Type switch
      {
        MovieType.Regular when rent.TimeInDays > 7 => 1,
        MovieType.Regular => 0,
        MovieType.NewRelease when rent.TimeInDays <= 1 => 1,
        MovieType.NewRelease => 0,
        MovieType.Childrens => 0,
        _ => throw new InvalidMovieTypeException(rent.Movie.Type)
      };

      return rentBonusScore;
    }

    #endregion
  }
}
