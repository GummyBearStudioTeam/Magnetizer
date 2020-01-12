using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulateParticles : MonoBehaviour
{
    public GameObject childPrefab;
    public Vector3 position, step;
    public int instances;

    // Start is called before the first frame update
    void Start()
    {
        var ipos = position;
        for (var i = 0; i < instances; i++) {
            Instantiate(childPrefab, ipos, Quaternion.identity, this.gameObject.transform);
            step.Scale(Random.onUnitSphere);
            ipos += step;
        }
    }
}
