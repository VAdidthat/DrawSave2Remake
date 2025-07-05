using UnityEngine;

public class SaveGameBehavior : MonoBehaviour
{
    private GameObject LevelButton;
    public int maxlevel = 100;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        PlayerPrefs.SetInt("Level" + 1, 1);
        for (int i = 1; i < maxlevel; i++)
        {
            if (PlayerPrefs.GetInt("Level" + i, 0) == 1)
            {
                LevelButton = GameObject.Find("LevelButton" + i);
                LevelButton.transform.Find("Lock").gameObject.SetActive(false);
                LevelButton.transform.Find("Completed").gameObject.SetActive(true);
            }
            else
            {
                LevelButton = GameObject.Find("LevelButton" + (i-1));
                LevelButton.transform.Find("Completed").gameObject.SetActive(false);
                break;
            }
        }
    }


}
