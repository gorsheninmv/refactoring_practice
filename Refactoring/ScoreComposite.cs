using System.Collections.Generic;
using System.Linq;

namespace Refactoring
{
  /// <summary>
  /// Очки, набранные клиентом.
  /// </summary>
  internal sealed class ScoreComposite : ScoreComponent
  {
    #region Поля и свойства

    /// <summary>
    /// Очки, набранные клиентом.
    /// </summary>
    private readonly List<IScore> scores = new List<IScore>();

    #endregion

    #region Методы

    /// <summary>
    /// Добавить очки.
    /// </summary>
    /// <param name="score">Очки.</param>
    public void AddComponent(IScore score)
    {
      this.scores.Add(score);
    }

    #endregion

    #region Базовый класс

    public override uint Total => this.scores.Aggregate(0u, (acc, score) => acc + score.Total);

    public override string Info => $"Вы заработали {this.Total} очков за активность";

    #endregion

    #region Конструктор

    /// <summary>
    /// Конструктор.
    /// </summary>
    public ScoreComposite() : base(0) { }

    #endregion
  }
}
