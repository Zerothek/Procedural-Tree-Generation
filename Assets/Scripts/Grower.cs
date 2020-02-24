using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grower : MonoBehaviour {
    public void Generated(Vector3 arguments)
    {
        this.gameObject.transform.position += this.transform.up * this.transform.localScale.y * 15.11f;
        this.gameObject.transform.position -= this.transform.right * 1.24f * this.transform.localScale.x;
        this.gameObject.transform.position += this.transform.forward * 2.8f * this.transform.localScale.z;
    }
}
