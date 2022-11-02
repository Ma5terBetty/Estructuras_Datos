using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class TreeTesting : MonoBehaviour
{
    private void Start()
    {
        var tree = new MyTree();

        int[] intVectors = { 67, 12, 95, 56, 85, 1, 100, 1000, 60, 9 };

        var stw = new Stopwatch();

        foreach (var t in intVectors)
        {
            tree.Add(t);
        }
        
        stw.Start();
        Debug.Log("The highest is: " + MyTree.Highest(tree));
        stw.Stop();
        Debug.Log("Time elapsed: " + stw.Elapsed.ToString("hh\\:mm\\:ss\\.ffff"));
        Debug.Log("Ticks elapsed: " + stw.ElapsedTicks);
        
        stw.Restart();
        Debug.Log("\nEl menor es: " + MyTree.Lowest(tree));
        stw.Stop();
        Debug.Log("Time elapsed: {0}" + stw.Elapsed.ToString("hh\\:mm\\:ss\\.ffff"));
        Debug.Log("Ticks elapsed: {0}" + stw.ElapsedTicks);
        
        
    }
}
