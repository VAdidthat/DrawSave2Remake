using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerBehavior : MonoBehaviour
{
    public GameObject youWinUI;
    public GameObject youLoseUI;
    public Text timeCountUI;

    public bool isGameStart = false;
    public bool isPlayerAlive = true;
    public bool isGameEnd = false;
    private float timeCount = 0;
    public int currentLevelIndex;
    public int nextLevelIndex;

    void YouWin()
    {
        youWinUI.SetActive(true);

        // save game hoan thanh level
        PlayerPrefs.SetInt("Level" + nextLevelIndex, 1);
        PlayerPrefs.Save();
        Debug.Log("Level" + nextLevelIndex + " is unlock");
        isGameEnd = true;
    }
    void YouLose()
    {
        youLoseUI.SetActive(true);
        StartCoroutine(ReloadSceneAfterDelay());
    }
 
    IEnumerator ReloadSceneAfterDelay()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameStart&& !isGameEnd)
        {
            if (isPlayerAlive)
            {
                timeCount += Time.deltaTime;
                int count = (int)(5 - timeCount) ; 
                timeCountUI.text = count + "...";
                if (timeCount >= 4f)
                {
                    YouWin();
                }
            }
            else { YouLose(); }

        }
    }
    void Start()
    {
        currentLevelIndex = SceneManager.GetActiveScene().buildIndex - 1;
        nextLevelIndex = currentLevelIndex + 1;
    }
}
