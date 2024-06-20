using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Controle : MonoBehaviour
{
    [Header("Hud de compras")]
    // Refer�ncia ao objeto que ser� ativado
    [SerializeField] GameObject upgradeButton;

    [Header("Bot�es da base")]
    [SerializeField] GameObject botao1;
    [SerializeField] GameObject botao2;
    [SerializeField] GameObject botao3;
    [SerializeField] GameObject botao4;

    [Header("Bot�es de escolha")]
    [SerializeField] GameObject botaoEscolha1;
    [SerializeField] GameObject botaoEscolha2;
    [SerializeField] GameObject botaoEscolha3;

    [Header("Mudar o sprite do bot�o")]
    [SerializeField] Image escolha1;
    [SerializeField] Image escolha2;
    [SerializeField] Image escolha3;

    [Header("Texto para ser o timer")]
    [SerializeField] TextMeshProUGUI timerText;
    
    public float tempoDecorrido;
    public int minutos;
    public int segundos;

    // Guarda a imagem selecionada
    private Sprite imagemSelecionada;

    // Guarda o bot�o selecionado
    private GameObject botaoSelecionado;

    private void Start()
    {
        // Adiciona eventos de clique aos bot�es
        botao1.GetComponent<Button>().onClick.AddListener(() => SelecionarBotao(botao1));
        botao2.GetComponent<Button>().onClick.AddListener(() => SelecionarBotao(botao2));
        botao3.GetComponent<Button>().onClick.AddListener(() => SelecionarBotao(botao3));
        botao4.GetComponent<Button>().onClick.AddListener(() => SelecionarBotao(botao4));

        // Adiciona eventos de clique aos bot�es de escolha
        botaoEscolha1.GetComponent<Button>().onClick.AddListener(TrocarImagemEscolha1);
        botaoEscolha2.GetComponent<Button>().onClick.AddListener(TrocarImagemEscolha2);
        botaoEscolha3.GetComponent<Button>().onClick.AddListener(TrocarImagemEscolha3);
    }

    void Update()
    {
        TempoDecorrido();
    }

    public void AbrirHud()
    {
        // Ativa o objeto
        if (upgradeButton != null)
        {
            upgradeButton.SetActive(true);
        }
    }

    public void FecharHud()
    {
        // Desativar o objeto
        if (upgradeButton != null)
        {
            upgradeButton.SetActive(false);
        }
    }

    void TempoDecorrido()
    {
        //Pegando o tempo e transformando ele em segundos e minutos
        tempoDecorrido += Time.deltaTime;
        minutos = Mathf.FloorToInt(tempoDecorrido / 60);
        segundos = Mathf.FloorToInt(tempoDecorrido % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutos, segundos);
    }

    // M�todo para selecionar o bot�o
    public void SelecionarBotao(GameObject botao)
    {
        botaoSelecionado = botao;
    }

    // M�todos para trocar a imagem do bot�o selecionado
    public void TrocarImagemEscolha1()
    {
        if (botaoSelecionado != null)
        {
            imagemSelecionada = escolha1.sprite;
            botaoSelecionado.GetComponent<Image>().sprite = imagemSelecionada;
            botaoSelecionado.GetComponent<Button>().interactable = false;
            FecharHud();
        }
    }

    public void TrocarImagemEscolha2()
    {
        if (botaoSelecionado != null)
        {
            imagemSelecionada = escolha2.sprite;
            botaoSelecionado.GetComponent<Image>().sprite = imagemSelecionada;
            botaoSelecionado.GetComponent<Button>().interactable = false;
            FecharHud();
        }
    }

    public void TrocarImagemEscolha3()
    {
        if (botaoSelecionado != null)
        {
            imagemSelecionada = escolha3.sprite;
            botaoSelecionado.GetComponent<Image>().sprite = imagemSelecionada;
            botaoSelecionado.GetComponent<Button>().interactable = false;
            FecharHud();
        }
    }
}