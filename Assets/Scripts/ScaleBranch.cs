using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleBranch : MonoBehaviour {

    //public float branch_scale = 0.5f;

    public void Generated(Vector3 arguments)
    {
        float branch_scale = Random.Range(arguments[1] * 0.85f, arguments[1] * 1.15f);
        this.transform.localScale *= branch_scale;
    }
}
