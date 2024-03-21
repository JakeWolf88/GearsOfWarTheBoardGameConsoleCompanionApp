interface IMission
{
    void StartMission();
    void MissionSetup();
    void StageOneBanner();
    void StageTwoBanner();
    void StageOneEnd();
    void StageActivationPrompt();
    bool IsGameStillGoing {get; set;}
    bool IsStageOneActivated {get; set;}
    bool IsStageTwoActivated {get; set;}
}