using System;

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
    /// Время проката.
    /// </summary>
    public TimeSpan Time { get; }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="movie">Фильм.</param>
    /// <param name="time">Вермя проката.</param>
    public Rental(Movie movie, TimeSpan time)
    {
      this.Movie = movie;
      this.Time = time;
    }

    #endregion
  }
}
