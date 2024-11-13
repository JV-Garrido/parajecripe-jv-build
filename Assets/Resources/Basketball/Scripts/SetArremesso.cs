using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetArremesso : MonoBehaviour
{
    public bool arremesso;
    private static SetArremesso setArremesso;
    private void Awake()
    {
        setArremesso = this;
    }
    private void OnTriggerStay(Collider other)
    {
        // Verifica se o objeto colidindo está na camada desejada (opcional)
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            arremesso = true; // Altera o valor da bool para verdadeiro
        }
    }
    private void OnTriggerExit(Collider other)
    {
        // Quando o objeto sai do trigger, você pode definir a bool de volta para falso
        arremesso = false;
    }
}
