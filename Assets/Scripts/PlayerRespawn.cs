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

    // deth and respawn :)
    private void OnCollisionEnter2D(Collision2D other)
    {    
        if (other.gameObject.tag == "Trap")
        {
            anim.SetBool("isDead", true);
            SoundManager.PlaySound("Game_Over");
            CinemachineShake.Instance.ShakeCamera(6f, .1f);
            StartCoroutine(WaitForSceneLoad());
        }
        else if(other.gameObject.tag == "FinishLine")
        {
            SceneManager.LoadScene(0);
        }
    }

    // Corountine to reload the scene 
    private IEnumerator WaitForSceneLoad()
    {
        yield return new WaitForSeconds(animLength);
        SceneManager.LoadScene(0);
    } 
}
