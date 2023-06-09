using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] Text _scoreText, _bestScoreText;
    [SerializeField] GameObject _player, _gameOverPanel;
    [SerializeField] Animator _animator;

    private void Start()
    {
        _bestScoreText.text = "Best Score: " + PlayerPrefs.GetInt("Score").ToString();
    }
    private void Update()
    {
        int _score = _player.GetComponent<PlayerController>()._score;

        if (PlayerPrefs.GetInt("Score") - _score == -1)
        {
            _animator.Play("NewScore");
        }
        if (_player.transform.position.y < 0.1f)
        {
            if (PlayerPrefs.GetInt("Score") < _score)
            {
                PlayerPrefs.SetInt("Score", _score);
            }
            _gameOverPanel.SetActive(true);
            Destroy(Camera.main.GetComponent<CameraFollow>());
            _player.gameObject.SetActive(false);

        }
        _scoreText.text = _score.ToString();
    }
    public void RestartButton()
    {
        SceneManager.LoadScene(0);
    }
    public void QuitButton()
    {
        Application.Quit();
    }
    public void ResetBestScore()
    {
        PlayerPrefs.SetInt("Score", 0);
    }
}
