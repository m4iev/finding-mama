using UnityEngine;
using UnityEngine.SceneManagement;

public class JawabanHandler1 : MonoBehaviour
{
    [SerializeField] private Dialogue dialogController;
    [SerializeField] private GameObject buttonJawaban;

    public void PilihBenar()
    {
        dialogController.kalimat[9] = "Satpam: Wah bener.. Ternyata kamu emang udah gede. Silahkan masuk mbak...";
        dialogController.index++;
        buttonJawaban.SetActive(false);
        dialogController.NextLine();
        GameState.onQuestion = false;
    }

    public void PilihSalah()
    {
        dialogController.kalimat[9] = "Satpam: Tuh kan salah... berarti adek masih kecil... Sana main diluar aja dek.";
        dialogController.index++;
        buttonJawaban.SetActive(false);
        dialogController.NextLine();
        GameState.onQuestion = false;
        GameState.lose = true;
    }
}
