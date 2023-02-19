using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;


public class DialogueBuilder : MonoBehaviour
{
    [SerializeField] private DialogueStrings _dialogueStrings;
    [SerializeField] private DialogueYesNo _dialogueYesNo;
    [SerializeField] private DialogueOk _dialogueOk;
    [SerializeField] private Gold _gold;
    [SerializeField] private Employees _employees;
    [SerializeField] private DaysUntilChristmas _daysUntilChristmas;
    [SerializeField] private Background _background;
    [SerializeField] private LeftInfoView _leftInfoView;
    // [SerializeField] private AudioManager _audioManager;
    [SerializeField] private Music _music;


    
    private enum DialogueName
    {
        WarmClothesForEmployees,
        EmployeesNeutralization,
        BrokenPresents,
        Productivity,
        Covid
    };

    private TouchControls _touchControls;

    private void Awake()
    {
        _touchControls = new TouchControls();
    }

    private void OnEnable() 
    {
        _touchControls.Enable();
    }

    private void OnDisable()
    {
        _touchControls.Disable();
    }

    private void Start()
    {
        _touchControls.Touch.TouchPress.started += ctx => OnStartTouch(ctx);
        _touchControls.Touch.TouchPress.canceled += ctx => OnEndTouch(ctx);
    }



    private void OnStartTouch(InputAction.CallbackContext ctx)
    {
        if (_gold.IsEffectValueChangerInProgress())
        {
            _gold.SkipEffectValueChanger();    
        }

        if (_employees.IsEffectValueChangerInProgress())
        {
            _employees.SkipEffectValueChanger();
        }

        if (_dialogueYesNo.IsTextTypingInProgress())
        {
            _dialogueYesNo.SkipTypingText();
        }

        if (_leftInfoView.IsEffectOfPanelInProgress())
        {
            _leftInfoView.SkipPanelEffect();
        }
    }

    private void OnEndTouch(InputAction.CallbackContext ctx)
    {

    }



    public void CreateAppealsToSanta()
    {
        _background.ShowBackgroundByName("SantaWithFlowers");

        _dialogueYesNo.AddDialogue(
            DialogueName.WarmClothesForEmployees.ToString(),
            _dialogueStrings.GetString(DialogueStrings.Key.workersarecold),
            () =>
            {
                _gold.DecreaseGold(
                    decreaserValue: 400,
                    onEnd: () => {
                        _employees.AddHappinessValueAsync
                        (
                            additionalHappinessValue: 2, 
                            onEnd: () => {
                                GoToNextDay();
                            }
                        );
                    }
                );

            },
            () =>
            {
                _employees.DecreaseHappinessValueAsync(2);
                GoToNextDay();
            },
            () =>
            {
                _background.ShowBackgroundByName("Gnomes");
            });
        _dialogueYesNo.AddDialogue(
            DialogueName.EmployeesNeutralization.ToString(),
            _dialogueStrings.GetString(DialogueStrings.Key.paymentсomplaint),
            () =>
            {
                _background.ShowBackgroundByName("SantaWithGun");
                _employees.DecreaseHappinessValueAsync(10);
                _employees.AddCountOfEmployees((_employees.GetCountEmployees() / 2) * -1);
                _dialogueOk.ShowDialogue(
                    "",
                    _dialogueStrings.GetString(DialogueStrings.Key.killedemployeesresult),
                    () => { 
                        GoToNextDay(); 
                    }
                );
            },
            () =>
            {
                _employees.AddHappinessValueAsync
                (
                    additionalHappinessValue: 5, 
                    onEnd: () => {
                        GoToNextDay();
                    }
                );
            },
            () =>
            {
                _background.ShowBackgroundByName("SantaWithGun2");
            });
        _dialogueYesNo.AddDialogue(
            DialogueName.BrokenPresents.ToString(),
            _dialogueStrings.GetString(DialogueStrings.Key.brokenpresents),
            () =>
            {
                _gold.AddGold(300);
                _employees.DecreaseHappinessValueAsync
                (
                    decreaserValue: 2, 
                    onEnd: () => {
                        GoToNextDay();
                    }
                );
            },
            () =>
            {
                _employees.AddHappinessValueAsync(
                    additionalHappinessValue: 5, 
                    onEnd: () => {
                        GoToNextDay();
                    }
                );
            },
            () =>
            {
                _background.ShowBackgroundByName("FallingPresents");
            });
        _dialogueYesNo.AddDialogue(
            DialogueName.Productivity.ToString(),
            _dialogueStrings.GetString(DialogueStrings.Key.productiveday),
            () =>
            {

                _dialogueOk.ShowDialogue(
                    "",
                    _dialogueStrings.GetString(DialogueStrings.Key.happyemployeesresult),
                    () =>
                    {
                        _employees.AddHappinessValueAsync(
                            additionalHappinessValue: 3, 
                            onEnd: () => {
                                GoToNextDay();
                            }
                        );
                    }
                );
            },
            () =>
            {
                _employees.DecreaseHappinessValueAsync(1);
                GoToNextDay();
            },
            () =>
            {
                _background.ShowBackgroundByName("Presents");
            });

        _dialogueYesNo.AddDialogue(
            DialogueName.Covid.ToString(), 
            _dialogueStrings.GetString(DialogueStrings.Key.covid),
            () =>
            {
                _employees.AddHappinessValueAsync
                (
                    additionalHappinessValue: 3, 
                    onEnd: () => {
                        GoToNextDay();
                    }
                );
            },
            () =>
            {
                _background.ShowBackgroundByName("SantaDevil");

                _dialogueOk.ShowDialogue(
                    "", 
                    _dialogueStrings.GetString(DialogueStrings.Key.pandemic),
                    () =>
                    {
                        _employees.DecreaseHappinessValueAsync(
                            decreaserValue: 3, 
                            onEnd: () => {
                                GoToNextDay();
                            }
                        );
                    }
                );
            },
            () =>
            {
                _background.ShowBackgroundByName("Gnomes");
            });
    
        _dialogueYesNo.AddDialogue(
            "", 
            _dialogueStrings.GetString(DialogueStrings.Key.magicelixir),
            () =>
            {
                _dialogueOk.ShowDialogue(
                    "", 
                    _dialogueStrings.GetString(DialogueStrings.Key.magicelixirresult),
                    () =>
                    {
                        _employees.DecreaseHappinessValueAsync(
                            decreaserValue: 3, 
                            onEnd: () => {
                                GoToNextDay();
                            }
                        );
                    }
                );
            },
            () =>
            {
                _employees.DecreaseHappinessValueAsync(
                    decreaserValue: 1, 
                    onEnd: () => {
                        GoToNextDay();
                    }
                );
            },
            () =>
            {
                _background.ShowBackgroundByName("Hallucination1");
            }
        );
    
        _dialogueYesNo.AddDialogue(
            "", 
            _dialogueStrings.GetString(DialogueStrings.Key.injuretment),
            () =>
            {
                _gold.DecreaseGold(100);
                _employees.AddHappinessValueAsync
                (
                    additionalHappinessValue: 3, 
                    onEnd: () => {
                        GoToNextDay();
                    }
                );
            },
            () =>
            {
                _employees.AddHappinessValueAsync(
                    additionalHappinessValue: 1, 
                    onEnd: () => {
                        GoToNextDay();
                    }
                );
            },
            () =>
            {
                _background.ShowBackgroundByName("FallingPresents");
            }
        );
    
        _dialogueYesNo.AddDialogue(
            "", 
            _dialogueStrings.GetString(DialogueStrings.Key.goodsdamage),
            () =>
            {
                _employees.AddCountOfEmployees(-1);
                _gold.DecreaseGold(250);
                _employees.DecreaseHappinessValueAsync(
                    decreaserValue: 1, 
                    onEnd: () => {
                        GoToNextDay();
                    }
                );
            },
            () =>
            {
                _gold.DecreaseGold(250);
                _employees.AddHappinessValueAsync(
                    additionalHappinessValue: 3, 
                    onEnd: () => {
                        GoToNextDay();
                    }
                );
            },
            () =>
            {
                _background.ShowBackgroundByName("FallingPresents");
            }
        );
        
        _dialogueYesNo.AddDialogue(
            "", 
            _dialogueStrings.GetString(DialogueStrings.Key.sniffing),
            () =>
            {
                
                _employees.AddCountOfEmployees(-1);
                _employees.AddHappinessValueAsync(
                    additionalHappinessValue: 2, 
                    onEnd: () => {
                        GoToNextDay();
                    }
                );
            },
            () =>
            {
                _employees.DecreaseHappinessValueAsync(
                    decreaserValue: 3, 
                    onEnd: () => {
                        GoToNextDay();
                    }
                );
            },
            () =>
            {
                _background.ShowBackgroundByName("Hallucination1");
            }
        );
        
        _dialogueYesNo.AddDialogue(
            "", 
            _dialogueStrings.GetString(DialogueStrings.Key.toxicsubstances),
            () =>
            {
                _gold.DecreaseGold(1000);
                
                _daysUntilChristmas.Decrease(2);
                
                _dialogueOk.ShowDialogue(
                    "", 
                    _dialogueStrings.GetString(DialogueStrings.Key.happyemployeesoncomebackresult),
                    () =>
                    {
                        _employees.AddHappinessValueAsync
                        (
                            additionalHappinessValue: 3, 
                            onEnd: () => {
                                GoToNextDay();
                            }
                        );
                    }
                );
            },
            () =>
            {
                _employees.AddCountOfEmployees(-3);
                
                _dialogueOk.ShowDialogue(
                    "", 
                    _dialogueStrings.GetString(DialogueStrings.Key.workintoxicresult),
                    () =>
                    {
                        _employees.DecreaseHappinessValueAsync
                        (
                            decreaserValue: 3, 
                            onEnd: () => {
                                GoToNextDay();
                            }
                        );
                    }
                );
            },
            () =>
            {
                _background.ShowBackgroundByName("Hallucination1");
            }
        );
        
        _dialogueYesNo.AddDialogue(
            "", 
            _dialogueStrings.GetString(DialogueStrings.Key.tiredemployees),
            () =>
            {
                _daysUntilChristmas.Decrease();
                
                _dialogueOk.ShowDialogue(
                    "", 
                    _dialogueStrings.GetString(DialogueStrings.Key.happyemployeesoncomebackresult),
                    () =>
                    {
                        _employees.DecreaseHappinessValueAsync(
                            decreaserValue: 3, 
                            onEnd: () => {
                                GoToNextDay();
                            }
                        );
                    }
                );
            },
            () =>
            {
                _employees.AddCountOfEmployees(-3);
                
                _dialogueOk.ShowDialogue(
                    "", 
                    _dialogueStrings.GetString(DialogueStrings.Key.difficultconditionsresult),
                    () =>
                    {
                        _employees.DecreaseHappinessValueAsync(
                            decreaserValue: 5, 
                            onEnd: () => {
                                GoToNextDay();
                            }
                        );
                    }
                );
            },
            () =>
            {
                _background.ShowBackgroundByName("Gnomes");
            }
        ); 
        
        _dialogueYesNo.AddDialogue(
            "", 
            _dialogueStrings.GetString(DialogueStrings.Key.ditructedemployees),
            () =>
            {
                _employees.AddCountOfEmployees(-5);
                
                _dialogueOk.ShowDialogue(
                    "", 
                    _dialogueStrings.GetString(DialogueStrings.Key.frustratedemployeesresult),
                    () =>
                    {
                        _employees.DecreaseHappinessValueAsync(
                            decreaserValue: 5, 
                            onEnd: () => {
                                GoToNextDay();
                            }
                        );
                    }
                );
            },
            () =>
            {
                _employees.AddHappinessValueAsync(3);
                _daysUntilChristmas.Decrease();
                
                _dialogueOk.ShowDialogue(
                    "", 
                    _dialogueStrings.GetString(DialogueStrings.Key.happyemployeesoncomebackresult),
                    () =>
                    {
                        GoToNextDay();
                    }
                );
            },
            () =>
            {
                _background.ShowBackgroundByName("Gnomes");
            }
        );

        _dialogueYesNo.AddDialogue(
            "", 
            _dialogueStrings.GetString(DialogueStrings.Key.wagesComplaints),
            () =>
            {
                _employees.AddCountGoldToPayForOneEmployee(additionalGold: 20);
                _employees.AddHappinessValueAsync(
                    additionalHappinessValue: 3, 
                    onEnd: () => 
                    {
                        GoToNextDay();
                    }
                );
            },
            () =>
            {
                _employees.DecreaseHappinessValueAsync(
                    decreaserValue: 1,
                    onEnd: () => 
                    {
                        GoToNextDay();
                    }
                );
            },
            () =>
            {
                _background.ShowBackgroundByName("Gnomes");
            }
        );

        _dialogueYesNo.AddDialogue(
            "", 
            _dialogueStrings.GetString(DialogueStrings.Key.saleWorkers),
            () =>
            {
                _gold.AddGold(5000);
                _employees.AddCountOfEmployees(additionalCountEmployees: -3);
                _employees.DecreaseHappinessValueAsync(
                    decreaserValue: 5, 
                    onEnd: () => 
                    {
                        GoToNextDay();
                    }
                );
            },
            () =>
            {
                _employees.AddHappinessValueAsync(
                    additionalHappinessValue: 3,
                    onEnd: () => 
                    {
                        GoToNextDay();
                    }
                );
            },
            () =>
            {
                _background.ShowBackgroundByName("SantaDevilWithDogs");
            }
        );

        _dialogueYesNo.AddDialogue(
            "", 
            _dialogueStrings.GetString(DialogueStrings.Key.gunForAnimalOrder),
            () =>
            {
                _gold.AddGold(2000);
                _employees.AddCountOfEmployees(additionalCountEmployees: -2);
                _employees.DecreaseHappinessValueAsync(
                    decreaserValue: 2, 
                    onEnd: () => 
                    {
                        GoToNextDay();
                    }
                );
            },
            () =>
            {
                _employees.AddHappinessValueAsync(
                    additionalHappinessValue: 2,
                    onEnd: () => 
                    {
                        GoToNextDay();
                    }
                );
            },
            () =>
            {
                _background.ShowBackgroundByName("SantaDevilWithDogs");
            }
        );

        _dialogueYesNo.AddDialogue(
            "", 
            _dialogueStrings.GetString(DialogueStrings.Key.fireResistance),
            () =>
            {
                _gold.DecreaseGold(1000);
                _employees.AddHappinessValueAsync(
                    additionalHappinessValue: 2, 
                    onEnd: () => 
                    {
                        GoToNextDay();
                    }
                );
            },
            () =>
            {
                _employees.DecreaseHappinessValueAsync(
                    decreaserValue: 2,
                    onEnd: () => 
                    {
                        GoToNextDay();
                    }
                );
            },
            () =>
            {
                _background.ShowBackgroundByName("Gnomes");
            }
        );
        
        _dialogueYesNo.AddDialogue(
            "", 
            _dialogueStrings.GetString(DialogueStrings.Key.foodForMagicalDeer),
            () =>
            {
                _gold.DecreaseGold(200);
                _employees.AddHappinessValueAsync(
                    additionalHappinessValue: 3, 
                    onEnd: () => 
                    {
                        GoToNextDay();
                    }
                );
            },
            () =>
            {
                _employees.DecreaseHappinessValueAsync
                (
                    decreaserValue: 2,
                    onEnd: () => 
                    {
                        GoToNextDay();
                    }
                );
            },
            () =>
            {
                _background.ShowBackgroundByName("Gnomes");
            }
        );

        _dialogueYesNo.AddDialogue(
            "", 
            _dialogueStrings.GetString(DialogueStrings.Key.giftTheft),
            () =>
            {
                _employees.AddCountOfEmployees(-1);
                _employees.AddHappinessValueAsync(
                    additionalHappinessValue: 3, 
                    onEnd: () => 
                    {
                        GoToNextDay();
                    }
                );
            },
            () =>
            {
                _employees.DecreaseHappinessValueAsync(
                    decreaserValue: 2,
                    onEnd: () => 
                    {
                        GoToNextDay();
                    }
                );
            },
            () =>
            {
                _background.ShowBackgroundByName("Gnomes");
            }
        );

        _dialogueYesNo.AddDialogue(
            "", 
            _dialogueStrings.GetString(DialogueStrings.Key.sabotage),
            () =>
            {
                _employees.AddCountOfEmployees(-1);
                _employees.AddHappinessValueAsync(
                    additionalHappinessValue: 3, 
                    onEnd: () => 
                    {
                        GoToNextDay();
                    }
                );
            },
            () =>
            {
                _employees.DecreaseHappinessValueAsync(
                    decreaserValue: 3,
                    onEnd: () => 
                    {
                        GoToNextDay();
                    }
                );
            },
            () =>
            {
                _background.ShowBackgroundByName("Gnomes");
            }
        );

        _dialogueYesNo.AddDialogue(
            "", 
            _dialogueStrings.GetString(DialogueStrings.Key.hardmachines),
            () =>
            {
                _gold.DecreaseGold(4000);
                _employees.AddHappinessValueAsync(
                    additionalHappinessValue: 3,
                    onEnd: () => 
                    {
                        GoToNextDay();
                    }
                );
            },
            () =>
            {
                _employees.DecreaseHappinessValueAsync
                (
                    decreaserValue: 1,
                    onEnd: () => 
                    {
                        GoToNextDay();
                    }
                );
            },
            () =>
            {
                _background.ShowBackgroundByName("Gnomes");
            }
        );
        
        
        _dialogueYesNo.ShuffleDialogues();
        _dialogueYesNo.ShowNextDialogue();
    }
    
    

    private void GoToNextDay()
    {
        int daysUntilChristmas = _daysUntilChristmas.Decrease();


        if (daysUntilChristmas > 0)
        {
            if (_employees.GetCountEmployees() > 0 && _gold.GetCountGold() > 0)
            {
                PayEmployees();
            }
            else if (_employees.GetCountEmployees() <= 0)
            {
                string finalContent = _dialogueStrings.GetString(DialogueStrings.Key.nightmarechristmasfinal);

                ShowFinalDialogue(finalContent);
                _background.ShowBackgroundByName("RudeRedSanta");
                _music.PlayBadResultMusic();
            }
            else if (_gold.GetCountGold() <= 0)
            {
                print("no gold");
                string finalContent = _dialogueStrings.GetString(DialogueStrings.Key.nogoldfinal);
                finalContent += _dialogueStrings.GetString(DialogueStrings.Key.sadchristmasfinal);

                ShowFinalDialogue(finalContent);

                _background.ShowBackgroundByName("RudeRedSanta");
                _music.PlayBadResultMusic();
            }
            else if (_gold.GetCountGold() > 0)
            {
                if (_employees.GetHappinessValue() <= -5) {
                    _employees.AddCountOfEmployees(-1);
                }
                else if (_employees.GetCountEmployees() <= 0)
                {
                    string finalContent = _dialogueStrings.GetString(DialogueStrings.Key.noemployeesfinal);
                    finalContent += _dialogueStrings.GetString(DialogueStrings.Key.nightmarechristmasfinal);

                    ShowFinalDialogue(finalContent);

                    _background.ShowBackgroundByName("RudeRedSanta");
                    _music.PlayBadResultMusic();
                }
            }
        }
        else if (daysUntilChristmas <= 0)
        {
            string finalContent = "";

            if (_employees.GetHappinessValue() > 0)
            {
                finalContent += _dialogueStrings.GetString(DialogueStrings.Key.amazingchristmasfinal);
                
                _background.ShowBackgroundByName("HappySanta");
            }
            else if (_employees.GetHappinessValue() <= 0)
            {
                finalContent += _dialogueStrings.GetString(DialogueStrings.Key.goodchristmasfinal) + "\n" + _dialogueStrings.GetString(DialogueStrings.Key.nosatisfiedworkersfinal);
                
                _background.ShowBackgroundByName("SantaWithGunBlackWhite3");
            }

            
            ShowFinalDialogue(finalContent);
            _music.PlayGoodResultMusic();
        }
    }

    private void ShowFinalDialogue(string content)
    {
        string finalContent = "This is the end.\n" + content;
        finalContent += "\n\n" + "Click \"OK\" to restart.";


        _dialogueOk.ShowDialogue(
            "",
            finalContent,
            () =>
            {
                _music.StopCurrentMusic();
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        );
    }

    private int PayEmployees()
    {
        int countGoldToPayForOneEmployee = _employees.GetCountGoldToPayForOneEmployee();
        int countGoldToPay = _employees.GetCountEmployees() * countGoldToPayForOneEmployee;

        _gold.DecreaseGold(
            decreaserValue: countGoldToPay
        );

        AudioManager.Instance.Play("wavesfx");
        _leftInfoView.ShowInfoAsync(
            newText: _dialogueStrings.GetString(DialogueStrings.Key.laborinfo) + "\n" + 
                "* " + countGoldToPayForOneEmployee.ToString() + " " + _dialogueStrings.GetString(DialogueStrings.Key.goldinfo), 
            onEnd: () => 
            {
                _dialogueYesNo.ShowNextDialogue();
            }
        );

        return countGoldToPay;
    }
}
