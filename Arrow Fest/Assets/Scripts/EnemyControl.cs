using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    Animator enemyAnim;
     void Start()
    {
        enemyAnim = GetComponent<Animator>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag =="Player")
        {
            enemyAnim.SetTrigger("isDeath");
            
        }
    }
}
