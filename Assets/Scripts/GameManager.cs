using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] Text _scoreText, _bestScoreText;
    [SerializeField] GameObject _player;

    private void Start()
    {
        //PlayerPrefs.SetInt("Score", 0);
        _bestScoreText.text = "Best Score: " + PlayerPrefs.GetInt("Score").ToString();
    }
    private void Update()
    {
        int _score = _player.GetComponent<PlayerController>()._score;
        
        if (_player.transform.position.y < 0.1f)
        {
            if (PlayerPrefs.GetInt("Score") < _score)
            {
                PlayerPrefs.SetInt("Score", _score);
            }
            SceneManager.LoadScene(0);
        }
        _scoreText.text = _score.ToString();

        if (100 < _score)
        {
            _scoreText.color = Color.white;
        }
        else if (60 < _score)
        {
            _scoreText.color = Color.magenta;
        }
        else if (40 < _score)
        {
            _scoreText.color = Color.yellow;
        }
        else if (20 < _score)
        {
            _scoreText.color = Color.green;
        }
    }
}
