using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
	public TextMeshProUGUI debugText;

    public enum GameState
    {
        menu,
        house,
        drugs,
        run
    }

    public double timePassed;
    private GameState currentGameState;
    public GameState CurrentGameState
    {
        get { return currentGameState; }
        set { currentGameState = value; }
    }

    [SerializeField]
    public GameObject menuScreen; 
    [SerializeField]
    public GameObject houseScreen; 
    [SerializeField]
    public GameObject drugsScreen; 
    [SerializeField]
    public GameObject runScreen; 

    void Start()
    {
    }

    void FixedUpdate()
    {
    	debugText.text = "GameState: " + currentGameState;
    	
        switch (currentGameState)
        {
            case GameState.menu:
                menuScreen.GetComponent<MenuScreen>().Handle();
                break;
            case GameState.house:
                houseScreen.GetComponent<HouseScreen>().Handle();
                break;
            case GameState.drugs:
                drugsScreen.GetComponent<DrugsScreen>().Handle();
                break;
            case GameState.run:
            	runScreen.GetComponent<RunScreen>().Handle();
                break;
        }
    }
}
