using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour {

    private Transform target;
    public void SetTarget(Transform _target)
    {
        this.target = _target;
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) return;
        transform.LookAt(target);
        transform.position += transform.forward * Time.deltaTime * 10;
        if (Vector3.Distance(transform.position, target.position) < 0.2)
        {
            Destroy(this.gameObject);
        }
    }
}
