using UnityEngine;
using UnityEngine.SceneManagement;

public class JawabanHandler3 : MonoBehaviour
{
    [SerializeField] private Dialogue dialogController;
    [SerializeField] private GameObject buttonJawaban;

    public void PilihBenar()
    {
        if (dialogController.index == 8)
        {
            dialogController.kalimat[14] = "Bos: Ternyata memang anak kecil. Silahkan keluar!";
            dialogController.index = 13;
            buttonJawaban.SetActive(false);
            dialogController.NextLine();
            GameState.onQuestion = false;
            GameState.lose = true;
        }

        else if (dialogController.index == 10)
        {
            dialogController.indexPertanyaan = 12;
            dialogController.kalimat[12] = "Bos: Pertanyaan ketiga, Orde Baru dipimpin oleh Presiden Soekarno. Benar atau salah?";
            dialogController.index = 11;
            buttonJawaban.SetActive(false);
            dialogController.NextLine();
        }
        
        else if (dialogController.index == 12)
        {
            dialogController.kalimat[14] = "Bos: Ternyata memang anak kecil. Silahkan keluar!";
            dialogController.index = 13;
            buttonJawaban.SetActive(false);
            dialogController.NextLine();
            GameState.onQuestion = false;
            GameState.lose = true;
        }
    }

    public void PilihSalah()
    {
        if (dialogController.index == 8)
        {   
            dialogController.indexPertanyaan = 10;
            dialogController.kalimat[10] = "Bos: Pertanyaan kedua, ASEAN adalah organisasi regional yang beranggotakan negara-negara di Asia Tenggara. Benar atau salah?";
            dialogController.index = 9;
            buttonJawaban.SetActive(false);
            dialogController.NextLine();
        }

        else if (dialogController.index == 10)
        {
            dialogController.kalimat[14] = "Bos: Ternyata memang anak kecil. Silahkan keluar!";
            dialogController.index = 13;
            buttonJawaban.SetActive(false);
            dialogController.NextLine();
            GameState.onQuestion = false;
            GameState.lose = true;
        }

        else if (dialogController.index == 12)
        {
            dialogController.kalimat[14] = "Bos: Hmmm menakjubkan. Kamu memang anak yang kompeten.";
            dialogController.index = 13;
            buttonJawaban.SetActive(false);
            dialogController.NextLine();
            GameState.onQuestion = false;
        }
    }
}
