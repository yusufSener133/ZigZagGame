using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] Text _scoreText, _bestScoreText, _woowText;
    [SerializeField] GameObject _player;

    bool wow = false;

    private void Start()
    {
           PlayerPrefs.SetInt("Score", 0);
        _bestScoreText.text = "Best Score: " + PlayerPrefs.GetInt("Score").ToString();
    }
    private void Update()
    {
        int _score = _player.GetComponent<PlayerController>()._score;
        if (Input.GetKeyDown(KeyCode.R))
        {
            _player.GetComponent<PlayerController>().startGame = true;
        }
        if (_player.transform.position.y < 0.1f)
        {
            if (PlayerPrefs.GetInt("Score") < _score)
            {
                PlayerPrefs.SetInt("Score", _score);
            }
            SceneManager.LoadScene(0);
        }
        _scoreText.text = _score.ToString();

        if (PlayerPrefs.GetInt("Score") < _score)
        {
            _scoreText.color = Color.green;
            if (!wow)
            {
                StartCoroutine(Woow());
                wow = true;
            }
        }
    }
    IEnumerator Woow()
    {
        _woowText.gameObject.SetActive(true);
        _woowText.text = "";
        foreach (var i in "Woow")
        {
            _woowText.text += i;
            yield return new WaitForSeconds(.1f);
            Debug.Log("saddsa");
            yield return new WaitForSeconds(.1f);
            Debug.Log("a");
        }
        _woowText.gameObject.SetActive(false);
    }
}
