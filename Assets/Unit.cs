using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {

    public GameObject projectile;
    public Transform gunEnd;
    public Transform target;

    void Update() {
        if (Input.GetKeyDown(KeyCode.F)) {
            ((GameObject)Instantiate(projectile,gunEnd.position,Quaternion.identity)).GetComponent<Projectile>().SetBezierParams(gunEnd,target);
        }
    }
}
