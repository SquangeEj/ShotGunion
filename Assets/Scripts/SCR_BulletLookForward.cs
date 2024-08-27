using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_BulletLookForward : MonoBehaviour
{
   [SerializeField] private Rigidbody2D rb2d;
  

    // Update is called once per frame
    void Update()
    {
         Vector2 v = rb2d.velocity;
        var angle = Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
