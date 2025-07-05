using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class GameOverBehavior : MonoBehaviour
{
    private GameManagerBehavior gameManager;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DeadZone") )
        {
            gameManager.isPlayerAlive = false;
            Destroy(gameObject);
        }
    }


    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerBehavior>();
    }

}
