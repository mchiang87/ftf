using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : Fighter {
    public GameObject drop;
    private Animator anim;

    protected void Start() {
        anim = GetComponent<Animator>();
    }

    protected override void Death() {
        Vector3 position = transform.position;
        anim.SetTrigger("Destroy");
        Instantiate(drop, position, Quaternion.identity);
    }
}
