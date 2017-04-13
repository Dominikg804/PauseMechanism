using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCreating : MonoBehaviour, IFactory {

    GameObject Cube;
    GameObject Parent;
    List<GameObject> Objects;
    private void Start()
    {
        Parent = new GameObject("Parent");
        Objects = new List<GameObject>();
    }
    public void Factory()
    {
        Cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Cube.transform.position = new Vector2(Random.Range(-4f,4f), Random.Range(-4f, 4f));
        Cube.transform.parent = Parent.transform;
        Cube.name = "Cube";
        Objects.Add(Cube);
    }
    public void DeleteAll()
    {
        foreach (GameObject o in Objects)
        {
            Destroy(o);
        }
    }

}
