using UnityEngine;
using UnityEngine.UI;

public class Escala : MonoBehaviour
{
    public float scale = 1.0f;

    void Start()
    {
        Canvas canvas = GetComponent<Canvas>();
        if (canvas != null)
        {
            RectTransform canvasRect = canvas.GetComponent<RectTransform>();
            canvasRect.localScale = new Vector3(scale, scale, scale);
        }
    }
}