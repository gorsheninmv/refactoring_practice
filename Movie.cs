namespace Refactoring
{
  /// <summary>
  /// Класс, который предоставляет данные о фильме.
  /// </summary>
  internal sealed class Movie
  {
    #region Поля и свойства

    /// <summary>
    /// Название фильма.
    /// </summary>
    public string Title { get; }

    /// <summary>
    /// Тип фильма.
    /// </summary>
    public MovieType Type { get; set; }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="title">Название фильма.</param>
    /// <param name="movieType">Тип фильма.</param>
    public Movie(string title, MovieType movieType)
    {
      this.Title = title;
      this.Type = movieType;
    }

    #endregion
  }
}
