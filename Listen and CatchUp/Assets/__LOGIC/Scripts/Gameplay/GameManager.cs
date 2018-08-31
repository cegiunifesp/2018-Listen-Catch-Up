using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonBehaviour<GameManager> {

    //******* GamePlay ********

    //Palavras
    private List<Word> _wordList;
    private CartaBehavior _rightchoice;
    public GameObject CartaObject;

    //Campanha
    private Score _score;
    private int _level;
    private const int _levelMax = 5;


    //********** UI ***********

    public UIManager UIman;

    //Posicao das Cartas
    private float _deltaX, _deltaY;

    //Timer
    private SimpleTimer _timer_entre_fases;
    private UnityEngine.Events.UnityEvent TimerTick;

    //Relogio
    private SimpleTimer _clock;
    private UnityEngine.Events.UnityEvent ClockTick;

    // Use this for initialization
    void Start () {

        // Posicao das cartas
        _deltaX = 3.7f;
        _deltaY = 2;

        // Timer
        TimerTick = new UnityEngine.Events.UnityEvent();
        _timer_entre_fases = gameObject.AddComponent<SimpleTimer>();
        _timer_entre_fases.Setup(1.5f, TimerTick);
        TimerTick.AddListener(StartLevel);

        //Relogio
        ClockTick = new UnityEngine.Events.UnityEvent();
        _clock = gameObject.AddComponent<SimpleTimer>();
        _clock.Setup(60, TimerTick);
        ClockTick.AddListener(EndCampaign);


        //Gera Palavras
        _wordList = WordGenerator.GenerateWords();

        //Inicia campanha (DEVE SER COLOCADO NO BOTAO START)
        StartCampaign();

	}
	
	// Update is called once per frame
	void Update () {

        UIman.SetClock(_clock.GetCurrenTime().ToString("N0"));
		
	}

    public void VerifyCard(CartaBehavior card)
    {
        
        if(card == _rightchoice)
        {
            print(card.name);
            //TODO
            //Efeito de Brilho
            //Efeito Sonoro
            _score.IncreseScore();
            EndLevel();
        }
        else
        {
            //TODO
            //Brilho de ajuda aaparece na rightchoice
        }

    }


    void StartCampaign()
    {
        //Inicia pontuacao
        _score = new Score();

        //Inicia level
        _level = 0;

        //Inicia Relogio
        _clock.TurnOn();

        //Inicia Cartas
        GenerateCards();
        StartLevel();

    }

    void EndCampaign()
    {
        //Exibe Score

        //Para Relogio
        _clock.TurnOff();
    }


    void StartLevel()
    {
        _level++;

        UIman.SetLevel("Nível " + _level.ToString("N0"));


        int i = 0;
        int rand = Random.Range(0, 11);

        // Da uma palavra pra cada carta e escolhe uma carta aleatoriamente
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Carta"))
        {
            CartaBehavior cb = go.GetComponent<CartaBehavior>();
            cb.ChangeTargetPos();
            cb.SetupCarta(_wordList[Random.Range(0,49)]);

            if (i == rand)
                _rightchoice = cb;

            i++;

        }



    }

    void EndLevel()
    {
        foreach(GameObject go in GameObject.FindGameObjectsWithTag("Carta"))
        {
            go.GetComponent<CartaBehavior>().ChangeTargetPos();
        }

        if (_level == _levelMax)
            EndCampaign();
        else
            _timer_entre_fases.TurnOn();
    }

    void GenerateCards()
    {
        //Inicia Cartas
        Quaternion _quadPadrao = new Quaternion(0, 0, 0, 0);

        for (int i = 0; i < 4; i++) // i = 4 colunas
        {
            for (int j = 0; j < 3; j++) // j = 3 linhas
            {
                CartaBehavior cb = Instantiate(CartaObject, transform.position, _quadPadrao).GetComponent<CartaBehavior>();
                cb.CreateCarta(transform.position + new Vector3(i * _deltaX + -_deltaX * 1.5f, j * _deltaY - _deltaY, 10));
            }
        }
    }
}
