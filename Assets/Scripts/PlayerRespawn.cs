using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{
    
    private Animator anim;
    private float animLength = 0.3f;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {    
        if (other.gameObject.tag == "Trap")
        {
            anim.SetBool("isDead", true);
            StartCoroutine(WaitForSceneLoad());
        }
        
    }

    private IEnumerator WaitForSceneLoad()
    {
        yield return new WaitForSeconds(animLength);
        SceneManager.LoadScene(0);
    } 
}
