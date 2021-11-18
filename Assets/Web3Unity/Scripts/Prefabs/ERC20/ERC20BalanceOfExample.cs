using System.Collections;
using System.Numerics;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ERC20BalanceOfExample : MonoBehaviour
{
    public string account;
    public string name;
    public string symbol;
    public BigInteger decimals;
    public BigInteger totalSupply;
    public BigInteger balanceOf;
    public Text _account;
    public Text _BalanceOf;
    public Text _name;
    public Text _symbol;
    public Text _decimals;
    public Text _totalSupply;
    async void Start()
    {
        string chain = "ethereum";
        string network = "mainnet";
        string contract = "0x495f947276749Ce646f68AC8c248420045cb7b5e";
        account = PlayerPrefs.GetString("Account") ;
        string tokenId = "37580235481215513343516874302373710391974179783829306714739909051369171976193";

        balanceOf = await ERC20.BalanceOf(chain, network, contract, account);
        name = await ERC20.Name(chain, network, contract);
        symbol = await ERC20.Symbol(chain, network, contract);
        decimals = await ERC20.Decimals(chain, network, contract);
        totalSupply = await ERC20.TotalSupply(chain, network, contract);
        //print(balanceOf);
        _account.text = account.ToString();
        _BalanceOf.text = balanceOf.ToString(); 
        _name.text = name.ToString(); 
        _symbol.text = symbol.ToString(); 
        _decimals.text = decimals.ToString(); 
        _totalSupply.text = totalSupply.ToString(); 
    }

    public void onClickDD()
    {
        _account.text = account.ToString();
        _BalanceOf.text = balanceOf.ToString(); 
        _name.text = name.ToString(); 
        _symbol.text = symbol.ToString(); 
        _decimals.text = decimals.ToString(); 
        _totalSupply.text = totalSupply.ToString();
    }
}
