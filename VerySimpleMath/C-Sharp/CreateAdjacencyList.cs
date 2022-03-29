/// <summary>
/// Возвращает список смежности на основании списка точек. Место точки в списке принято за уникальный идентификатор. 
/// Новый список формируется по принципу: номер элемента списка - уникальный идентификатор точки, числа в подсписке - идентификаторы точек, которые связаны с текущей.
/// </summary>
public static List<List<int>> GetAdjacencyList(ref List<Point> vertices, double connectionDistance)
{
    var result = new List<List<int>>();
    for (var i = 0; i < vertices.Count; i++)
    {
        var listFormer = new List<int>();
        for (var j = 0; j < vertices.Count; j++)
        {
            if (i == j) continue;
            if (Utils.GetDistanceBetweenPoints(vertices[i], vertices[j]) < connectionDistance) listFormer.Add(j);
        }
        result.Add(listFormer);
    }
    return result;
}
