using System;
using System.CodeDom;
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
      var rentScore = 1u;
      return rentScore;
    }

    /// <summary>
    /// Рассчитать бонусные очки за прокат фильма.
    /// </summary>
    /// <param name="rent">Детали о прокате.</param>
    /// <returns>Бонусные очки за прокат.</returns>
    private uint CalculateRentBonusScore(Rental rent)
    {
      uint rentBonusScore = rent.Movie.Type switch
      {
        MovieType.Regular when rent.Time > TimeSpan.FromDays(7) => 1,
        MovieType.Regular => 0,
        MovieType.NewRelease when rent.Time <= TimeSpan.FromDays(1) => 1,
        MovieType.NewRelease => 0,
        MovieType.Childrens => 0,
        _ => throw this.GetInvalidMovieTypeException(rent.Movie.Type, nameof(rent.Movie.Type))
      };

      return rentBonusScore;
    }

    /// <summary>
    /// Рассчитать фиксированную часть платы за прокат фильма.
    /// </summary>
    /// <param name="rent">Детали о прокате.</param>
    /// <returns>Фиксированная часть платы за прокат фильма.</returns>
    private double CalculateFixRentCost(Rental rent)
    {
      double fixRentCost = rent.Movie.Type switch
      {
        MovieType.Regular => 2,
        MovieType.NewRelease => 0,
        MovieType.Childrens => 1.5,
        _ => throw this.GetInvalidMovieTypeException(rent.Movie.Type, nameof(rent.Movie.Type))
      };

      return fixRentCost;
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

      double costPerDay = rent.Movie.Type switch
      {
        MovieType.Regular => 1.5,
        MovieType.NewRelease => 3,
        MovieType.Childrens => 1.5,
        _ => throw this.GetInvalidMovieTypeException(rent.Movie.Type, nameof(rent.Movie.Type))
      };

      TimeSpan paidPeriod = rent.Time - freePeriod;
      return paidPeriod.Days * costPerDay;
    }

    /// <summary>
    /// Получить период, который не облагается переменной частью платы за прокат фильма.
    /// </summary>
    /// <param name="movieType">Тип фильма.</param>
    /// <returns>Период, который не облагается переменной частью платы за прокат фильма.</returns>
    private TimeSpan GetFreePeriod(MovieType movieType)
    {
      TimeSpan freePeriod = movieType switch
      {
        MovieType.Regular => TimeSpan.FromDays(2),
        MovieType.NewRelease => TimeSpan.Zero,
        MovieType.Childrens => TimeSpan.FromDays(3),
        _ => throw this.GetInvalidMovieTypeException(movieType, nameof(movieType))
      };

      return freePeriod;
    }

    /// <summary>
    /// Возвращает исключение о неверном типе фильма.
    /// </summary>
    /// <param name="movieType">Тип фильма.</param>
    /// <param name="argumentName">Имя аргумента, в котором был передан неверный тип фильма.</param>
    /// <returns>Исключение о неверном типе фильма.</returns>
    private Exception GetInvalidMovieTypeException(MovieType movieType, string argumentName)
    {
      var inner = new ArgumentException("Invalid argument value.", argumentName);
      return new InvalidMovieTypeException(movieType, inner);
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
