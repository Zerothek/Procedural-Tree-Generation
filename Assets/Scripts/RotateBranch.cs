using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBranch : MonoBehaviour {

    //public float branch_angle_rotation = 30;

    public void Generated(Vector3 arguments)
    {
        float index = arguments[0];
        //float branch_angle_rotation = arguments[2];
        float branch_angle_rotation = Random.Range(arguments[2] / 4, arguments[2]);
        //Debug.Log(branch_angle_rotation);
        if (index < 2)
        {
            this.transform.rotation *= Quaternion.Euler(0, Random.Range(-50, 50), branch_angle_rotation * (2 * index - 1));
        } else
        {
            this.transform.rotation *= Quaternion.Euler(branch_angle_rotation * (2 * (index - 2) - 1), Random.Range(-50, 50), 0);
        }
    }
}
