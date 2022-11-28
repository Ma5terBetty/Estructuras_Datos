using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISet
{
    void InitializeSet();
    bool IsSetEmpty();
    void Add(int input);
    int Pick();
    void Remove(int input);
    bool BelongsToSet(int input);
}
