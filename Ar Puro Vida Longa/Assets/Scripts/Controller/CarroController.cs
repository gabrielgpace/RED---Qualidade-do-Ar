// Controller/CarroController.cs
using UnityEngine;

public class CarroController : MonoBehaviour
{
    [SerializeField] private string nomeCarro = "Carro Velho";
    [SerializeField] private int pontosCarro = 20;

    private CarroModel model;
    private CarroView view;

    public void Inicializar()
    {
        model = new CarroModel(nomeCarro, pontosCarro);
        view = GetComponent<CarroView>();

        view.OnDragEnd += HandleDragEnd;
    }

    private void HandleDragEnd(CarroView carroView)
    {
        if (EstaaNaAreaDeColeta())
        {
            model.AplicarCatalisador();
            view.MostrarCatalisadorAplicado();
            GameController.Instance.RegistrarColeta(model.pontos);
        }
        else
        {
            view.VoltarPosicaoOriginal();
        }
    }

    private bool EstaaNaAreaDeColeta()
    {
        Collider2D[] hits = Physics2D.OverlapPointAll(transform.position);
        foreach (var hit in hits)
            if (hit.CompareTag("AreaColeta"))
                return true;
        return false;
    }
}