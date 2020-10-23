namespace Refactoring.Statistics
{
  /// <summary>
  /// Очки, набранные клиентом.
  /// </summary>
  /// <remarks>Компонент паттерна Композитор.</remarks>
  internal class ScoreComponent : Score
  {
    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="score">Очки, набранные клиентом.</param>
    public ScoreComponent(uint score) : base(score){ }

    #endregion
  }
}
