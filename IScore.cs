namespace Refactoring
{
  /// <summary>
  /// Очки, набранные пользователем.
  /// </summary>
  internal interface IScore : IInformer
  {
    /// <summary>
    /// Общее количество очков, набранных клиентом.
    /// </summary>
    uint Total { get; }
  }
}
