namespace Common.GlobalExceptionResponses.Generics;

public class Pagination<T>
{
    public List<T> Data { get; set; }
    public int TotalCount { get; set; }
    public int Page { get; set; }
    public int Size { get; set; }

    public Pagination(List<T> datas, int totalDataCount, int page, int size)
    {
        Data = datas;
        TotalCount = totalDataCount;
        Page = page;
        Size = size;
    }
    public Pagination()
    {
        Data = new List<T>();
        TotalCount = 0;
    }
}
