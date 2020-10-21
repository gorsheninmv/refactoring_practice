namespace Refactoring
{
  /// <summary>
  /// Очки, набранные клиентом.
  /// </summary>
  internal class ScoreComponent : Informer, IScore
  {
    #region IScore

    public virtual uint Total { get; }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="score">Очки.</param>
    public ScoreComponent(uint score)
    {
      this.Total = score;
    }

    #endregion
  }
}
