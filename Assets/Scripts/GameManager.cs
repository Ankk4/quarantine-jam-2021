using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
	public TextMeshProUGUI debugText;
	[SerializeField]
	public Button debugButton;

	public Dictionary<int, string> GameStates;

    public double timePassed;

    private int currentGameState;
    public int CurrentGameState
    {
        get { return currentGameState; }
        set { currentGameState = value; }
    }

    void Awake()
    {
    	DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {	
    	GameStates = new Dictionary<int, string>(){
    		{0, "Start"},
    		{1, "House"},
    		{2, "Drugs"},
    		{3, "Run"}
    	};
    	debugButton.onClick.AddListener(SwitchScene);
    	CurrentGameState = 0;
    }

    void FixedUpdate()
    {
    	debugText.text = "GameState: " + currentGameState;
    }

    void SwitchScene()
    {
    	Debug.Log("Current: " + currentGameState);
    	currentGameState++;

    	if (currentGameState > GameStates.Count - 1)
    	{
    		currentGameState = 1;
    	}

    	if (SceneManager.GetActiveScene().name == GameStates[currentGameState])
    	{
    		return;
    	}
    	SceneManager.LoadScene(GameStates[currentGameState]);
    }
}
