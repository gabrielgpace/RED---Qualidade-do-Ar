// Controller/GameController.cs
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("Referências")]
    [SerializeField] private HUDView hudView;
    [SerializeField] private GameObject areaDeColeta; // collider da área

    private GameModel gameModel;

    public static GameController Instance { get; private set; }

    void Awake()
    {
        Instance = this;
        gameModel = new GameModel();
    }

    void Start()
    {
        hudView.AtualizarContador(0, gameModel.totalObjetivos);

        // Inicializa todos os Lixos
        foreach (var lixoCtrl in FindObjectsOfType<LixoController>())
            lixoCtrl.Inicializar();

        // Inicializa todos os Carros
        foreach (var carroCtrl in FindObjectsOfType<CarroController>())
            carroCtrl.Inicializar();
    }

    public void RegistrarColeta(int pontos)
    {
        gameModel.AdicionarPontos(pontos);
        hudView.AtualizarContador(gameModel.objetosColetados, gameModel.totalObjetivos);
        hudView.AtualizarPontos(gameModel.pontuacaoTotal);

        if (gameModel.FaseCompleta())
            Debug.Log("FASE COMPLETA!");
    }
}