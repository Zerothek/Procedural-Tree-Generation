using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowTree : MonoBehaviour
{
    float scale_fraction = 0, final_scale;
    float elapsedTime = 0;
    RecursiveInstantiator rec_inst;
    List<GameObject> children;

    // Start is called before the first frame update
    void Start()
    {
        rec_inst = GetComponent<RecursiveInstantiator>();
        children = rec_inst.get_children();
        final_scale = this.transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        scale_fraction = elapsedTime / 5;

        if (elapsedTime > 5)
        {
            this.transform.localScale = new Vector3(final_scale, final_scale, final_scale);
            children = rec_inst.get_children();
            foreach (GameObject child in children)
            {
                child.SetActive(true);
            }
        } else
        {
            this.transform.localScale = new Vector3(scale_fraction * final_scale, scale_fraction * final_scale, scale_fraction * final_scale);
        }
    }
}
