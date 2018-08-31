using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartaBehavior : MonoBehaviour {

    // Aparencia
    private Word _word;             //Palavra desta carta

    // Variaveis de Posicionamento
    private Vector3 _startPos;      //Posicao Inicial no Baralho
    private Vector3 _endPos;        //Posicao Durante Jogo
    private Vector3 _targetPos;     //Posicao para onde esta indo
    private bool _move;     //Se esta indo pra algum lugar
    private float _velocity;        //Velocidade de movimento

    // Use this for initialization
    void Start() {


    }

    // Update is called once per frame
    void Update() {

        if(Input.GetMouseButtonDown(0))
        {
            OnClicked();
        }

        CheckMoviment();
    }




    // Realiza Movimentação
    void CheckMoviment()
    {
        if (_move)
        {
 
            transform.position = Vector3.MoveTowards(transform.position, _targetPos, _velocity * Time.deltaTime);

            if (transform.position == _targetPos)
                _move = false;
        }
    }


    public void CreateCarta(Vector3 endpos)
    {
        // Posicionamento inicial
        _startPos = transform.position;
        _targetPos = _startPos;
        _move = false;
        _velocity = 10;
        _endPos = endpos;
    }


    public void SetupCarta(Word word)
    {
        _word = word;
    }

    public void ChangeTargetPos()
    {
        if (_targetPos == _startPos)
            _targetPos = _endPos;
        else
            _targetPos = _startPos;

        _move = true;
    }

    // Quando clickado NAO ESTA DETECTANDO O CLICK AINDA
    public void OnClicked()
    {
        GameManager.Instance.VerifyCard(this);
    }

}
