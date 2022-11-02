
/// <summary>
/// Hierarchical data structure of nodes
/// </summary>
public interface ITreeADT
{
    /// <summary>
    /// Origin of the tree
    /// </summary>
    int Root { get; }
    /// <summary>
    /// Check if the current root is empty
    /// </summary>
    bool Empty { get; }
    /// <summary>
    /// Reference to the left node
    /// </summary>
    NodeABB Left { get; }
    /// <summary>
    /// Reference to the Right node
    /// </summary>
    NodeABB Right { get; }
    /// <summary>
    /// Initializes the tree
    /// </summary>
    void Initialize();

    /// <summary>
    /// Add an element to the referenced node
    /// </summary>
    /// <param name="n">Node</param>
    /// <param name="x">Info</param>
    void Add(ref NodeABB n, int x);

    /// <summary>
    /// Remove an element from the the referenced node
    /// </summary>
    /// <param name="n">Node</param>
    /// <param name="x">Info</param>
    void Remove(ref NodeABB n, int x);
}
