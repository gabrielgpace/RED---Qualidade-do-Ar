// View/LixoView.cs
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class LixoView : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Action<LixoView> OnDragStart;
    public Action<LixoView> OnDragEnd;

    private Vector3 posicaoOriginal;
    private float distanciaZ; // ← distância da câmera ao objeto
    private Vector3 offset;   // ← diferença entre centro do objeto e onde clicou

    public void OnBeginDrag(PointerEventData e)
    {
        posicaoOriginal = transform.position;

        // Calcula a distância Z da câmera até o objeto
        distanciaZ = Camera.main.WorldToScreenPoint(transform.position).z;

        // Calcula o offset para não "pular" para o centro
        Vector3 worldClick = Camera.main.ScreenToWorldPoint(
            new Vector3(e.position.x, e.position.y, distanciaZ)
        );
        offset = transform.position - worldClick;

        OnDragStart?.Invoke(this);
    }

    public void OnDrag(PointerEventData e)
    {
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(
            new Vector3(e.position.x, e.position.y, distanciaZ)
        );
        transform.position = worldPos + offset; // ← aplica o offset
    }

    public void OnEndDrag(PointerEventData e)
    {
        OnDragEnd?.Invoke(this);
    }

    public void MostrarColetado()
    {
        gameObject.SetActive(false);
    }

    public void VoltarPosicaoOriginal()
    {
        transform.position = posicaoOriginal;
    }
}