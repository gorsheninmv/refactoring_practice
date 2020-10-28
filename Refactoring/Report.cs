using System.Text;
using Refactoring.Calculators;

namespace Refactoring
{
  /// <summary>
  /// Отчет о клиенте.
  /// </summary>
  internal static class Report
  {
    /// <summary>
    /// Создать отчет.
    /// </summary>
    /// <param name="customer">Клиент.</param>
    /// <returns>Отчет о клиенте.</returns>
    public static string Create(Customer customer)
    {
      var costCalcualtor = new RentCostCalculator();
      var scoreCalculator = new RentScoreCalculator();
      var report = new StringBuilder($"Учет аренды для {customer.Name}: ");

      foreach (var rent in customer.Rentals)
      {
        double cost = costCalcualtor.Calculate(rent);
        costCalcualtor.AddToTotal(cost);
        report.Append($"\t{rent.Movie.Title}\t{cost}\n");

        uint score = scoreCalculator.Calculate(rent);
        scoreCalculator.AddToTotal(score);
      }

      report.Append($"Сумма задолженности составляет {costCalcualtor.Total}\n");
      report.Append($"Вы заработали {scoreCalculator.Total} очков за активность");

      return report.ToString();
    }
  }
}
