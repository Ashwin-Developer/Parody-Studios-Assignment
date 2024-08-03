using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private GameObject _cubeBag,_gameCompletePanel,_gameOverPanel;
    [SerializeField] private TextMeshProUGUI _totalCoinCollected;
    private int _cubesCollected = 0;
    private int _totalCubes;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else { 
            Destroy(this.gameObject);
        }
    }
    private void Start()
    {
        Time.timeScale = 1f;
        _totalCubes = CubeCounting(_cubeBag);
        Debug.Log($"Cube Count : {_totalCubes}");
        _totalCoinCollected.text = _cubesCollected.ToString() + "/" + _totalCubes.ToString();
    }

    //Taking the total count of cubes in the bag
    private int CubeCounting(GameObject cubeBag)
    {
        int count = 0;
        foreach(Transform child in cubeBag.transform)
        {
            if (child.gameObject.CompareTag("Collectible"))
            {
                count++;
            }
        }
        return count;
    }

    //Updating the score 
    public void UpdateScore()
    {
        _cubesCollected += 1;
        _totalCoinCollected.text = _cubesCollected.ToString() + "/" + _totalCubes.ToString();

        if(_cubesCollected >= _totalCubes)
        {
            _gameCompletePanel.SetActive(true);
        }
    }

    internal void ToggleGameOverPanel()
    {
        Time.timeScale = 0f;
        _gameOverPanel.SetActive(true);
    }

    public void TryAgain()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }
} 
