namespace Refactoring.Statistics
{
  /// <summary>
  /// Задолженность клиента.
  /// </summary>
  internal abstract class Debt : Statistics<double>
  {
    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="debt">Задолженность.</param>
    protected Debt(double debt) : base(debt) { }
  }
}
