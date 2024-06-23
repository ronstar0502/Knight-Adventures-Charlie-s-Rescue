using UnityEngine;
using UnityEngine.UI;

public class QuitButton : MonoBehaviour
{
    private Button bt;

    private void Start()
    {
        bt = GetComponent<Button>();
        bt.onClick.AddListener(QuitGame);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
