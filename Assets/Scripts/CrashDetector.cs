using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] public float loadDelay = 0.5f;
    [SerializeField] ParticleSystem CrashEffect;
    [SerializeField] AudioClip crashSFX;

    bool hasCrashed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground" && !hasCrashed)
        {
            hasCrashed = true;

            FindObjectOfType<PlayerContrtoller>().DisableControls();

            CrashEffect.Play();
            // GetComponent<AudioSource>().PlayOneShot(crashSFX);
            // normalde adam düþtüðünde ses çýkarmasý lazým ama neden çalýþmadý bilmiyorum.

            Invoke("ReloadScene", loadDelay);  //for delay
        }         
    }

    void ReloadScene()
    {
        SceneManager.LoadScene("Level1");
    }
}
