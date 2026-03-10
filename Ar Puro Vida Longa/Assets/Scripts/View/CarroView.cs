// View/CarroView.cs
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class CarroView : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Action<CarroView> OnDragStart;
    public Action<CarroView> OnDragEnd;

    private Vector3 posicaoOriginal;
    private float distanciaZ;
    private Vector3 offset;

    public void OnBeginDrag(PointerEventData e)
    {
        posicaoOriginal = transform.position;

        distanciaZ = Camera.main.WorldToScreenPoint(transform.position).z;

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
        transform.position = worldPos + offset;
    }

    public void OnEndDrag(PointerEventData e)
    {
        OnDragEnd?.Invoke(this);
    }

    public void MostrarCatalisadorAplicado()
    {
        GetComponent<SpriteRenderer>().color = Color.green;
    }

    public void VoltarPosicaoOriginal()
    {
        transform.position = posicaoOriginal;
    }
}