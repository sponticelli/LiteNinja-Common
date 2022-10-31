using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityRandom = UnityEngine.Random;

namespace LiteNinja.Common.Extensions
{
  public static class IEnumerableExtensions
  {
    public static bool IsNullOrEmpty<T>(this IEnumerable<T> self)
    {
      return self == null || !self.Any();
    }

    public static void ForEach<TSource>(this IEnumerable<TSource> self, Action<TSource> func)
    {
      if (func == null) return;

      foreach (var row in self)
      {
        func(row);
      }
    }

    public static TSource FindMin<TSource, TResult>(this IEnumerable<TSource> self, Func<TSource, TResult> selector)
    {
      return !self.Any() ? default(TSource) : self.FirstOrDefault(c => selector(c).Equals(self.Min(selector)));
    }

    public static TSource FindMax<TSource, TResult>(this IEnumerable<TSource> self, Func<TSource, TResult> selector)
    {
      return !self.Any() ? default(TSource) : self.FirstOrDefault(c => selector(c).Equals(self.Max(selector)));
    }

    public static IEnumerable<TSource> ForEach<TSource>(this IEnumerable<TSource> self, Action<int, TSource> func)
    {
      if (func == null) return self;
      foreach (var row in self.Select((obj, index) => new { obj, index }))
      {
        func(row.index, row.obj);
      }

      return self;
    }

    public static IEnumerable ForEach(this IEnumerable self, Action<object> func)
    {
      if (func == null) return self;
      foreach (var row in self)
      {
        func(row);
      }

      return self;
    }

    public static IEnumerable ForEach(this IEnumerable self, Action<int, object> func)
    {
      if (func == null) return self;
      var index = 0;
      foreach (var row in self)
      {
        func(index++, row);
      }

      return self;
    }

    public static IEnumerable<TSource> Distinct<TSource, TKey>(this IEnumerable<TSource> self,
      Func<TSource, TKey> selector)
    {
      return self.Distinct(new CommonSelector<TSource, TKey>(selector));
    }

    public static IEnumerable<T> Log<T>(this IEnumerable<T> self)
    {
      foreach (var item in self)
      {
        Debug.Log(item);
      }

      return self;
    }

    public static bool None<TSource>(this IEnumerable<TSource> source)
    {
      return !source.Any();
    }

    public static bool None<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
    {
      return !source.Any(predicate);
    }

    /// <summary>
    /// Divide the specified collection and divisions.
    /// </summary>
    public static IEnumerable<IEnumerable<TSource>> Divide<TSource>(this IEnumerable<TSource> self, int divisions)
    {
      var capacity = self.Count() / divisions;
      var remainder = self.Count() % divisions;

      using var enumerator = self.GetEnumerator();
      for (var i = 0; i < remainder; i++)
        yield return Take(enumerator, capacity + 1);

      for (var i = remainder; i < divisions; i++)
        yield return Take(enumerator, capacity);
    }

    public static IEnumerable<TSource> Take<TSource>(IEnumerator<TSource> self, int count)
    {
      while (--count >= 0 && self.MoveNext())
        yield return self.Current;
    }

    /// <summary>
    /// Get random element from the enumerable
    /// </summary>
    public static T GetRandomElement<T>(this IEnumerable<T> self) =>
      self.ElementAt(UnityRandom.Range(0, self.Count()));

    /// <summary>
    /// Excepts passed elements from enumerable
    /// </summary>
    public static IEnumerable<T> Except<T>(this IEnumerable<T> self, params T[] elements) =>
      self.Except((IEnumerable<T>)elements);

    /// <summary>
    /// Shuffles enumerable
    /// </summary>
    public static IEnumerable<T> Shuffled<T>(this IEnumerable<T> self) =>
      self.OrderBy(v => UnityRandom.value);

    /// <summary>
    /// Represents an enumerable as a string in the format [a, b, c, ...]
    /// </summary>
    public static string AsString<T>(this IEnumerable<T> self) => $"[{string.Join(", ", self)}]";

    private sealed class CommonSelector<TSource, TKey> : IEqualityComparer<TSource>
    {
      private readonly Func<TSource, TKey> _selector;

      public CommonSelector(Func<TSource, TKey> selector)
      {
        _selector = selector;
      }

      public bool Equals(TSource x, TSource y)
      {
        return _selector(x).Equals(_selector(y));
      }

      public int GetHashCode(TSource obj)
      {
        return _selector(obj).GetHashCode();
      }
    }

    public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> self)
    {
      var list = self.ToList();
      for (var i = 0; i < list.Count; i++)
      {
        var j = UnityRandom.Range(0, list.Count);
        (list[i], list[j]) = (list[j], list[i]);
      }

      return list;
    }

    public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> self, int seed)
    {
      var list = self.ToList();
      for (var i = 0; i < list.Count; i++)
      {
        var j = UnityRandom.Range(0, list.Count);
        (list[i], list[j]) = (list[j], list[i]);
      }

      return list;
    }

    public static RangeMap<T> ToRangeMap<T>(this IEnumerable<T> values, Func<T, T, float, T> interpolation)
    {
      var map = new RangeMap<T>(interpolation);
      var step = 1f / values.Count();
      var i = 0f;
      foreach (var value in values)
      {
        map.Add(i, value);
        i += step;
      }

      return map;
    }


    /// <summary>
    /// Finds the maximum element in the source as scored by the given function.
    /// </summary>
    public static T MaxBy<T>(this IEnumerable<T> source, Func<T, IComparable> score)
    {
      return source.Aggregate((x, y) => score(x).CompareTo(score(y)) > 0 ? x : y);
    }

    /// <summary>
    /// Finds the minimum element in the source as scored by its projection.
    /// </summary>
    public static TSource MinBy<TSource, TKey>(
      this IEnumerable<TSource> source,
      Func<TSource, TKey> selector)
    {
      return source.MinBy(selector, Comparer<TKey>.Default);
    }

    /// <summary>
    /// Finds the minimum element in the source as scored by the given function applied to a projection on the elements.
    /// </summary>
    public static TSource MinBy<TSource, TKey>(
      this IEnumerable<TSource> source,
      Func<TSource, TKey> selector,
      IComparer<TKey> comparer)
    {
      source.ThrowIfNull("source");
      selector.ThrowIfNull("selector");
      comparer.ThrowIfNull("comparer");

      using var sourceIterator = source.GetEnumerator();
      if (!sourceIterator.MoveNext())
      {
        throw new InvalidOperationException("Sequence was empty");
      }

      var min = sourceIterator.Current;
      var minKey = selector(min);

      while (sourceIterator.MoveNext())
      {
        var candidate = sourceIterator.Current;
        var candidateProjected = selector(candidate);

        if (comparer.Compare(candidateProjected, minKey) >= 0) continue;
        min = candidate;
        minKey = candidateProjected;
      }

      return min;
    }

    /// <summary>
    /// Finds the minimum element in the source as scored by its projection.
    /// </summary>
    public static TSource MaxBy<TSource, TKey>(this IEnumerable<TSource> source,
      Func<TSource, TKey> selector)
    {
      return source.MaxBy(selector, Comparer<TKey>.Default);
    }

    /// <summary>
    /// Finds the minimum element in the source as scored by the given function applied to a projection on the elements.
    /// </summary>
    public static TSource MaxBy<TSource, TKey>(this IEnumerable<TSource> source,
      Func<TSource, TKey> selector, IComparer<TKey> comparer)
    {
      source.ThrowIfNull("source");
      selector.ThrowIfNull("selector");
      comparer.ThrowIfNull("comparer");

      using var sourceIterator = source.GetEnumerator();
      if (!sourceIterator.MoveNext())
      {
        throw new InvalidOperationException("Sequence was empty");
      }

      var max = sourceIterator.Current;
      var maxKey = selector(max);

      while (sourceIterator.MoveNext())
      {
        var candidate = sourceIterator.Current;
        var candidateProjected = selector(candidate);

        if (comparer.Compare(candidateProjected, maxKey) <= 0) continue;
        max = candidate;
        maxKey = candidateProjected;
      }

      return max;
    }


    /// <summary>
    /// Returns an enumerable of all elements of the given list	but the first, keeping them in order.
    /// </summary>
    public static IEnumerable<T> ButFirst<T>(this IEnumerable<T> source)
    {
      return source.Skip(1);
    }

    /// <summary>
    /// Returns an enumerable of all elements in the given  list but the last, keeping them in order.
    /// </summary>
    public static IEnumerable<T> ButLast<T>(this IEnumerable<T> source)
    {
      var lastX = default(T);
      var first = true;

      foreach (var x in source)
      {
        if (first)
        {
          first = false;
        }
        else
        {
          yield return lastX;
        }

        lastX = x;
      }
    }

    /// <summary>
    /// Returns a random element from a source.
    /// </summary>
    /// <typeparam name="T">The type of items generated from the source.</typeparam>
    /// <param name="source">The list.</param>
    /// <returns>A item ramdonly selected from the source.</returns>
    public static T RandomItem<T>(this IEnumerable<T> source)
    {
      return source.ElementAt(UnityRandom.Range(0, source.Count()));
    }
    
    /// <summary>
    /// </summary>
    public static IEnumerable<T> SampleRandom<T>(this IEnumerable<T> source, int count)
    {
      return source.Shuffle().Take(count);
    }
  }
}