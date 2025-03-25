using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    private int health = 500;
    public Animator animator;
    private int randomNum = 0;

    public ParticleSystem bloodEf;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForSeconds(4);
        randomNum = Random.Range(0, 2);
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        bloodEf.Play();
        if(health > 0 && randomNum == 0)
        {
            animator.SetTrigger("Damage");
        }
        if(health > 0 && randomNum == 1)
        {
            animator.SetTrigger("Demage");
        }

        if (health <= 0)
        {
            
            //   strttm = 0;
            animator.SetTrigger("Death");
           // transform.LookAt(null);
        }
    }
}
