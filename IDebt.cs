namespace Refactoring
{
  /// <summary>
  /// Задолженность клиента.
  /// </summary>
  internal interface IDebt : IInformer
  {
    /// <summary>
    /// Общая задолженность клиента.
    /// </summary>
    double Total { get; }
  }
}
