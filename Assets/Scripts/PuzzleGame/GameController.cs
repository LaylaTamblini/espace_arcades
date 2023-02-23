using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [Header("SPRITES")]
    [SerializeField][Tooltip("Image background des cartes.")] private Sprite _bgImage;
    [SerializeField][Tooltip("Images des puzzles.")] private Sprite[] _puzzles;

    [Header("LISTES")]
    [SerializeField][Tooltip("List des boutons.")] private List<Button> _btns = new List<Button>();
    [SerializeField][Tooltip("List des puzzles dans le jeu.")] private List<Sprite> _gamePuzzles = new List<Sprite>();

    [Header("AUDIO")]
    [SerializeField][Tooltip("L'AudioSource du SoundManager.")] private AudioSource _audioSource;
    [SerializeField][Tooltip("Son quand l'image est sélectionnée.")] private AudioClip _audioSelected;
    [SerializeField][Tooltip("Son quand l'image est sélectionnée n'est pas placée dans son container.")] private AudioClip _audioError;
    [SerializeField][Tooltip("Son quand l'image est sélectionnée est placée dans son container.")] private AudioClip _audioWin;

    [Header("GAMEOBJECTS")]
    [SerializeField][Tooltip("Gameobject dans le canvas qui contient le panneau de victoire.")] private GameObject _panneau;


    private bool _firstGuess;
    private bool _secondGuess;

    private int _countGuesses;
    private int _countCorrectGuesses;
    private int _gameGuesses;
    private int _firstGuessIndex;
    private int _secondGuessIndex;

    private string _firstGuessPuzzle;
    private string _secondGuessPuzzle;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake() {
        // va chercher le sprite qui se nomme ButtonFace
        // dans le dossier sprites.-
        _puzzles = Resources.LoadAll<Sprite> ("Sprites/ButtonFace");
    }

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start() {
        GetButtons();
        AddListeners();
        AddGamePuzzles();
        Shuffle(_gamePuzzles);

        _gameGuesses = _gamePuzzles.Count / 2;
    }

    /// <summary>
    //  Création des btns
    /// </summary>
    private void GetButtons() {
        // Trouve tout les go avec le tag PuzzleButton.
        GameObject[] objects = GameObject.FindGameObjectsWithTag("PuzzleButton");

        // Pour tout les go dans la liste,
        // va chercher son component Button.
        for (int i = 0; i < objects.Length; i++) {
            // ajoute le button.
            _btns.Add(objects[i].GetComponent<Button>());
            // change le background image du btn.
            _btns[i].image.sprite = _bgImage;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    private void AddGamePuzzles() {
        // le nombre de btn dans la liste.
        int looper = _btns.Count;
        // l'index commence à zéro.
        int index = 0;

        // looping pour tout les btn.
        // si l'index et == a looper / 2
        // recommence l'index à zéro
        // ( donc nous avons les images en double pour le puzzle )
        for (int i = 0; i < looper; i++) {
            if (index == looper / 2) {
                index = 0;
            }

            _gamePuzzles.Add(_puzzles[index]);
            index++;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    private void AddListeners() {
        foreach (Button btn in _btns) {
            // ajoute un listener aux buttons.
            btn.onClick.AddListener(() => PickAPuzzle());
        }
    }

    /// <summary>
    /// Quand on click sur
    /// un puzzle
    /// </summary>
    public void PickAPuzzle() {
        // va chercher le nom du current selected gameobject dans unity.
        string name = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        Debug.Log("Click sur le btn qui se nomme " + name);
        _audioSource.PlayOneShot(_audioSelected);

        // permet au joueur d'avoir seulement deux essais
        if (!_firstGuess) {
            _firstGuess = true;
            // string to int.
            _firstGuessIndex = int.Parse(name);
            // nous donne le nom de l'image
            _firstGuessPuzzle = _gamePuzzles[_firstGuessIndex].name;
            _btns[_firstGuessIndex].image.sprite = _gamePuzzles[_firstGuessIndex];
            // desactive interactivité si btn est cliqué
            _btns[_firstGuessIndex].interactable = false;
        } else if (!_secondGuess) {
            _secondGuess = true;
            // string to int.
            _secondGuessIndex = int.Parse(name);
            // nous donne le nom de l'image
            _secondGuessPuzzle = _gamePuzzles[_secondGuessIndex].name;
            _btns[_secondGuessIndex].image.sprite = _gamePuzzles[_secondGuessIndex];
            // desactive interactivité si btn est cliqué
            _btns[_secondGuessIndex].interactable = false;
            // augmente le nombre d'essais réalisé
            // par le joueur
            _countGuesses++;
            StartCoroutine(CheckIfThePuzzlesMatch());

            // // si le nom des deux go sont le même
            // if (_firstGuessPuzzle == _secondGuessPuzzle) {
            //     Debug.Log("Match!!!");
            // } else {
            //     Debug.Log("No match :( !!!!");
            // }
        }
    }

    IEnumerator CheckIfThePuzzlesMatch() {
        yield return new WaitForSeconds(.5f);

        // si le match est bon.
        if (_firstGuessPuzzle == _secondGuessPuzzle) {
            yield return new WaitForSeconds(.3f);
            // désactive l'intéractivité du btn.
            _btns[_firstGuessIndex].interactable = false;
            _btns[_secondGuessIndex].interactable = false;

            // ne plus voir les btn dans unity.
            _btns[_firstGuessIndex].image.color = new Color(0, 0, 0, 0);
            _btns[_secondGuessIndex].image.color = new Color(0, 0, 0, 0);

            CheckIfTheGameIsFinished();

            _audioSource.PlayOneShot(_audioWin);
            
        } else {
            yield return new WaitForSeconds(.5f);


            // si le match n'est pas bon, on remet 
            // l'image de background.
            _btns[_firstGuessIndex].image.sprite = _bgImage;
            _btns[_secondGuessIndex].image.sprite = _bgImage;

            // active interactivité si btn est cliqué
            _btns[_firstGuessIndex].interactable = true;
            _btns[_secondGuessIndex].interactable = true;

            _audioSource.PlayOneShot(_audioError);
        }

        // yield return new WaitForSeconds(.5f);
        _firstGuess = false;
        _secondGuess = false;
    }

    private void CheckIfTheGameIsFinished() {
        _countCorrectGuesses++;
        if (_countCorrectGuesses == _gameGuesses) {
            Debug.Log("Fin de la partie");
            Debug.Log("Tu as fini la partie en " + _countGuesses + " tours");

            _panneau.SetActive(true);
        }
    }

    private void Shuffle(List<Sprite> list) {
        for (int i = 0; i < list.Count; i++) {
            Sprite temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }
}
