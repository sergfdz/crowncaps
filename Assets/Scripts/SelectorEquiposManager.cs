using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectorEquiposManager : MonoBehaviour
{
    public void SeleccionarAmarilloJugador1()
{
    ColorUtility.TryParseHtmlString("#FFCC00", out ConfigEquipos.colorJugador1); 
}

public void SeleccionarRojoJugador1()
{
    ColorUtility.TryParseHtmlString("#E74C3C", out ConfigEquipos.colorJugador1);
}

public void SeleccionarAzulJugador1()
{
    ColorUtility.TryParseHtmlString("#3498DB", out ConfigEquipos.colorJugador1); 
}

public void SeleccionarVerdeJugador1()
{
    ColorUtility.TryParseHtmlString("#2ECC71", out ConfigEquipos.colorJugador1); 
}

    public void SeleccionarAmarilloJugador2()
{
    ColorUtility.TryParseHtmlString("#B0AB00", out ConfigEquipos.colorJugador2);
}

public void SeleccionarRojoJugador2()
{
    ColorUtility.TryParseHtmlString("#B90403", out ConfigEquipos.colorJugador2);
}

public void SeleccionarAzulJugador2()
{
    ColorUtility.TryParseHtmlString("#0319B9", out ConfigEquipos.colorJugador2);
}

public void SeleccionarVerdeJugador2()
{
    ColorUtility.TryParseHtmlString("#009F0D", out ConfigEquipos.colorJugador2);
}

public void SeleccionarCampoNegro()
{
    ColorUtility.TryParseHtmlString("#8C8C8C", out ConfigEquipos.colorCampo);
}

public void SeleccionarCampoBlanco()
{
    ColorUtility.TryParseHtmlString("#FFFFFF", out ConfigEquipos.colorCampo);
}

public void SeleccionarCampoVerde()
{
    ColorUtility.TryParseHtmlString("#AFFFC7", out ConfigEquipos.colorCampo);
}

    public void ComenzarPartido() => SceneManager.LoadScene("CampoChapas");
}
