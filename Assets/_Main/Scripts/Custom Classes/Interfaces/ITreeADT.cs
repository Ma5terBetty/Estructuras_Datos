
/// <summary>
/// Hierarchical data structure of nodes
/// </summary>
public interface ITreeADT<T>
{
    /// <summary>
    /// Origin of the tree
    /// </summary>
    NodeTree<T> Root { get; }
    /// <summary>
    /// Check if the current root is empty
    /// </summary>
    bool IsEmpty { get; }
    /// <summary>
    /// Reference to the left node
    /// </summary>
    NodeTree<T> Left { get; }
    /// <summary>
    /// Reference to the Right node
    /// </summary>
    NodeTree<T> Right { get; }
    T this[int i] { get; }
    /// <summary>
    /// Adds an element to the end of the tree
    /// </summary>
    /// <param name="element"></param>
    void Add(T element);
    /// <summary>
    /// Inserts an element to a specific place in the tree
    /// </summary>
    /// <param name="index"></param>
    /// <param name="element"></param>
    void Insert(int index, T element);
    /// <summary>
    /// Removes the first element that it finds
    /// </summary>
    /// <param name="element"></param>
    /// <returns></returns>
    bool Remove(T element);
    /// <summary>
    /// Removes at the given index 
    /// </summary>
    /// <param name="index"></param>
    void RemoveAt(int index);
    /// <summary>
    /// Let's you know if it contains an element
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    bool Contains(T element);
    /// <summary>
    /// Restarts the tree
    /// </summary>
    void Clear();
    /// <summary>
    /// Finds the node at a certain key
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    NodeTree<T> Find(int key);
}
