namespace Refactoring
{
  /// <summary>
  /// Задолженность клиента.
  /// </summary>
  internal class DebtComponent : Informer, IDebt
  {
    #region Поля и свойства

    /// <summary>
    /// Описание задолженности.
    /// </summary>
    private readonly string description;

    #endregion

    #region IDebt

    public virtual double Total { get; }

    #endregion

    #region Базовый класс

    public override string Info => $"{this.description}\t{this.Total}";

    #endregion

    #region Констукторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="debt">Задолженность.</param>
    /// <param name="description">Описание задолженности.</param>
    public DebtComponent(string description, double debt)
    {
      this.description = description;
      this.Total = debt;
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="debt">Задолженность.</param>
    protected DebtComponent(double debt)
    {
      this.Total = debt;
    }

    #endregion
  }
}
