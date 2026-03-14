using ItemChanger.Serialization;

namespace ItemChanger.Silksong.Extensions;

internal static class ICExtensions
{
    /// <summary>
    /// Converts an object to a writable value provider wrapping that object.
    /// </summary>
    public static IWritableValueProvider<T> ToValueProvider<T>(this T t) => new LiftedT<T> { Value = t };
    /// <summary>
    /// Converts a struct-returning value provider to an object-returning value provider.
    /// </summary>
    public static IValueProvider<object> Embox<T>(this IValueProvider<T> t) where T : struct => new Box<T> { Source = t };
}

file class Box<T> : IValueProvider<object> where T : struct
{
    public required IValueProvider<T> Source { get; init; }
    public object Value => Source.Value;
}

file class LiftedT<T> : IWritableValueProvider<T>
{
    public required T Value { get; set; }
}
