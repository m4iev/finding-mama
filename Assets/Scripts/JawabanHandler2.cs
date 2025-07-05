using UnityEngine;
using UnityEngine.SceneManagement;

public class JawabanHandler2 : MonoBehaviour
{
    [SerializeField] private Dialogue dialogController;
    [SerializeField] private GameObject buttonJawaban;

    public void PilihBenar()
    {
        if (dialogController.index == 8)
        {
            dialogController.kalimat[12] = "PNS: Tuh kan gatau. Sana main diluar!";
            dialogController.index = 11;
            buttonJawaban.SetActive(false);
            dialogController.NextLine();
            GameState.onQuestion = false;
            GameState.lose = true;
        }

        else if (dialogController.index == 10)
        {
            dialogController.kalimat[12] = "PNS: Wah hebat. Ternyata kamu memang sudah gede.";
            dialogController.index = 11;
            buttonJawaban.SetActive(false);
            dialogController.NextLine();
            GameState.onQuestion = false;
        }
        
    }

    public void PilihSalah()
    {
        if (dialogController.index == 8)
        {   
            dialogController.indexPertanyaan = 10;
            dialogController.kalimat[10] = "PNS: Pertanyaan kedua, Konferensi Asia Afrika (KAA) diadakan di Bandung. Benar atau salah?";
            dialogController.index = 9;
            buttonJawaban.SetActive(false);
            dialogController.NextLine();
        }

        else if (dialogController.index == 10)
        {
            dialogController.kalimat[12] = "PNS: Tuh kan gatau. Sana main diluar!";
            dialogController.index = 11;
            buttonJawaban.SetActive(false);
            dialogController.NextLine();
            GameState.onQuestion = false;
            GameState.lose = true;
        }
    }
}
