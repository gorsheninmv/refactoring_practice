using System;
using System.Collections.Generic;
using System.Text;
using Refactoring.Statistics;

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

    /// <summary>
    /// Текущие прокаты клиента.
    /// </summary>
    private readonly List<Rental> rentals = new List<Rental>();

    #endregion

    #region Методы

    /// <summary>
    /// Получить отчет о клиенте.
    /// </summary>
    /// <returns>Отчет о клиенте.</returns>
    public string GetReport()
    {
      var sb = new StringBuilder();
      sb.Append($"Учет аренды для {this.Name}: ");
      sb.Append($"{this.GetDebt().Info}\n");
      sb.Append(this.GetScore().Info);

      return sb.ToString();
    }

    /// <summary>
    /// Получить текущие набранные очки.
    /// </summary>
    /// <returns>Текущие набранные очки.</returns>
    public Score GetScore()
    {
      var score = new ScoreComposite();

      foreach (var rent in this.rentals)
      {
        uint rentScore = this.CalculateRentScore(rent) + this.CalculateRentBonusScore(rent);
        score.AddComponent(new ScoreComponent(rentScore));
      }

      return score;
    }

    /// <summary>
    /// Текущая задолженность клиента.
    /// </summary>
    /// <returns>Текущая зожлженность.</returns>
    public Debt GetDebt()
    {
      var debt = new DebtComposite();

      foreach (var rent in this.rentals)
      {
        double rentCost = this.CalculateFixRentCost(rent) + this.CalculateFloatingRentCost(rent);
        debt.AddComponent(new DebtComponent(rent.Movie.Title, rentCost));
      }

      return debt;
    }

    /// <summary>
    /// Добавить новый фильм в список текущих прокатов клиента.
    /// </summary>
    /// <param name="rent">Детали о прокате.</param>
    public void AddRent(Rental rent)
    {
      this.rentals.Add(rent);
    }

    /// <summary>
    /// Рассчитать очки за прокат фильма.
    /// </summary>
    /// <param name="rent">Детали о прокате.</param>
    /// <returns>Очки за прокат.</returns>
    private uint CalculateRentScore(Rental rent)
    {
      return 1;
    }

    /// <summary>
    /// Рассчитать бонусные очки за прокат фильма.
    /// </summary>
    /// <param name="rent">Детали о прокате.</param>
    /// <returns>Бонусные очки за прокат.</returns>
    private uint CalculateRentBonusScore(Rental rent)
    {
      switch (rent.Movie.Type)
      {
        case MovieType.Regular:
          if (rent.Time > TimeSpan.FromDays(7))
            return 1;
          break;
        case MovieType.NewRelease:
          if (rent.Time <= TimeSpan.FromDays(1))
            return 1;
          break;
        case MovieType.Childrens:
          return 0;
        default:
          var inner = new ArgumentException("Invalid argument value.", nameof(rent.Movie.Type));
          throw new InvalidMovieTypeException(rent.Movie.Type, inner);
      }

      return 0;
    }

    /// <summary>
    /// Рассчитать фиксированную часть платы за прокат фильма.
    /// </summary>
    /// <param name="rent">Детали о прокате.</param>
    /// <returns>Фиксированная часть платы за прокат фильма.</returns>
    private double CalculateFixRentCost(Rental rent)
    {
      switch (rent.Movie.Type)
      {
        case MovieType.Regular:
          return 2;
        case MovieType.Childrens:
          return 1.5;
        case MovieType.NewRelease:
          return 0;
        default:
          var inner = new ArgumentException("Invalid argument value.", nameof(rent.Movie.Type));
          throw new InvalidMovieTypeException(rent.Movie.Type, inner);
      }
    }

    /// <summary>
    /// Рассчитать переменную часть платы за прокат фильма.
    /// </summary>
    /// <param name="rent">Детали о прокате.</param>
    /// <returns>Пераменная часть платы за прокат фильма.</returns>
    private double CalculateFloatingRentCost(Rental rent)
    {
      TimeSpan freePeriod = this.GetFreePeriod(rent.Movie.Type);

      if (rent.Time <= freePeriod)
        return 0;

      TimeSpan paidPeriod = rent.Time - freePeriod;

      switch (rent.Movie.Type)
      {
        case MovieType.Regular:
        case MovieType.Childrens:
          return paidPeriod.Days * 1.5;
        case MovieType.NewRelease:
          return paidPeriod.Days * 3;
        default:
          var inner = new ArgumentException("Invalid argument value.", nameof(rent.Movie.Type));
          throw new InvalidMovieTypeException(rent.Movie.Type, inner);
      }
    }

    /// <summary>
    /// Получить период, который не облагается переменной частью платы за прокат фильма.
    /// </summary>
    /// <param name="movieType">Тип фильма.</param>
    /// <returns>Период, который не облагается переменной частью платы за прокат фильма.</returns>
    private TimeSpan GetFreePeriod(MovieType movieType)
    {
      switch (movieType)
      {
        case MovieType.Regular: return TimeSpan.FromDays(2);
        case MovieType.NewRelease: return TimeSpan.Zero;
        case MovieType.Childrens: return TimeSpan.FromDays(3);
        default:
          var inner = new ArgumentException("Invalid argument value.", nameof(movieType));
          throw new InvalidMovieTypeException(movieType, inner);
      }
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
