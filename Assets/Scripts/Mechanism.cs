using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mechanism : MonoBehaviour {

    float timeScaler = 1.0f;
    int Compensate = 0;
    GameObject FloatObject;
    GameObject ObjectCreating;
    List<IFactory> listOfObjects = new List<IFactory>();
    private void Start()
    {
        FloatObject = GameObject.Find("GameObjectFactory");
        ObjectCreating = GameObject.Find("FloatFactory");
        IFactory f = FloatObject.AddComponent<FloatCreating>();
        IFactory o = ObjectCreating.AddComponent<ObjectCreating>();
        listOfObjects.Add(f);
        listOfObjects.Add(o);
    }

    public void PauseMechanism(bool Pause)
    {
        if (Pause)
        {
            StopAllCoroutines();
            StartCoroutine(Timing(Pause));
        }
        else
        {
            for (int i = 0; i < Compensate; i++)
                foreach (IFactory f in listOfObjects)
                    f.Factory();

            StopAllCoroutines();
            StartCoroutine(Timing(Pause));
        }
    }
    public void Deleting()
    {
        StopAllCoroutines();
        foreach (IFactory f in listOfObjects)
        {
            f.DeleteAll();
            Compensate = 0;
        }
    }
    void Creating()
    {
        foreach (IFactory f in listOfObjects)
        {
            f.Factory();
        }
    }
    IEnumerator Timing(bool pause)
    {
        if (pause)
            Compensate++;
        else
            Creating();

        yield return new WaitForSeconds(timeScaler);
        StartCoroutine(Timing(pause));
    }
}
