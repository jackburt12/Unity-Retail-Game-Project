using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour
{

    public Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            anim.SetBool("Click", true);
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            anim.SetBool("Click", false);
        }
    }
}