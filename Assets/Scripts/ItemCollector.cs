using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int apples = 0; // contador das macas
    [SerializeField] private AudioSource CollectItem;

    [SerializeField] private Text applesText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Apple"))
        {
            CollectItem.Play();
            Destroy(collision.gameObject);
            apples++; // toda vez que encostar em uma maca, vai guardar o valor +1
            applesText.text = "Apples Collected: " + apples; // mudar o texto do canvas para o valor guardado em "apples"
        }
    }
}
