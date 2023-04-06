using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GoalScript _blue, _red, _orange, _green;
    private TextMeshProUGUI _gameOverText;
    private TextMeshProUGUI _timerText;
    private bool _isGameOver;
    private bool _onTimer;
    private float _time;

    // Start is called before the first frame update
    void Start()
    {
       _onTimer = true;

        _gameOverText = GameObject.Find("Game Over Text").GetComponent<TextMeshProUGUI>();
        _gameOverText.gameObject.SetActive(false);

        _timerText = GameObject.Find("Timer").GetComponent<TextMeshProUGUI>();
        _timerText.text = _time.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Timing();

        _isGameOver = _blue.isSolved && _red.isSolved && _orange.isSolved && _green.isSolved;

        if (_isGameOver)
        {
            _gameOverText.gameObject.SetActive(true);
            _onTimer = false;
            _gameOverText.text = "You win! Your result - " + Mathf.Round(_time).ToString() + " second.";
        }
    }



    public void Restart(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    private void Timing()
    {
        if (_onTimer)
        {
            _time += Time.deltaTime;
        }

        _timerText.text = Mathf.Round(_time).ToString();
    }
}
