using System;

namespace Refactoring
{
  /// <summary>
  /// Класс точки входа в программу.
  /// </summary>
  internal sealed class Program
  {
    /// <summary>
    /// Точка входа в программу.
    /// </summary>
    private static void Main()
    {
      var customer = new Customer("Alex");
      var movie1 = new Movie("Matrix", MovieType.NewRelease);
      var movie2 = new Movie("Star track", MovieType.Regular);
      var rental1 = new Rental(movie1, TimeSpan.FromDays(2));
      var rental2 = new Rental(movie2, TimeSpan.FromDays(3));

      customer.AddRent(rental1);
      customer.AddRent(rental2);

      Console.WriteLine(customer.GetReport());
    }
  }
}
