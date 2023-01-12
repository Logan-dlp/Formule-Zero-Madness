using UnityEngine;

public class SecureCheckpoint : MonoBehaviour
{
    #region Settings
    [Header("Checkpoint in race")]
    [SerializeField] GameObject ligneArrivee;
    [SerializeField] GameObject checkpoint1;
    [SerializeField] GameObject checkpoint2;
    [SerializeField] GameObject checkpoint3;

    [HideInInspector] public int NumberOfCheckpoint;
    #endregion
    #region Meths
    void System()
    {
        if (NumberOfCheckpoint == 0) LigneDeDepart();
        if (NumberOfCheckpoint == 1) Checkpoint1();
        if (NumberOfCheckpoint == 2) Checkpoint2();
        if (NumberOfCheckpoint == 3) Checkpoint3();
    }
    void LigneDeDepart()
    {
        ligneArrivee.SetActive(true);
        checkpoint1.SetActive(false);
        checkpoint2.SetActive(false);
        checkpoint3.SetActive(false);
    }
    void Checkpoint1()
    {
        ligneArrivee.SetActive(false);
        checkpoint1.SetActive(true);
        checkpoint2.SetActive(false);
        checkpoint3.SetActive(false);
    }
    void Checkpoint2()
    {
        ligneArrivee.SetActive(false);
        checkpoint1.SetActive(false);
        checkpoint2.SetActive(true);
        checkpoint3.SetActive(false);
    }
    void Checkpoint3()
    {
        ligneArrivee.SetActive(false);
        checkpoint1.SetActive(false);
        checkpoint2.SetActive(false);
        checkpoint3.SetActive(true);
        NumberOfCheckpoint = 0;
    }
    #endregion
    #region Meths Unity
    private void Start()
    {
        NumberOfCheckpoint = 0;
    }
    private void FixedUpdate()
    {
        System();
    }
    #endregion
}
