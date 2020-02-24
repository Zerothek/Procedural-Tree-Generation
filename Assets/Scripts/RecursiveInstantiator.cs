using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecursiveInstantiator : MonoBehaviour {

    public int recursion_iterations = 5;
    int initial_recursion_iterations = 5;
    public int split_number = 4;
    int initial_split_number = 4;
    public float branch_scale = 0.7f;
    float initial_branch_scale = 0.7f;
    public float branch_angle_rotation = 30f;
    float initial_branch_angle_rotation = 30f;
    List<GameObject> children = new List<GameObject>();
    // public GameObject leaves;
    public GameObject leaves;
    GameObject root = null;

    // Use this for initialization
    void Start()
    {
        initial_recursion_iterations = recursion_iterations;
        initial_split_number = split_number;
        initial_branch_scale = branch_scale;
        initial_branch_angle_rotation = branch_angle_rotation;

        if (recursion_iterations > 0)
        {
            int number_of_branches = split_number;

            if (root != null && recursion_iterations < root.GetComponent<RecursiveInstantiator>().recursion_iterations - 1)
            {
                number_of_branches = Random.Range(2, split_number);
            }

            for (int i = 0; i < number_of_branches; i++)
            {
                GameObject branch_copy = null;
                branch_copy = Instantiate(gameObject);
                children.Add(branch_copy);
                RecursiveInstantiator branch_copy_rec_inst = branch_copy.GetComponent<RecursiveInstantiator>();
                branch_copy_rec_inst.recursion_iterations -= 1;

                if (root == null)
                {
                    branch_copy_rec_inst.root = gameObject;
                } else
                {
                    branch_copy_rec_inst.root = this.root;
                }

                Vector3 arguments = new Vector3((float)i, branch_scale, branch_angle_rotation);
                branch_copy.SendMessage("Generated", arguments);
            }
        }

        Debug.Log(root);
        if (root != null && recursion_iterations < root.GetComponent<RecursiveInstantiator>().recursion_iterations - 1)
        {
            //GameObject leaf = Instantiate(leaves);
            //children.Add(leaf);
            leaves.SetActive(true);
        }

        if (root != null)
        {
            this.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update () {
		if (parameters_change())
        {
            Debug.Log("jauwhsd");
            foreach (GameObject child in children)
            {
                if (recursion_iterations > 0)
                {
                    RecursiveInstantiator child_inst = child.GetComponent<RecursiveInstantiator>();
                    child.SendMessage("DestroyRecursive", child_inst.get_children());
                } else
                {
                    Destroy(child);
                }
            }

            if (recursion_iterations > 0)
            {
                children.Clear();
                for (int i = 0; i < split_number; i++)
                {
                    GameObject branch_copy = Instantiate(gameObject);
                    children.Add(branch_copy);
                    RecursiveInstantiator branch_copy_rec_inst = branch_copy.GetComponent<RecursiveInstantiator>();
                    branch_copy_rec_inst.recursion_iterations -= 1;
                    Vector3 arguments = new Vector3((float)i, branch_scale, branch_angle_rotation);
                    branch_copy.SendMessage("Generated", arguments);
                }
            }
        }
	}

    bool parameters_change()
    {
        if (initial_branch_angle_rotation != branch_angle_rotation || initial_branch_scale != branch_scale ||
            initial_recursion_iterations != recursion_iterations || initial_split_number != split_number)
        {
            initial_branch_angle_rotation = branch_angle_rotation;
            initial_branch_scale = branch_scale;
            initial_recursion_iterations = recursion_iterations;
            initial_split_number = split_number;
            return true;
        }

        return false;
    }

    public List<GameObject> get_children()
    {
        return this.children;
    }
}
