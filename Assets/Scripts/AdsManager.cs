using UnityEngine.Advertisements;
using UnityEngine;

public class AdsManager : MonoBehaviour
{
    public void ShowRewardedAd()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            var showOptions = new ShowOptions
            {
                resultCallback = HandleShowResult
            };
            Advertisement.Show("rewardedVideo", showOptions);
        }
    }

    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                
                break;
            case ShowResult.Skipped:
                Debug.Log("Skipped, no reward!");
                break;
            case ShowResult.Failed:
                Debug.Log("Failed, try again!");
                break;
        }
    }
}
