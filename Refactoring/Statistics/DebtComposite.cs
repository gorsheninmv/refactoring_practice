using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Refactoring.Statistics
{
  /// <summary>
  /// Задолженность клиента.
  /// </summary>
  /// <remarks>Композит паттерна Композитор.</remarks>
  internal sealed class DebtComposite : Debt
  {
    #region Поля и свойства

    /// <summary>
    /// Задолженность клиента.
    /// </summary>
    private readonly List<Debt> debts = new List<Debt>();

    #endregion

    #region Методы

    /// <summary>
    /// Добавить очки.
    /// </summary>
    /// <param name="debt">Очки.</param>
    public void AddComponent(Debt debt)
    {
      this.debts.Add(debt);
    }

    #endregion

    #region Базовый класс

    public override double Total => this.debts.Aggregate(0d, (acc, debt) => acc + debt.Total);

    public override string Info
    {
      get
      {
        var sb = new StringBuilder();
        foreach (var debt in this.debts)
          sb.Append($"\t{debt.Info}\n");

        sb.Append($"Сумма задолженности составляет {this.Total}");
        return sb.ToString();
      }
    }

    #endregion

    #region Конструктор

    /// <summary>
    /// Конструктор.
    /// </summary>
    public DebtComposite() : base(0) { }

    #endregion
  }
}
