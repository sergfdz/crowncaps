using UnityEngine;
using UnityEngine.SceneManagement;

public class Instrucciones : MonoBehaviour
{
    public void VolverMenu() => SceneManager.LoadScene("MenuPrincipal");
}
