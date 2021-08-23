using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forcefield : MonoBehaviour
{
    public GameObject player;
    WinLose win;
    public ParticleSystem particles;

    private void Start()
    {
        win = GameObject.Find("GameController").GetComponent<WinLose>();
    }
    public void ChangeSize(float scaleFactor)
    {
        if (transform.localScale.x >= 0.5f)// <- if the forcefield hits the player when it reaches 0.3
        {
            transform.localScale = new Vector2(transform.localScale.x + scaleFactor, transform.localScale.y + scaleFactor);
        }
        else
        {
            Destroy(player);
            win.WinText(false, false);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            particles.Play();
            transform.localScale = new Vector2(1, 1);
        }
    }

    public void PistolPowerup()
    {
        transform.localScale = new Vector2(transform.localScale.x + 1f, transform.localScale.y + 1f);
    }
}