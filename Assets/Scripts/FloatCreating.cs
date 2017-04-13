using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatCreating : MonoBehaviour, IFactory {

    int x = 0;
    public void Factory()
    {
        x++;
    }
    public void DeleteAll()
    {
        x = 0;
    }
}
