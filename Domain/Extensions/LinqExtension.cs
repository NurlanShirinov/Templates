namespace Domain.Extensions;

public static class LinqExtension
{
    public static IEnumerable<T> PageBy<T>(this IEnumerable<T> query, int page, int size) { return query.Skip((page - 1) * size).Take(size); }
}