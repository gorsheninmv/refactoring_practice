namespace Refactoring.Statistics
{
  /// <summary>
  /// Задолженность клиента.
  /// </summary>
  /// <remarks>Компонент паттерна Композитор.</remarks>
  internal class DebtComponent : Debt
  {
    #region Поля и свойства

    /// <summary>
    /// Описание задолженности.
    /// </summary>
    private readonly string description;

    #endregion

    #region Базовый класс

    public override string Info => $"{this.description}\t{this.Total}";

    #endregion

    #region Констукторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="description">Описание задолженности.</param>
    /// <param name="debt">Задолженность.</param>
    public DebtComponent(string description, double debt) : base(debt)
    {
      this.description = description;
    }

    #endregion
  }
}
