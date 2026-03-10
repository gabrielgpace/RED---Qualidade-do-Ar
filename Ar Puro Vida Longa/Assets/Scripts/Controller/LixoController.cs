// Controller/LixoController.cs
using UnityEngine;

public class LixoController : MonoBehaviour
{
    [SerializeField] private string nomeLixo = "Garrafa";
    [SerializeField] private int pontosLixo = 10;

    private LixoModel model;
    private LixoView view;

    public void Inicializar()
    {
        model = new LixoModel(nomeLixo, pontosLixo);
        view = GetComponent<LixoView>();

        // Controller escuta eventos da View
        view.OnDragEnd += HandleDragEnd;
    }

    private void HandleDragEnd(LixoView lixoView)
    {
        // Verifica se está na área de coleta
        if (EstaaNaAreaDeColeta())
        {
            model.Coletar();
            view.MostrarColetado();
            GameController.Instance.RegistrarColeta(model.pontos);
        }
        else
        {
            view.VoltarPosicaoOriginal();
        }
    }

    private bool EstaaNaAreaDeColeta()
    {
        // Checa overlap com o collider da área
        Collider2D[] hits = Physics2D.OverlapPointAll(transform.position);
        foreach (var hit in hits)
            if (hit.CompareTag("AreaColeta"))
                return true;
        return false;
    }
}