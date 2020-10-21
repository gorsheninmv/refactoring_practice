using System;

namespace Refactoring
{
  /// <summary>
  /// Исключение о недопустимом типе фильма.
  /// </summary>
  internal class InvalidMovieTypeException : Exception
  {
    #region Методы

    /// <summary>
    /// Создать сообщение исключения.
    /// </summary>
    /// <param name="movieType">Тип фильма.</param>
    /// <returns>Сообщение исключения.</returns>
    private static string CreateExceptionMessage(MovieType movieType)
    {
      return $"{nameof(MovieType)} value '{movieType}' is invalid in this context.";
    }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="movieType">Тип фильма.</param>
    /// <param name="innerExceptopn">Внутренне исключение.</param>
    public InvalidMovieTypeException(MovieType movieType, Exception innerExceptopn) :
      base(CreateExceptionMessage(movieType), innerExceptopn) { }

    #endregion
  }
}
