using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    private void Awake()
    {
        instance = this;
    }

    [SerializeField] private GameObject StartButton;
    [SerializeField] private GameObject retryPanel;
    [SerializeField] private GameObject successPanel;

    public void StartGame()
    {
        StartButton.SetActive(false);
        BallForce.instance.rb.useGravity = true;
        FootController.instance.isPlay = true;
    }
    public void RetrGame()
    {
        retryPanel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        FootController.instance.isPlay = false;
    }
    public void SuccessLevel()
    {
        successPanel.SetActive(true);
        BallForce.instance.rb.useGravity = false;
        FootController.instance.isPlay = false;
    }
}
