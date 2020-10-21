namespace Refactoring
{
  /// <summary>
  /// Текстовое представление объекта.
  /// </summary>
  internal abstract class Informer : IInformer
  {
    public virtual string Info => string.Empty;
  }
}
