using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyChildren : MonoBehaviour {

    public void DestroyRecursive(List<GameObject> children)
    {
        foreach (GameObject child in children)
        {
            //Debug.Log("jauwhsd");
            RecursiveInstantiator child_inst = child.GetComponent<RecursiveInstantiator>();
            //child_inst.updateNode(this.gameObject);
            child.SendMessage("DestroyRecursive", child_inst.get_children());
            //i++;
        }
        Destroy(this.gameObject);
    }
}
