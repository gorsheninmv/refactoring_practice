namespace Refactoring
{
  /// <summary>
  /// Класс, представляющий данные о прокате фильма.
  /// </summary>
  internal sealed class Rental
  {
    #region Поля и свойства

    /// <summary>
    /// Фильм.
    /// </summary>
    public Movie Movie { get; }

    /// <summary>
    /// Время проката в днях.
    /// </summary>
    public uint TimeInDays { get; }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="movie">Фильм.</param>
    /// <param name="timeInDays">Вермя проката в днях.</param>
    public Rental(Movie movie, uint timeInDays)
    {
      this.Movie = movie;
      this.TimeInDays = timeInDays;
    }

    #endregion
  }
}
