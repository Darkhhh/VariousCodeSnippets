private static List<List<int>> _adjacencyList;
private static List<bool> _visitedVerticesList;
private static List<int> _currentComponent;
private static double _connectionDistance;

private static void DepthFirstSearch(int v)
{
    _visitedVerticesList[v] = true;
    _currentComponent.Add(v);
    for (var i = 0; i < _adjacencyList[v].Count; i++)
    {
        var to = _adjacencyList[v][i];
        if (!_visitedVerticesList[to]) DepthFirstSearch(to);
    }
}

public static List<Component> SearchComponents(List<Point> vertices)
{
    _adjacencyList = GetAdjacencyList(ref vertices, _connectionDistance);
    _visitedVerticesList = new List<bool>();
    _currentComponent = new List<int>();

    for (var i = 0; i < vertices.Count; i++) _visitedVerticesList.Add(false);

    var connectedComponents = new List<Component>();
    for (var i = 0; i < vertices.Count; i++)
    {
        if (_visitedVerticesList[i]) continue;
        _currentComponent.Clear();
        DepthFirstSearch(i);

        var componentVertices = new List<Point>();
        for (var j = 0; j < vertices.Count; j++)
        {
            componentVertices.AddRange(from index in _currentComponent where index == j select vertices[j]);
        }
        connectedComponents.Add(new Component(componentVertices));
    }
    return connectedComponents;
}
