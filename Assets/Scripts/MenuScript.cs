using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public Text highText;
    int _highScore;

    // Start is called before the first frame update
    void Start()
    {
        Display();
    }

    // Update is called once per frame
    void Update()
    {
        Display();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void OnClick()
    {
        SceneManager.LoadScene("Mazescape");

    }

    void Display()
    {
        _highScore = PlayerPrefs.GetInt("old");
        highText.text = "high score: " + _highScore;
    }
}
