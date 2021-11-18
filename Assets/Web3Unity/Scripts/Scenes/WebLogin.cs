using System;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

#if UNITY_WEBGL
public class WebLogin : MonoBehaviour
{
    public string  ContractAdress;
    public string  TokenId;
    public GameObject LogPanel;
    public GameObject VerifyPanel;
    public InputField ContractAdressInput;
    public InputField TokenIdInput;

    [DllImport("__Internal")]
    private static extern void Web3Connect();

    [DllImport("__Internal")]
    private static extern string ConnectAccount();

    [DllImport("__Internal")]
    private static extern void SetConnectAccount(string value);

    private int expirationTime;
    private string account; 

    public void OnLogin()
    {
        LogPanel.SetActive(false);
        VerifyPanel.SetActive(true);
    }

    public void OnVerify()
    {
        ContractAdress = ContractAdressInput.text.ToString();
        TokenId = TokenIdInput.text.ToString();
        Web3Connect();
        OnConnected();
    }

    public void OnBack()
    {
        LogPanel.SetActive(true);
        VerifyPanel.SetActive(false);
    }

    async private void OnConnected()
    {
        account = ConnectAccount();
        while (account == "") {
            await new WaitForSeconds(1f);
            account = ConnectAccount();
        };
        // save account for next scene
        PlayerPrefs.SetString("Account", account);
        PlayerPrefs.SetString("ContractAdress", ContractAdress);
        PlayerPrefs.SetString("TokenId", TokenId);
        // reset login message
        SetConnectAccount("");
        // load next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OnSkip()
    {
        // burner account for skipped sign in screen
        PlayerPrefs.SetString("Account", "You are not connected!");
        PlayerPrefs.SetString("ContractAdress", "##");
        PlayerPrefs.SetString("TokenId", "##");
        // move to next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
#endif
