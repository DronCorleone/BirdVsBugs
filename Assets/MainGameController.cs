﻿using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainGameController : MonoBehaviour
{
    private RotationController _rotationController;
    private MovingUpController _movingUpController;
    public int[] BugsOnLvl;
    public Slider PowerSlider;
    private int _currentLvl = 0;
    private float BirdPower = 50;

    private void Start()
    {
        _rotationController = FindObjectOfType<RotationController>();
        _movingUpController = FindObjectOfType<MovingUpController>();
    }
    public void EatBug()
    {
        BugsOnLvl[_currentLvl]--;
        if(BugsOnLvl[_currentLvl] <= 0)
        {
            _currentLvl++;
            _movingUpController.MoveObjectsUp();
        }
        BirdPower += 15;
        if(BirdPower > 50)
        {
            BirdPower = 50;
        }
    }
    public void EatNothing()
    {
        BirdPower -= 10;
    }
    private void FixedUpdate()
    {
        BirdPower -= Time.deltaTime * 4f;
        PowerSlider.value = BirdPower / 50;
        if(BirdPower <= 0)
        {
            RestartLvl();
        }
    }
    private void RestartLvl()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
