using UnityEngine;

public class SelectorVisual : MonoBehaviour
{
    public GameObject[] marcosJugador1;
    public GameObject[] marcosJugador2;
    public GameObject[] marcosCampo;

    // Estos métodos se llaman desde cada botón OnClick()
    public void ActivarMarcoJugador1(int index)
    {
        for (int i = 0; i < marcosJugador1.Length; i++)
        {
            marcosJugador1[i].SetActive(i == index);
        }
    }

    public void ActivarMarcoJugador2(int index)
    {
        for (int i = 0; i < marcosJugador2.Length; i++)
        {
            marcosJugador2[i].SetActive(i == index);
        }
    }

    public void ActivarMarcoCampo(int index)
    {
        for (int i = 0; i < marcosCampo.Length; i++)
        {
            marcosCampo[i].SetActive(i == index);
        }
    }
}
