﻿using System;
using System.Text;
using NSubstitute;
using NUnit.Framework;
using Refactoring;

namespace RefactoringUnitTests
{
  [TestFixture]
  internal sealed class CustomerTests
  {
    private struct MovieForTest
    {
      public string Title { get; set; }
      public double Cost { get; set; }
    }

    [Test]
    public void GetReport_ReturnCorrectReport_ForMixedMovieTypes()
    {
      var customer = new Customer("Alex");
      var movie1 = new Movie("Matrix", MovieType.NewRelease);
      var movie2 = new Movie("Star track", MovieType.Regular);
      var rental1 = new Rental(movie1, TimeSpan.FromDays(2));
      var rental2 = new Rental(movie2, TimeSpan.FromDays(3));

      customer.AddRent(rental1);
      customer.AddRent(rental2);

      var testMovie1 = new MovieForTest { Title = movie1.Title, Cost = 6 };
      var testMovie2 = new MovieForTest { Title = movie2.Title, Cost = 3.5 };
      var totalDebt = 9.5;
      var score = 2u;

      string expected = this.GetExpectedInfo(customer.Name, totalDebt, score, testMovie1, testMovie2);
      Assert.AreEqual(expected, customer.GetReport());
    }

    [TestCase(MovieType.Regular, 2, 2, 1u)]
    [TestCase(MovieType.Regular, 8, 11, 2u)]
    [TestCase(MovieType.NewRelease, 1, 3, 2u)]
    [TestCase(MovieType.NewRelease, 5, 15, 1u)]
    [TestCase(MovieType.Childrens, 1, 1.5, 1u)]
    [TestCase(MovieType.Childrens, 5, 4.5, 1u)]
    public void GetReport_ReturnCorrectReport_ForParticularMovieType(MovieType movieType, int rentDays,
      double expectedCost, uint score)
    {
      var customer = new Customer("Foo");
      var movie = new Movie("Bar", movieType);
      var rental = new Rental(movie, TimeSpan.FromDays(rentDays));

      customer.AddRent(rental);

      var testMovie1 = new MovieForTest { Title = movie.Title, Cost = expectedCost };

      string expected = this.GetExpectedInfo(customer.Name, expectedCost, score, testMovie1);
      Assert.AreEqual(expected, customer.GetReport());
    }

    [Test]
    public void GetReport_ThrowsException_IfInvalidMovieType()
    {
      var customer = new Customer(Arg.Any<string>());
      var movie = new Movie(Arg.Any<string>(), MovieType.None);
      var rental = new Rental(movie, TimeSpan.FromDays(Arg.Any<int>()));

      customer.AddRent(rental);

      Assert.Catch<InvalidMovieTypeException>(() => customer.GetReport());
    }

    private string GetExpectedInfo(string customerName,
      double totalDebt, uint score, params MovieForTest[] movies)
    {
      var sb = new StringBuilder($"Учет аренды для {customerName}: ");
      foreach (var movie in movies)
        sb.Append($"\t{movie.Title}\t{movie.Cost}\n");

      sb.Append($"Сумма задолженности составляет {totalDebt}\n");
      sb.Append($"Вы заработали {score} очков за активность");
      return sb.ToString();
    }
  }
}
