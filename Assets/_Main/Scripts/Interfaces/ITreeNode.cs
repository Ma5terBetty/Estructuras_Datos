
/// <summary>
/// Interface to enforce the properties that a node needs
/// </summary>
/// <typeparam name="T"></typeparam>
public interface ITreeNode
{
    /// <summary>
    /// Stored data
    /// </summary>
    int Info { get; }
    /// <summary>
    /// Reference to the left node
    /// </summary>
    NodeABB Left { get; }
    /// <summary>
    /// Reference to the right node
    /// </summary>
    NodeABB Right { get; }
    /// <summary>
    /// Method to change the stored data
    /// </summary>
    /// <param name="info"></param>
    void SetInfo(in int info);
    /// <summary>
    /// Method to change the left child
    /// </summary>
    /// <param name="child"></param>
    void SetLeftChild(in NodeABB child);
    /// <summary>
    /// Method to change the right child
    /// </summary>
    /// <param name="child"></param>
    void SetRightChild(in NodeABB child);
}
