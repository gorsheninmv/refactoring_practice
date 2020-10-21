namespace Refactoring
{
  /// <summary>
  /// Интерфейс вывод информации о состоянии объекта.
  /// </summary>
  internal interface IInformer
  {
    /// <summary>
    /// Информация о состоянии объекта.
    /// </summary>
    string Info { get; }
  }
}
