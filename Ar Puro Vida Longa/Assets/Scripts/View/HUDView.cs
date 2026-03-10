// View/HUDView.cs
using UnityEngine;
using TMPro;

public class HUDView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textContador; // "0/9"
    [SerializeField] private TextMeshProUGUI textPontos;

    public void AtualizarContador(int coletados, int total)
    {
        textContador.text = $"{coletados}/{total}";
    }

    public void AtualizarPontos(int pontos)
    {
        textPontos.text = $"Pontos: {pontos}";
    }
}