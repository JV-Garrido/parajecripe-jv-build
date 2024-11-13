using UnityEngine;
using UnityEngine.UI;

public class ButtonInputReplicator : MonoBehaviour
{
    public KeyCode targetKey = KeyCode.RightArrow;

    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        Debug.Log("Button Clicked");
        // Coloque aqui o código que deseja executar quando o botão for clicado.
    }

    void Update()
    {
        if (Input.GetKeyDown(targetKey))
        {
            OnButtonClick();
        }
    }
}
