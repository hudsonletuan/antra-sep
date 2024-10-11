// 1. Custom Stack Class: MyStack<T>
public class MyStack<T>
{
    private List<T> _elements = new List<T>();

    public int Count()
    {
        return _elements.Count;
    }

    public T Pop()
    {
        if (_elements.Count == 0)
            throw new InvalidOperationException("Stack is empty.");

        T item = _elements[_elements.Count - 1];
        _elements.RemoveAt(_elements.Count - 1);
        return item;
    }

    public void Push(T item)
    {
        _elements.Add(item);
    }
}

// 2. Generic List Data Structure: MyList<T>
public class MyList<T>
{
    private List<T> _elements = new List<T>();

    public void Add(T element)
    {
        _elements.Add(element);
    }

    public T Remove(int index)
    {
        if (index < 0 || index >= _elements.Count)
            throw new ArgumentOutOfRangeException("Index out of range.");

        T item = _elements[index];
        _elements.RemoveAt(index);
        return item;
    }

    public bool Contains(T element)
    {
        return _elements.Contains(element);
    }

    public void Clear()
    {
        _elements.Clear();
    }

    public void InsertAt(T element, int index)
    {
        if (index < 0 || index > _elements.Count)
            throw new ArgumentOutOfRangeException("Index out of range.");

        _elements.Insert(index, element);
    }

    public void DeleteAt(int index)
    {
        if (index < 0 || index >= _elements.Count)
            throw new ArgumentOutOfRangeException("Index out of range.");

        _elements.RemoveAt(index);
    }

    public T Find(int index)
    {
        if (index < 0 || index >= _elements.Count)
            throw new ArgumentOutOfRangeException("Index out of range.");

        return _elements[index];
    }
}

// Generic Repository Class: GenericRepository<T>
public interface IRepository<T> where T : class
{
    void Add(T item);
    void Remove(T item);
    void Save();
    IEnumerable<T> GetAll();
    T GetById(int id);
}

public class Entity
{
    public int Id { get; set; }
}

public class GenericRepository<T> : IRepository<T> where T : Entity
{
    private List<T> _dataStore = new List<T>();

    public void Add(T item)
    {
        _dataStore.Add(item);
    }

    public void Remove(T item)
    {
        _dataStore.Remove(item);
    }

    public void Save()
    {
        Console.WriteLine("Changes saved.");
    }

    public IEnumerable<T> GetAll()
    {
        return _dataStore;
    }

    public T GetById(int id)
    {
        return _dataStore.FirstOrDefault(item => item.Id == id);
    }
}