using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;



public class PlayFabManager : MonoBehaviour
{
    [Header("UI")]
    public Text messageText;
    public InputField emailInput;
    public InputField passwordInput;

    public void RegisterButton()
    {
        if (passwordInput.text.Length <6)
        {
            messageText.text = "Password too short!";
            return;
        }
        var request = new RegisterPlayFabUserRequest
        {
            Email = emailInput.text,
            Password = passwordInput.text,
            RequireBothUsernameAndEmail = false
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnError);
    }
    void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        messageText.text = "Registered and logged in!";
    }

    public void LoginButton()
    {
        var request = new LoginWithEmailAddressRequest
        {
            Email = emailInput.text,
            Password = passwordInput.text,
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnError);
    }
    public void RestetPasswordButton()
    {
        var request = new SendAccountRecoveryEmailRequest
        {
            Email = emailInput.text,
            TitleId = "412A3"
        };
        PlayFabClientAPI.SendAccountRecoveryEmail(request, OnPasswordReset, OnError);
    }
    void OnPasswordReset(SendAccountRecoveryEmailResult result)
    {
        messageText.text = "Password reset mail send";
    }






    // Start is called before the first frame update
    void Start()
    {
        Login();
    }

    // Update is called once per frame
    void Login()
    {
        var request = new LoginWithCustomIDRequest
        {
           CustomId = SystemInfo.deviceUniqueIdentifier,
           CreateAccount = true
         //  InfoRequestParameters = new GetPlayerCombinedInfoRequestParams
          // {
          //     GetPlayerProfile = true
         //  }
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnError);
    }
    void OnLoginSuccess(LoginResult result)
    {
        messageText.text = "Logged in";
        Debug.Log("login/creazione account avvenuta con successo!");
       // string name = null;
        //if(result.InfoResultPayload.PlayerProfile !=null)
         //   name = result.InfoResultPayload.PlayerProfile.DisplayName;
    }
    void OnError(PlayFabError error)
    {
        Debug.Log("errore login/creazione account avvenuta con successo!");
       // Debug.Log(error.GenerateErrorReport());
        messageText.text = error.ErrorMessage;
    }


   // public void SendLeaderboard(int score)
   // {
    //    var request = new UpdatePlayerStatisticsRequest
    //    {
    //        Statistics = new List<StatisticUpdate>
   //         {
   //             new StatisticUpdate
   //             {
   //                 StatisticName = "PlatformScore",
   //                 Value = score
   //             }
   //         }
   //     };
  //      PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboradUpdate, OnError);
 //   }
  //  void OnLeaderboradUpdate(UpdatePlayerStatisticsResult resutl)
  //  {
  //      Debug.Log("Successfull Leaderboard sent");
  //  }
}
