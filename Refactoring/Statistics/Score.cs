namespace Refactoring.Statistics
{
  /// <summary>
  /// Очки, набранные клиентом.
  /// </summary>
  internal abstract class Score : Statistics<uint>
  {
    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="score">Очки, набранные клиентом.</param>
    protected Score(uint score) : base(score) { }
  }
}
