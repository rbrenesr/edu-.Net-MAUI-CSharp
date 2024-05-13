using System.ComponentModel;
using System.Diagnostics;

namespace Hangman
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        #region UI Properties
        public string Spotlight
        {
            get => spotlight; set
            {
                spotlight = value;
                OnPropertyChanged();
            }
        }
        public List<char> Letters
        {
            get => letters; set
            {
                letters = value;
                OnPropertyChanged();
            }
        }
        public string Mensaje
        {
            get => mensaje; set
            {
                mensaje = value;
                OnPropertyChanged();
            }
        }
        public string GameStatus
        {
            get => gameStatus; set
            {
                gameStatus = value;
                OnPropertyChanged();
            }
        }

        public string CurrentImage
        {
            get => currentImage; set
            {
                currentImage = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Fields

        private List<string> words = new List<string> { "hola", "adios", "casa", "perro", "gato", "raton", "elefante", "tigre", "leon", "jirafa" };
        private string answer;
        private string spotlight;
        private List<char> guessed = new List<char>();
        private List<char> letters = new List<char>();
        private string mensaje;
        private int mistakes = 0;
        private int maxWrong = 6;
        private string gameStatus;
        private string currentImage = "img0.jpg";


        #endregion

        #region Game Engine
        private void PickWord()
        {
            Random random = new Random();
            int index = random.Next(words.Count);
            answer = words[index];

            Debug.WriteLine(answer);
        }
        private void CalculateWord(string answer, List<char> guessed)
        {
            var temp =
                 answer.Select(c => (guessed.IndexOf(c) >= 0 ? c : '_')).ToArray();

            Spotlight = string.Join(" ", temp);
        }

        private void UpdateGameStatus()
        {
            GameStatus = $"Mistakes: {mistakes} of {maxWrong}";
        }

        private void HandleGuess(char letter)
        {
            //Valida si la letra fue descubierta anteriormente
            if (guessed.IndexOf(letter) == -1)
            {
                guessed.Add(letter);
            }

            if (answer.IndexOf(letter) >= 0)
            {
                CalculateWord(answer, guessed);
                CheckIfGameWom();
            }
            else if (answer.IndexOf(letter) == -1)
            {
                mistakes++;
                UpdateGameStatus();
                CheckIfGameLost();
                CurrentImage = $"img{mistakes}.jpg";
            }
        }

        private void CheckIfGameLost()
        {
            if (mistakes == maxWrong)
            {
                Mensaje = "You Lose!";
                DisableLetters();
            }
        }

        private void DisableLetters()
        {
            foreach (var children in LetterContainer.Children)
            {
                var btn = children as Button;
                if (btn != null)
                {
                    btn.IsEnabled = false;
                }
            }
        }

        private void EnableLetters()
        {
            foreach (var children in LetterContainer.Children)
            {
                var btn = children as Button;
                if (btn != null)
                {
                    btn.IsEnabled = true;
                }
            }
        }

        private void CheckIfGameWom()
        {
            if (Spotlight.Replace(" ", "") == answer)
            {
                Mensaje = "You Win!";
            }
        }

        #endregion
        public MainPage()
        {
            InitializeComponent();
            Letters.AddRange("abcdefghijklmnopqrstuvwxyz");
            BindingContext = this;
            PickWord();
            CalculateWord(answer, guessed);
            GameStatus = $"Mistakes: 0 of {maxWrong}";
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var btn = sender as Button;
            if (btn != null)
            {
                var letter = btn.Text;
                btn.IsEnabled = false;
                HandleGuess(letter[0]);                                
            }
        }

        private void btnResetGame_Clicked(object sender, EventArgs e)
        {
            mistakes = 0;
            guessed = new List<char>();
            CurrentImage = "img0.jpg";
            PickWord();
            CalculateWord(answer, guessed);
            Mensaje = "";
            UpdateGameStatus();
            EnableLetters();
        }
    }

}
