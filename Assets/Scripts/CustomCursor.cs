using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CustomCursor : MonoBehaviour
{
    public Texture2D cursorTexture; // Asigna la textura del cursor desde el Inspector
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    void Start()
    {
        // Establece la textura personalizada como cursor
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }
    void Update()
    {
        // Verifica si se hizo clic en el juego
        if (Input.GetMouseButtonDown(0)) // Puedes ajustar el botón según tus necesidades
        {
            // Restaura el cursor estándar después de hacer clic
            StartCoroutine(RestoreCursorAfterClick());
        }
    }

    IEnumerator RestoreCursorAfterClick()
    {
        // Espera un breve periodo de tiempo antes de restablecer el cursor
        yield return new WaitForSeconds(0.1f);

        // Restaura el cursor personalizado después de un breve retraso
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }
}