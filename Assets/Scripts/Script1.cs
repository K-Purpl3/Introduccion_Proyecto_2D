using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Script1 : MonoBehaviour
{
    private SpriteRenderer blockRenderer; // Referencia al SpriteRenderer
    private Color originalColor;          // Para guardar el color original

    void Start()
    {
        // Obtener el SpriteRenderer y guardar el color original
        blockRenderer = GetComponent<SpriteRenderer>();
        if (blockRenderer != null)
        {
            originalColor = blockRenderer.color;
        }
        else
        {
            Debug.LogError("No se encontró un SpriteRenderer en este objeto.");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Verificar si el objeto que colisiona es uno de los bloques
        if (collision.gameObject.name.StartsWith("bloque"))
        {
            Debug.Log($"Colisión detectada con {collision.gameObject.name}.");

            // Cambiar el color del bloque a amarillo
            SpriteRenderer collidedRenderer = collision.gameObject.GetComponent<SpriteRenderer>();
            if (collidedRenderer != null)
            {
                Color blockOriginalColor = collidedRenderer.color; // Guardar el color original
                collidedRenderer.color = Color.yellow;
                StartCoroutine(ChangeColorBack(collidedRenderer, blockOriginalColor));
            }
            else
            {
                Debug.LogError($"El objeto {collision.gameObject.name} no tiene un SpriteRenderer.");
            }
        }
    }

    IEnumerator ChangeColorBack(SpriteRenderer collidedRenderer, Color blockOriginalColor)
    {
        // Esperar 0.5 segundos
        yield return new WaitForSeconds(0.5f);

        // Restaurar el color original del bloque
        if (collidedRenderer != null)
        {
            collidedRenderer.color = blockOriginalColor;
            Debug.Log($"Color original restaurado en {collidedRenderer.gameObject.name}.");
        }
    }
}
