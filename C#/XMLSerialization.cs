public static void Serialize(List<T> objects, string fileName)
{
    XmlSerializer formatter = new XmlSerializer(typeof(List<T>));
    using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
    {
        formatter.Serialize(fs, objects);
    }
}

public static List<T> Deserialize(string fileName)
{
    XmlSerializer formatter = new XmlSerializer(typeof(List<T>));
    using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
    {
        var loadedObjects = formatter.Deserialize(fs) as List<T>;
        return loadedObjects;
    }
}
