using UnityEngine;
using TMPro;

public class ScrollTextLoop : MonoBehaviour
{
    public RectTransform text;             // O texto que se move
    public RectTransform visibleArea;       // O painel que faz a máscara (RectMask2D)
    public float velocity = 50f;

    [SerializeField] private float textSize;
    [SerializeField] private float visibleSize;
    [SerializeField] private Vector2 initialPosition;

    void Awake()
    {
        initialPosition = text.anchoredPosition;
        textSize = text.rect.height;
        visibleSize = visibleArea.rect.height;
    }

    void Update()
    {
        text.anchoredPosition += velocity * Time.deltaTime * Vector2.up;

        // Se o texto passou totalmente, reseta para começar de novo fora da tela
        if (text.anchoredPosition.y >= textSize-visibleSize)
        {
            text.anchoredPosition = new Vector2(initialPosition.x, initialPosition.y - visibleSize);
        }
    }
}
