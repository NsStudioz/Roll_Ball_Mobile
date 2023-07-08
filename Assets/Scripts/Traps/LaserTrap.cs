using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTrap : MonoBehaviour
{
    [Header("Laser Elements")]
    [SerializeField] private GameObject laserGO;
    [SerializeField] private bool isLaserOn = true;
    [SerializeField] private bool isPermanent;

    [Header("Timers")]
    [SerializeField] private float timeElapsed;
    [SerializeField] private float delayTime = 2f;

    [Header("Laser Effects")]
    [SerializeField] private bool isLarge;
    [SerializeField] private float effectChangeDelay = 0.25f;

    #region VectorEffects:
    [SerializeField] private Vector2 m_OldState; // 0.95, 0.9;
    [SerializeField] private Vector2 m_NewState;    // 1, 0.9;
    //
    [SerializeField] private Vector2 l_OldState; // 1.05, 1.4
    [SerializeField] private Vector2 l_NewState;  // 1.1, 1.4

    #endregion

    private void Start()
    {
        SetLaserState(); // Set laser Active/Inactive
        InitializeStates();
    }

    void Update()
    {
        if(isLaserOn)
            SetLaserEffectSize(); // if large laser, large effect. else, medium effect.

        if (isPermanent)
            return;

        CalculateLaserState(); // if the timer reaches the threshold, switch the state of bool.
        SetLaserState(); // Set laser Active/Inactive
    }

    private void InitializeStates()
    {
        m_OldState = new Vector2(0.95f, 0.9f);
        m_NewState = new Vector2(1f, 0.9f);
        //
        l_OldState = new Vector2(1.05f, 1.4f);
        l_NewState = new Vector2(1.1f, 1.4f);
    }

    private void CalculateLaserState()
    {
        timeElapsed += Time.deltaTime;

        if(timeElapsed > delayTime)
        {
            isLaserOn = !isLaserOn;
            timeElapsed = 0f;
        }
    }

    private void SetLaserState()
    {
        if (isLaserOn)
            laserGO.SetActive(true);
        else
            laserGO.SetActive(false);      
    }

    private void SetLaserEffectSize()
    {
        if (isLarge)
            StartCoroutine(LaserEffectSizeChange(l_OldState, l_NewState));
        else
            StartCoroutine(LaserEffectSizeChange(m_OldState, m_NewState));
    }

    private IEnumerator LaserEffectSizeChange(Vector2 oldState, Vector2 newState)
    {
        laserGO.transform.localScale = oldState;
        yield return new WaitForSeconds(effectChangeDelay);
        laserGO.transform.localScale = newState;
    }
}
