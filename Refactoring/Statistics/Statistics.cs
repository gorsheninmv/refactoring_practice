namespace Refactoring.Statistics
{
  /// <summary>
  /// Статистика клиента.
  /// </summary>
  /// <typeparam name="T">Тип данных, прeдставляющий статистику.</typeparam>
  internal abstract class Statistics<T>
  {
    /// <summary>
    /// Суммарное значение статистики.
    /// </summary>
    public virtual T Total { get; }

    /// <summary>
    /// Строковое представление статистики.
    /// </summary>
    public virtual string Info { get; } = string.Empty;

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="statistics">Значение статистики.</param>
    protected Statistics(T statistics)
    {
      this.Total = statistics;
    }

    #endregion
  }
}
