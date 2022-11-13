using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class MyTreeTest
{
    [Test]
    public void CreateTreeInt()
    {
        var myTree = new MyTree<int>();
        Assert.AreEqual(0, myTree.Count);
        Assert.IsTrue(myTree.IsEmpty);
    }

    [Test]
    public void CreateTreeFloat()
    {
        var myList = new MyTree<float>();
        Assert.AreEqual(0, myList.Count);
        Assert.IsTrue(myList.IsEmpty);
    }

    [Test]
    public void CreateTreeVector2()
    {
        var myTree = new MyTree<Vector2>();
        Assert.AreEqual(0, myTree.Count);
        Assert.IsTrue(myTree.IsEmpty);
    }

    [Test]
    public void CreateTreeString()
    {
        var myTree = new MyTree<string>();
        Assert.AreEqual(0, myTree.Count);
        Assert.IsTrue(myTree.IsEmpty);
    }

    [Test]
    public void CreateTreeObject()
    {
        var myTree = new MyTree<object>();
        Assert.AreEqual(0, myTree.Count);
        Assert.IsTrue(myTree.IsEmpty);
    }

    [Test]
    public void TestBracketsInt()
    {
        var myTree = new MyTree<int>();
        myTree.Add(1);
        myTree.Add(2);
        myTree.Add(3);
        myTree.Add(4);
        Assert.AreEqual(4, myTree.Count);
        Assert.AreEqual(1, myTree[0]);
        Assert.AreEqual(2, myTree[1]);
        Assert.AreEqual(3, myTree[2]);
        Assert.AreEqual(4, myTree[3]);


        myTree[3] = 4000;
        Assert.AreEqual(4, myTree.Count);
        Assert.AreEqual(4000, myTree[3]);
        myTree[3] = 34;
        Assert.AreEqual(4, myTree.Count);
        Assert.AreEqual(34, myTree[3]);
    }

    [Test]
    public void TestBracketsFloat()
    {
        var myTree = new MyTree<float>();
        myTree.Add(1.5f);
        myTree.Add(2.5f);
        myTree.Add(3.5f);
        myTree.Add(4.5f);
        Assert.AreEqual(4, myTree.Count);
        Assert.AreEqual(1.5f, myTree[0]);
        Assert.AreEqual(2.5f, myTree[1]);
        Assert.AreEqual(3.5f, myTree[2]);
        Assert.AreEqual(4.5f, myTree[3]);


        myTree[3] = 4000.00008f;
        Assert.AreEqual(4, myTree.Count);
        Assert.AreEqual(4000.00008f, myTree[3]);
        myTree[3] = .0058f;
        Assert.AreEqual(4, myTree.Count);
        Assert.AreEqual(.0058f, myTree[3]);
    }

    [Test]
    public void TestBracketsVector()
    {
        var myTree = new MyTree<Vector2>();
        myTree.Add(new Vector2(1,1));
        myTree.Add(new Vector2(2, 2));
        myTree.Add(new Vector2(3, 3));
        myTree.Add(new Vector2(4, 4));
        Assert.AreEqual(4, myTree.Count);
        Assert.AreEqual(new Vector2(1, 1), myTree[0]);
        Assert.AreEqual(new Vector2(2, 2), myTree[1]);
        Assert.AreEqual(new Vector2(3, 3), myTree[2]);
        Assert.AreEqual(new Vector2(4, 4), myTree[3]);


        myTree[3] = new Vector2(35, 0);
        Assert.AreEqual(4, myTree.Count);
        Assert.AreEqual(new Vector2(35, 0), myTree[3]);
        myTree[3] = Vector2.up;
        Assert.AreEqual(4, myTree.Count);
        Assert.AreEqual(Vector2.up, myTree[3]);
    }

    [Test]
    public void TestBracketsString()
    {
        var myTree = new MyTree<string>();
        myTree.Add("a");
        myTree.Add("b");
        myTree.Add("c");
        myTree.Add("d");
        Assert.AreEqual(4, myTree.Count);
        Assert.AreEqual("a", myTree[0]);
        Assert.AreEqual("b", myTree[1]);
        Assert.AreEqual("c", myTree[2]);
        Assert.AreEqual("d", myTree[3]);


        myTree[3] = "R2D2";
        Assert.AreEqual(4, myTree.Count);
        Assert.AreEqual("R2D2", myTree[3]);
        myTree[3] = "R3D3";
        Assert.AreEqual(4, myTree.Count);
        Assert.AreEqual("R3D3", myTree[3]);
    }

    [Test]
    public void TestBracketsObject()
    {
        var myTree = new MyTree<object>();
        myTree.Add('p');
        myTree.Add(2);
        myTree.Add("eduardo");
        myTree.Add(Vector2.zero);
        Assert.AreEqual(4, myTree.Count);
        Assert.AreEqual('p', myTree[0]);
        Assert.AreEqual(2, myTree[1]);
        Assert.AreEqual("eduardo", myTree[2]);
        Assert.AreEqual(Vector2.zero, myTree[3]);


        myTree[3] = 't';
        Assert.AreEqual(4, myTree.Count);
        Assert.AreEqual('t', myTree[3]);
        myTree[3] = new Vector2(23, 23);
        Assert.AreEqual(4, myTree.Count);
        Assert.AreEqual(new Vector2(23, 23), myTree[3]);
    }

    [Test]
    public void AddInt()
    {
        var myTree = new MyTree<int>();
        myTree.Add(67);
        Assert.AreEqual(1, myTree.Count);
        Assert.IsFalse(myTree.IsEmpty);

        myTree.Add(156);
        Assert.AreEqual(2, myTree.Count);

        myTree.Add(88);
        Assert.AreEqual(3, myTree.Count);

        myTree.Add(190);
        Assert.AreEqual(4, myTree.Count);

        myTree.Add(2);
        Assert.AreEqual(5, myTree.Count);

        Assert.AreEqual(67, myTree[0]);
        Assert.AreEqual(156, myTree[1]);
        Assert.AreEqual(88, myTree[2]);
        Assert.AreEqual(190, myTree[3]);
        Assert.AreEqual(2, myTree[4]);
    }

    [Test]
    public void AddFloat()
    {
        var myTree = new MyTree<float>();
        myTree.Add(67.5f);
        Assert.AreEqual(1, myTree.Count);
        Assert.IsFalse(myTree.IsEmpty);

        myTree.Add(156.005f);
        Assert.AreEqual(2, myTree.Count);

        myTree.Add(88.69f);
        Assert.AreEqual(3, myTree.Count);

        myTree.Add(190);
        Assert.AreEqual(4, myTree.Count);

        myTree.Add(.5f);
        Assert.AreEqual(5, myTree.Count);

        Assert.AreEqual(67.5f, myTree[0]);
        Assert.AreEqual(156.005f, myTree[1]);
        Assert.AreEqual(88.69f, myTree[2]);
        Assert.AreEqual(190, myTree[3]);
        Assert.AreEqual(.5f, myTree[4]);

        
    }

    [Test]
    public void AddVector2()
    {
        var myTree = new MyTree<Vector2>();
        myTree.Add(new Vector2(3, 3));
        Assert.AreEqual(1, myTree.Count);
        Assert.IsFalse(myTree.IsEmpty);

        myTree.Add(new Vector2(3, 3584));
        Assert.AreEqual(2, myTree.Count);

        myTree.Add(Vector2.zero);
        Assert.AreEqual(3, myTree.Count);

        myTree.Add(Vector2.right);
        Assert.AreEqual(4, myTree.Count);

        myTree.Add(Vector2.left);
        Assert.AreEqual(5, myTree.Count);

        Assert.AreEqual(new Vector2(3, 3), myTree[0]);
        Assert.AreEqual(new Vector2(3, 3584), myTree[1]);
        Assert.AreEqual(Vector2.zero, myTree[2]);
        Assert.AreEqual(Vector2.right, myTree[3]);
        Assert.AreEqual(Vector2.left, myTree[4]);

    }

    [Test]
    public void AddString()
    {
        var myTree = new MyTree<string>();
        myTree.Add("eduardo");
        Assert.AreEqual(1, myTree.Count);
        Assert.IsFalse(myTree.IsEmpty);

        myTree.Add(Vector2.zero.ToString());
        Assert.AreEqual(2, myTree.Count);

        myTree.Add("88");
        Assert.AreEqual(3, myTree.Count);

        myTree.Add("C3PO");
        Assert.AreEqual(4, myTree.Count);

        myTree.Add("red");
        Assert.AreEqual(5, myTree.Count);

        Assert.AreEqual("eduardo", myTree[0]);
        Assert.AreEqual(Vector2.zero.ToString(), myTree[1]);
        Assert.AreEqual("88", myTree[2]);
        Assert.AreEqual("C3PO", myTree[3]);
        Assert.AreEqual("red", myTree[4]);

        
    }

    [Test]
    public void AddObject()
    {
        var myTree = new MyTree<object>();
        myTree.Add(67);
        Assert.AreEqual(1, myTree.Count);
        Assert.IsFalse(myTree.IsEmpty);

        myTree.Add("eduardo");
        Assert.AreEqual(2, myTree.Count);

        myTree.Add(Vector2.right);
        Assert.AreEqual(3, myTree.Count);

        myTree.Add(190.5f);
        Assert.AreEqual(4, myTree.Count);

        myTree.Add('e');
        Assert.AreEqual(5, myTree.Count);

        Assert.AreEqual(67, myTree[0]);
        Assert.AreEqual("eduardo", myTree[1]);
        Assert.AreEqual(Vector2.right, myTree[2]);
        Assert.AreEqual(190.5f, myTree[3]);
        Assert.AreEqual('e', myTree[4]);

        
    }

    [Test]
    public void InsertInt()
    {
        var myTree = new MyTree<int>();
        myTree.Add(55);
        myTree.Add(56);
        myTree.Add(57);
        myTree.Add(58);
        Assert.AreEqual(4, myTree.Count);
        myTree.Insert(2, 88);
        Assert.AreEqual(88, myTree[2]);
        Assert.AreEqual(57, myTree[3]);
        Assert.AreEqual(5, myTree.Count);
    }

    [Test]
    public void InsertFloat()
    {
        var myTree = new MyTree<float>();
        myTree.Add(55.5f);
        myTree.Add(56.5f);
        myTree.Add(57.5f);
        myTree.Add(58.5f);
        Assert.AreEqual(4, myTree.Count);
        myTree.Insert(2, 88.5f);
        Assert.AreEqual(88.5f, myTree[2]);
        Assert.AreEqual(57.5f, myTree[3]);
        Assert.AreEqual(5, myTree.Count);
    }

    [Test]
    public void InsertVector2()
    {
        var myTree = new MyTree<Vector2>();
        myTree.Add(new Vector2(0, 99));
        myTree.Add(new Vector2(58, 65));
        myTree.Add(new Vector2(66, 99));
        myTree.Add(new Vector2(0, 9321));
        Assert.AreEqual(4, myTree.Count);
        myTree.Insert(2, new Vector2(687, 99));
        Assert.AreEqual(new Vector2(687, 99), myTree[2]);
        Assert.AreEqual(new Vector2(66, 99), myTree[3]);
        Assert.AreEqual(5, myTree.Count);
    }

    [Test]
    public void InsertString()
    {
        var myTree = new MyTree<string>();
        myTree.Add("eduardo");
        myTree.Add("658444");
        myTree.Add("felipe");
        myTree.Add("carmela");
        Assert.AreEqual(4, myTree.Count);
        myTree.Insert(2, new Vector2(687, 99).ToString());
        Assert.AreEqual(new Vector2(687, 99).ToString(), myTree[2]);
        Assert.AreEqual("felipe", myTree[3]);
        Assert.AreEqual(5, myTree.Count);
    }

    [Test]
    public void InsertObject()
    {
        var myTree = new MyTree<object>();
        myTree.Add(55);
        myTree.Add(Vector2.up);
        myTree.Add("felipe");
        myTree.Add(58);
        Assert.AreEqual("felipe", myTree[2]);
        Assert.AreEqual(4, myTree.Count);
        myTree.Insert(2, 'd');
        Assert.AreEqual('d', myTree[2]);
        Assert.AreEqual("felipe", myTree[3]);
        Assert.AreEqual(5, myTree.Count);
    }

    [Test]
    public void RemoveInt()
    {
        var myTree = new MyTree<int>();
        myTree.Add(5);
        myTree.Add(6);
        Assert.AreEqual(2, myTree.Count);
        Assert.AreEqual(5, myTree[0]);
        Assert.AreEqual(6, myTree[1]);

        myTree.Remove(5);
        Assert.AreEqual(1, myTree.Count);
        Assert.AreEqual(6, myTree[0]);
        Assert.IsFalse(myTree.Remove(45));
    }

    [Test]
    public void RemoveFloat()
    {
        var myTree = new MyTree<float>();
        myTree.Add(5.5f);
        myTree.Add(6.5f);
        Assert.AreEqual(2, myTree.Count);
        Assert.AreEqual(5.5f, myTree[0]);
        Assert.AreEqual(6.5f, myTree[1]);

        myTree.Remove(5.5f);
        Assert.AreEqual(1, myTree.Count);
        Assert.AreEqual(6.5f, myTree[0]);
        Assert.IsFalse(myTree.Remove(45));
    }

    [Test]
    public void RemoveVector2()
    {
        var myTree = new MyTree<Vector2>();
        myTree.Add(Vector2.right);
        myTree.Add(Vector2.up);
        Assert.AreEqual(2, myTree.Count);
        Assert.AreEqual(Vector2.right, myTree[0]);
        Assert.AreEqual(Vector2.up, myTree[1]);

        myTree.Remove(Vector2.right);
        Assert.AreEqual(1, myTree.Count);
        Assert.AreEqual(Vector2.up, myTree[0]);
        Assert.IsFalse(myTree.Remove(Vector2.left));
    }

    [Test]
    public void RemoveString()
    {
        var myTree = new MyTree<string>();
        myTree.Add("eduardo");
        myTree.Add("maria");
        Assert.AreEqual(2, myTree.Count);
        Assert.AreEqual("eduardo", myTree[0]);
        Assert.AreEqual("maria", myTree[1]);

        myTree.Remove("eduardo");
        Assert.AreEqual(1, myTree.Count);
        Assert.AreEqual("maria", myTree[0]);
        Assert.IsFalse(myTree.Remove("franco"));
    }

    [Test]
    public void RemoveObject()
    {
        var myTree = new MyTree<object>();
        myTree.Add('d');
        myTree.Add(34);
        Assert.AreEqual(2, myTree.Count);
        Assert.AreEqual('d', myTree[0]);
        Assert.AreEqual(34, myTree[1]);

        myTree.Remove('d');
        Assert.AreEqual(1, myTree.Count);
        Assert.AreEqual(34, myTree[0]);
        Assert.IsFalse(myTree.Remove("franco"));
    }

    [Test]
    public void RemoveMultiple()
    {
        var myTree = new MyTree<int>();
        Assert.IsTrue(myTree.IsEmpty);
        myTree.Add(10);
        myTree.Add(20);
        myTree.Add(30);
        myTree.Add(40);
        myTree.Add(50);
        myTree.Add(60);
        myTree.Add(70);
        myTree.Add(80);
        Assert.AreEqual(8, myTree.Count);
        Assert.AreEqual(10, myTree[0]);
        Assert.AreEqual(20, myTree[1]);
        Assert.AreEqual(30, myTree[2]);
        Assert.AreEqual(40, myTree[3]);
        Assert.AreEqual(50, myTree[4]);
        Assert.AreEqual(60, myTree[5]);
        Assert.AreEqual(70, myTree[6]);
        Assert.AreEqual(80, myTree[7]);
        
        myTree.Remove(10);
        myTree.Remove(50);
        myTree.Remove(80);
        Assert.AreEqual(5, myTree.Count);
        Assert.AreEqual(20, myTree[0]);//30
        Assert.AreEqual(30, myTree[1]);//40
        Assert.AreEqual(40, myTree[2]);//60
        Assert.AreEqual(60, myTree[3]);//70
        Assert.AreEqual(70, myTree[4]);//80
    }

    [Test]
    public void RemoveAtInt()
    {
        var myTree = new MyTree<int>();
        myTree.Add(5);
        myTree.Add(6);
        Assert.AreEqual(2, myTree.Count);
        Assert.AreEqual(5, myTree[0]);
        Assert.AreEqual(6, myTree[1]);

        myTree.RemoveAt(0);
        Assert.AreEqual(1, myTree.Count);
        Assert.AreEqual(6, myTree[0]);
    }

    [Test]
    public void RemoveAtFloat()
    {
        var myTree = new MyTree<float>();
        myTree.Add(5.5f);
        myTree.Add(6.25f);
        Assert.AreEqual(2, myTree.Count);
        Assert.AreEqual(5.5f, myTree[0]);
        Assert.AreEqual(6.25f, myTree[1]);

        myTree.RemoveAt(0);
        Assert.AreEqual(1, myTree.Count);
        Assert.AreEqual(6.25f, myTree[0]);
    }

    [Test]
    public void RemoveAtVector2()
    {
        var myTree = new MyTree<float>();
        myTree.Add(5.5f);
        myTree.Add(6.25f);
        Assert.AreEqual(2, myTree.Count);
        Assert.AreEqual(5.5f, myTree[0]);
        Assert.AreEqual(6.25f, myTree[1]);

        myTree.RemoveAt(0);
        Assert.AreEqual(1, myTree.Count);
        Assert.AreEqual(6.25f, myTree[0]);
    }

    [Test]
    public void RemoveAtString()
    {
        var myTree = new MyTree<string>();
        myTree.Add("eduardo");
        myTree.Add("maria");
        Assert.AreEqual(2, myTree.Count);
        Assert.AreEqual("eduardo", myTree[0]);
        Assert.AreEqual("maria", myTree[1]);

        myTree.RemoveAt(0);
        Assert.AreEqual(1, myTree.Count);
        Assert.AreEqual("maria", myTree[0]);
    }

    [Test]
    public void RemoveAtObject()
    {
        var myTree = new MyTree<object>();
        myTree.Add("5.5f");
        myTree.Add('f');
        Assert.AreEqual(2, myTree.Count);
        Assert.AreEqual("5.5f", myTree[0]);
        Assert.AreEqual('f', myTree[1]);

        myTree.RemoveAt(0);
        Assert.AreEqual(1, myTree.Count);
        Assert.AreEqual('f', myTree[0]);
    }

    [Test]
    public void RemoveAtMultiple()
    {
        var myTree = new MyTree<int>();
        Assert.IsTrue(myTree.IsEmpty);
        myTree.Add(10);
        myTree.Add(20);
        myTree.Add(30);
        myTree.Add(40);
        myTree.Add(50);
        myTree.Add(60);
        myTree.Add(70);
        myTree.Add(80);
        Assert.AreEqual(8, myTree.Count);
        Assert.AreEqual(10, myTree[0]);
        Assert.AreEqual(20, myTree[1]);
        Assert.AreEqual(30, myTree[2]);
        Assert.AreEqual(40, myTree[3]);
        Assert.AreEqual(50, myTree[4]);
        Assert.AreEqual(60, myTree[5]);
        Assert.AreEqual(70, myTree[6]);
        Assert.AreEqual(80, myTree[7]);

        myTree.RemoveAt(0);
        myTree.RemoveAt(3);
        myTree.RemoveAt(5);

        Assert.AreEqual(5, myTree.Count);
        Assert.AreEqual(20, myTree[0]);
        Assert.AreEqual(30, myTree[1]);
        Assert.AreEqual(40, myTree[2]);
        Assert.AreEqual(60, myTree[3]);
        Assert.AreEqual(70, myTree[4]);
    }

    [Test]
    public void ContainsInt()
    {
        var myTree = new MyTree<int>();
        myTree.Add(5);
        myTree.Add(6);
        Assert.IsTrue(myTree.Contains(5));
        Assert.IsFalse(myTree.Contains(45));
    }

    [Test]
    public void ContainsFloat()
    {
        var myTree = new MyTree<float>();
        myTree.Add(5.5f);
        myTree.Add(6.765f);
        Assert.IsTrue(myTree.Contains(6.765f));
        Assert.IsFalse(myTree.Contains(45.25f));
    }

    [Test]
    public void ContainsVector2()
    {
        var myTree = new MyTree<Vector2>();
        myTree.Add(new Vector2(90, 90));
        myTree.Add(new Vector2(35, 90));
        Assert.IsTrue(myTree.Contains(new Vector2(35, 90)));
        Assert.IsFalse(myTree.Contains(Vector2.zero));
    }

    [Test]
    public void ContainsString()
    {
        var myTree = new MyTree<string>();
        myTree.Add("eduardo");
        myTree.Add("maria");
        Assert.IsTrue(myTree.Contains("maria"));
        Assert.IsFalse(myTree.Contains("mariana"));
    }

    [Test]
    public void ContainsObject()
    {
        var myTree = new MyTree<object>();
        myTree.Add("eduardo");
        myTree.Add(Vector2.zero);
        Assert.IsTrue(myTree.Contains("eduardo"));
        Assert.IsTrue(myTree.Contains(Vector2.zero));
        Assert.IsFalse(myTree.Contains(58));
    }

    [Test]
    public void ClearInt()
    {
        var myTree = new MyTree<int>();
        myTree.Add(34);
        Assert.AreEqual(1, myTree.Count);
        Assert.IsFalse(myTree.IsEmpty);
        myTree.Clear();
        Assert.AreEqual(0, myTree.Count);
        Assert.IsTrue(myTree.IsEmpty);
    }

    [Test]
    public void ClearFloat()
    {
        var myTree = new MyTree<float>();
        myTree.Add(34.45f);
        Assert.AreEqual(1, myTree.Count);
        Assert.IsFalse(myTree.IsEmpty);
        myTree.Clear();
        Assert.AreEqual(0, myTree.Count);
        Assert.IsTrue(myTree.IsEmpty);
    }

    [Test]
    public void ClearVector2()
    {
        var myTree = new MyTree<Vector2>();
        myTree.Add(Vector2.zero);
        Assert.AreEqual(1, myTree.Count);
        Assert.IsFalse(myTree.IsEmpty);
        myTree.Clear();
        Assert.AreEqual(0, myTree.Count);
        Assert.IsTrue(myTree.IsEmpty);
    }

    [Test]
    public void ClearString()
    {
        var myTree = new MyTree<string>();
        myTree.Add("eduardo");
        Assert.AreEqual(1, myTree.Count);
        Assert.IsFalse(myTree.IsEmpty);
        myTree.Clear();
        Assert.AreEqual(0, myTree.Count);
        Assert.IsTrue(myTree.IsEmpty);
    }

    [Test]
    public void ClearObject()
    {
        var myTree = new MyTree<object>();
        myTree.Add('d');
        Assert.AreEqual(1, myTree.Count);
        Assert.IsFalse(myTree.IsEmpty);
        myTree.Clear();
        Assert.AreEqual(0, myTree.Count);
        Assert.IsTrue(myTree.IsEmpty);
    }

    [Test]
    public void ClearTree()
    {
        MyTree<int> myTree = new MyTree<int>();
        Assert.IsTrue(myTree.IsEmpty);
        myTree.Add(1);
        myTree.Add(3);
        Assert.IsFalse(myTree.IsEmpty);
        Assert.AreEqual(2, myTree.Count);

        myTree.Clear();
        Assert.IsTrue(myTree.IsEmpty);
        Assert.AreEqual(0, myTree.Count);
    }

    [Test]
    public void Contains()
    {
        var myTree = new MyTree<int>();
        myTree.Add(1);
        myTree.Add(4);
        myTree.Add(78);
        Assert.IsTrue(myTree.Contains(1));
        Assert.IsTrue(myTree.Contains(4));
        Assert.IsTrue(myTree.Contains(78));
        Assert.IsFalse(myTree.Contains(451));
        Assert.IsFalse(myTree.Contains(890));
        Assert.IsFalse(myTree.Contains(909));
    }

    [Test]
    public void Add()
    {
        var myTree = new MyTree<int>();
        myTree.Add(1);
        myTree.Add(4);
        myTree.Add(78);
        Assert.IsTrue(myTree.Contains(1));
        Assert.IsTrue(myTree.Contains(4));
        Assert.IsTrue(myTree.Contains(78));
        Assert.AreEqual(1, myTree[0]);
        Assert.AreEqual(4, myTree[1]);
        Assert.AreEqual(78, myTree[2]);
    }

    [Test]
    public void Insert()
    {
        var myTree = new MyTree<int>();
        myTree.Add(1);
        myTree.Add(4);
        myTree.Add(78);
        Assert.AreEqual(3, myTree.Count);
        Assert.AreEqual(1, myTree[0]);
        Assert.AreEqual(4, myTree[1]);
        Assert.AreEqual(78, myTree[2]);

        myTree.Insert(0, 7);
        Assert.AreEqual(4, myTree.Count);
        Assert.AreEqual(7, myTree[0]);
        Assert.AreEqual(1, myTree[1]);
        Assert.AreEqual(4, myTree[2]);
        Assert.AreEqual(78, myTree[3]);
    }
    
    [Test]
    public void RemoveRoot()
    {
        var myTree = new MyTree<int>();
        Assert.IsTrue(myTree.IsEmpty);
        myTree.Add(1);
        myTree.Add(5);
        myTree.Add(6);
        
        myTree.Remove(1);
        Assert.AreEqual(6, myTree.Root.Info.Data);
        Assert.IsFalse(myTree.IsEmpty);
    }

    // [Test]
    // public void RemoveLast()
    // {
    //     var myTree = new MyTree<int>();
    //     Assert.IsTrue(myTree.IsEmpty);
    //     myTree.Add(1);
    //     myTree.Add(5);
    //     myTree.Add(6);
    //     
    //     myTree.Remove(6);
    //     var root = myTree.Root;
    //     var element5 = myTree.Find(5);
    //     var element1 = myTree.Find(1);
    //     
    //     Assert.AreEqual(5, root.Info);
    //     Assert.AreEqual(null, element5.Right);
    //     Assert.AreEqual(1, element5.Left.Info);
    //     Assert.IsFalse(myTree.IsEmpty);
    // }

    // [Test]
    // public void RemoveSecond()
    // {
    //     var myTree = new MyTree<int>();
    //     Assert.IsTrue(myTree.IsEmpty);
    //     myTree.Add(1);
    //     myTree.Add(5);
    //     myTree.Add(6);
    //     
    //     myTree.Remove(5);
    //     var root = myTree.Root;
    //     var element6 = myTree.Find(6);
    //     var element1 = myTree.Find(1);
    //     
    //     Assert.AreEqual(6, root.Info);
    //     Assert.AreEqual(null, element6.Right);
    //     Assert.AreEqual(1, element6.Left.Info);
    //     Assert.IsFalse(myTree.IsEmpty);
    // }
    //
    // [Test]
    // public void RemoveIntermediate()
    // {
    //     var myTree = new MyTree<int>();
    //     Assert.IsTrue(myTree.IsEmpty);
    //     myTree.Add(3);
    //     myTree.Add(1);
    //     myTree.Add(10);
    //     myTree.Add(7);
    //     myTree.Add(12);
    //
    //     var root = myTree.Root;
    //     Assert.AreEqual(1, root.Info.Id);
    //     myTree.Remove(10);
    //     root = myTree.Root;
    //     Assert.AreEqual(1, root.Info.Id);
    // }

    [Test]
    public void RemoveAt()
    {
        var myTree = new MyTree<int>();
        Assert.IsTrue(myTree.IsEmpty);
        myTree.Add(45);
        myTree.Add(65);
        myTree.Add(78);
        myTree.Add(45);
        myTree.Add(453);
        myTree.Add(44444);
        myTree.Add(344);
        myTree.Add(0003);
        Assert.AreEqual(8, myTree.Count);
        Assert.AreEqual(45, myTree[0]);
        Assert.AreEqual(65, myTree[1]);
        Assert.AreEqual(78, myTree[2]);
        Assert.AreEqual(45, myTree[3]);
        Assert.AreEqual(453, myTree[4]);
        Assert.AreEqual(44444, myTree[5]);
        Assert.AreEqual(344, myTree[6]);
        Assert.AreEqual(0003, myTree[7]);
        myTree.RemoveAt(0);
        Assert.AreEqual(7, myTree.Count);
        Assert.AreEqual(65, myTree[0]);
        Assert.AreEqual(78, myTree[1]);
        Assert.AreEqual(45, myTree[2]);
        Assert.AreEqual(453, myTree[3]);
        Assert.AreEqual(44444, myTree[4]);
        Assert.AreEqual(344, myTree[5]);
        Assert.AreEqual(0003, myTree[6]);
    }

    [Test]
    public void Remove()
    {
        var myTree = new MyTree<int>();
        Assert.IsTrue(myTree.IsEmpty);
        myTree.Add(45);
        myTree.Add(65);
        myTree.Add(78);
        myTree.Add(45);
        myTree.Add(453);
        myTree.Add(44444);
        myTree.Add(344);
        myTree.Add(0003);
        Assert.AreEqual(8, myTree.Count);
        Assert.AreEqual(45, myTree[0]);
        Assert.AreEqual(65, myTree[1]);
        Assert.AreEqual(78, myTree[2]);
        Assert.AreEqual(45, myTree[3]);
        Assert.AreEqual(453, myTree[4]);
        Assert.AreEqual(44444, myTree[5]);
        Assert.AreEqual(344, myTree[6]);
        Assert.AreEqual(0003, myTree[7]);
        myTree.Remove(45);
        Assert.AreEqual(7, myTree.Count);
        Assert.AreEqual(65, myTree[0]);
        Assert.AreEqual(78, myTree[1]);
        Assert.AreEqual(45, myTree[2]);
        Assert.AreEqual(453, myTree[3]);
        Assert.AreEqual(44444, myTree[4]);
        Assert.AreEqual(344, myTree[5]);
        Assert.AreEqual(0003, myTree[6]);

    }

}
