using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GoalScript blue, red, orange, green;
    private TextMeshProUGUI gameOverText;
    private bool isGameOver;
    
    // Start is called before the first frame update
    void Start()
    {
        gameOverText = GameObject.Find("Game Over Text").GetComponent<TextMeshProUGUI>();
        gameOverText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        isGameOver = blue.isSolved && red.isSolved && orange.isSolved && green.isSolved;

        if (isGameOver)
        {
            gameOverText.gameObject.SetActive(true);
        }
    }

    public void Restart(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}
