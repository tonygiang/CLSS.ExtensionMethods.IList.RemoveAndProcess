// A part of the C# Language Syntactic Sugar suite.

using System;
using System.Collections.Generic;

namespace CLSS
{
  public static partial class IListRemoveAndProcess
  {
    /// <inheritdoc cref="RemoveAndProcess{T, TElement, TR}(T, int, Func{TElement, TR})"/>
    public static T RemoveAndProcess<T, TElement>(this T source,
      int index,
      Action<TElement> processingAction)
      where T : IList<TElement>
    {
      if (source == null) throw new ArgumentNullException("source");
      if (processingAction == null)
        throw new ArgumentNullException("processingAction");
      var element = source[index];
      source.RemoveAt(index);
      processingAction(element);
      return source;
    }

    /// <inheritdoc cref="RemoveAndProcess{T, TElement, TR}(T, int, Func{TElement, TR})"/>
    public static IList<TElement> RemoveAndProcess<TElement>(
      this IList<TElement> source,
      int index,
      Action<TElement> processingAction)
    {
      if (source == null) throw new ArgumentNullException("source");
      if (processingAction == null)
        throw new ArgumentNullException("processingAction");
      var element = source[index];
      source.RemoveAt(index);
      processingAction(element);
      return source;
    }

    /// <summary>
    /// Takes the element at the specified index number, removes that element
    /// from the source collection and passes the removed element to the
    /// specified delegate.
    /// </summary>
    /// <typeparam name="T">The type of <see cref="IList{T}"/> to remove element
    /// from.</typeparam>
    /// <typeparam name="TElement"><inheritdoc cref="IList{T}"
    /// path="/typeparam[@name='T']"/></typeparam>
    /// <typeparam name="TResult">The return type of
    /// <paramref name="processingAction"/>.</typeparam>
    /// <param name="source">The <see cref="IList{T}"/> to remove element.
    /// </param>
    /// <param name="index"><inheritdoc cref="IList{T}.RemoveAt(int)"
    /// path="/param[@name='index']"/></param>
    /// <param name="processingAction">The action that will be executed with the
    /// removed element as its argument.</param>
    /// <returns>The source collection.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> or
    /// <paramref name="processingAction"/> is null.</exception>
    public static T RemoveAndProcess<T, TElement, TResult>(this T source,
      int index,
      Func<TElement, TResult> processingAction)
      where T : IList<TElement>
    {
      if (source == null) throw new ArgumentNullException("source");
      if (processingAction == null)
        throw new ArgumentNullException("processingAction");
      var element = source[index];
      source.RemoveAt(index);
      processingAction(element);
      return source;
    }

    /// <inheritdoc cref="RemoveAndProcess{T, TElement, TR}(T, int, Func{TElement, TR})"/>
    public static IList<TElement> RemoveAndProcess<TElement, TResult>(
      this IList<TElement> source,
      int index,
      Func<TElement, TResult> processingAction)
    {
      if (source == null) throw new ArgumentNullException("source");
      if (processingAction == null)
        throw new ArgumentNullException("processingAction");
      var element = source[index];
      source.RemoveAt(index);
      processingAction(element);
      return source;
    }
  }
}