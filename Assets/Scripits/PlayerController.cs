using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;

    private AudioSource playerAudioSource;
    public AudioClip bombClip;
    public AudioClip moneyClip;
    public AudioClip groundClip;

    public ParticleSystem bombParticalS;
    public ParticleSystem moneyParticalS;

    public float speed;
    public float gravityModifier = 1.5f;
    public bool gameOver;
    public bool isLowEnough;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAudioSource = GetComponent<AudioSource>();

        Physics.gravity *= gravityModifier;
        playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 13)
        {
            isLowEnough = false;
        }
        else
        {
            isLowEnough = true;
        }

        if (Input.GetKeyDown(KeyCode.Space) && !gameOver && isLowEnough)
        {
            playerRb.AddForce(Vector3.up * speed);
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bomb"))
        {
            gameOver = true;
            Destroy(collision.gameObject);
            playerAudioSource.PlayOneShot(bombClip, 1);
            bombParticalS.Play();
            Debug.Log("Game Over");
        }
        else if (collision.gameObject.CompareTag("Money"))
        {
            Destroy(collision.gameObject);
            playerAudioSource.PlayOneShot(moneyClip, 1);
            moneyParticalS.Play();
            Debug.Log("Earn Money");
        }
        else if (collision.gameObject.CompareTag("Ground") && !gameOver)
        {
            playerRb.AddForce(Vector3.up * 10, ForceMode.Impulse);
            playerAudioSource.PlayOneShot(groundClip, 1);
        }
    }
}
