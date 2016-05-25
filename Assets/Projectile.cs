using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    Vector3 P0, P1, P2;

    public float height;
    Transform attacker, target;

    float progress = 0f;
    public float speed = 1f;


    public Vector3 Evaluate(float t) {
        t = Mathf.Clamp01(t);
        float t1 = 1f - t;
        return t1 * t1 * P0 + 2 * t * t1 * P1 + t * t * P2;
    }

    public void SetBezierParams(Transform att, Transform tar) {
        attacker = att;
        target = tar;
    }

    void Calculate() {
        P0 = attacker.position;
        P2 = target.position;
        P1 = (P0 + P2) / 2f + new Vector3(0, height, 0);
    }

    void Update() {
        if (target != null && attacker != null) {
            Calculate();

            transform.LookAt(Evaluate(progress));
            transform.position = Evaluate(progress);

            Evaluate(progress);
            progress += speed*Time.deltaTime;

            if (progress >= 1f) {
                Destroy(this.gameObject);
            }
        }
    }

    void OnDrawGizmos() {

        if (target != null && attacker != null) {
            Calculate();
            Gizmos.color = Color.green;

            for (int i = 1; i < 50f; i++) {
                float t = (i - 1f) / 49f;
                float t1 = i / 49f;
                Gizmos.DrawLine(Evaluate(t), Evaluate(t1));
            }
        }
    }
}
