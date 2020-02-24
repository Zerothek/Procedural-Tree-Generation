using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecursiveGenerator : MonoBehaviour {

    public int recursion_iterations = 5, initial_recursion_iterations;
    public int split_number = 2, initial_split_number;
    public float branch_scale = 0.5f, initial_branch_scale;
    public float branch_angle_rotation = 30f, initial_branch_angle_rotation;

    // Use this for initialization
    void Start()
    {
        initial_recursion_iterations = recursion_iterations;
        initial_split_number = split_number;
        initial_branch_scale = branch_scale;
        initial_branch_angle_rotation = branch_angle_rotation;

        recursion_iterations -= 1;
        for (int i = 0; i < split_number; i++)
        {
            if (recursion_iterations > 0)
            {
                GameObject branch_copy = Instantiate(gameObject);
                RecursiveGenerator branch_copy_rec_inst = branch_copy.GetComponent<RecursiveGenerator>();
                //branch_copy.SendMessage("Generated", i);
                branch_copy_rec_inst.growBranch();
                branch_copy_rec_inst.scaleBranch();
                branch_copy_rec_inst.rotateBranch(i);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void scaleBranch()
    {
        this.transform.localScale *= branch_scale;
    }

    public void rotateBranch(int index)
    {
        this.transform.rotation *= Quaternion.Euler(0, 0, branch_angle_rotation * (2 * index - 1));
    }

    public void growBranch()
    {
        this.gameObject.transform.position += this.transform.up * this.transform.localScale.y;
    }
}
