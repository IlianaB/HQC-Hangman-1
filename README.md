#High-Quality Programming Code – Team Projects

### 1. Redesign of the initial project structure
#### 1.1. Rename project *besenica* to *HangmanGame*
#### 1.2. Extract each class in a separate file with a good name: GameEngine.cs, ConsoleRenderer.cs, GameStrategy.cs, ScoreBoard.cs

### 2. Code Formatting
#### 2.1. Formatting Blocks

     if (count == 0) { mistackes++; }

changed to:

            if (count == 0)
            {
                mistackes++;
            }

#### 2.2. Empty line for separation of methods, properties, etc. and methods, if statements, loop identation (single tab in the body of the method, statement, loop and so on)
    public int Mistackes
    {
        get{return mistackes;}
    }
    public bool HelpUsed 
    {
        get { return helpUsed; }
    }
    public char RevealALetter() 
    {
        char toReturnt = char.MinValue;
        for (int i = 0; i < guessedLetters.Length; i++)
        {
            if (guessedLetters[i] == '_') 
            {
                guessedLetters[i] = wordToGuess[i];
                toReturnt = wordToGuess[i];
                helpUsed = true;
                break;
            }
        }
        return toReturnt;
    }

changed to:

            public int Mistackes
            {
                get
                {
                    return this.Mistackes;
                }
            }

            public bool HelpUsed
            {
                get
                {
                    return this.HelpUsed;
                }
            }

            public char RevealALetter(char[] guessedLetters, string wordToGuess)
            {
                char toReturnt = char.MinValue;

                for (int i = 0; i < guessedLetters.Length; i++)
                {
                    if (guessedLetters[i] == '_')
                    {
                        guessedLetters[i] = wordToGuess[i];
                        toReturnt = wordToGuess[i];
                        bool helpUsed = true;
                        break;
                    }
                }

                return toReturnt;
            }

#### 2.3. Unnecessary new lines and spaces removed

    public bool isOver() 
    {
        for (int i = 0; i < guessedLetters.Length; i++)
        {
            if (guessedLetters[i] == '_') 
            {
     
				
				return false;
            }
        }
        return true;
    }

changed to:

        public bool isOver()
        {
            for (int i = 0; i < guessedLetters.Length; i++)
            {
                if (guessedLetters[i] == '_')
                {
                    return false;
                }
            }

            return true;
        }

#### 2.4. Split the lines containing several statements into several simple lines:

    if (scoreNames[scoreNames.Length - 1] != null) { worstTopScore = mistackes[scoreNames.Length - 1]; }

changed to:

    if (scoreNames[scoreNames.Length - 1] != null) 
	{ 
		worstTopScore = mistackes[scoreNames.Length - 1]; 
	}

#### 2.5. Formatting reflects the logical structure of the methods:

    if (playerCanEnterHighScores)
    {
	    int mistakes = this.Player.Mistakes;
	    IPersonalScore newRecord = new PersonalScore(this.Player.Name, mistakes);
	    
	    this.SaveResult(newRecord);
	    
	    this.ScoreBoardService.AddNewScore(newRecord);
	    this.ScoreBoardService.SortScoreBoard();
	    this.Renderer.ShowScoreBoardResults(this.ScoreBoardService.IsEmpty(), this.ScoreBoardService.GetAllRecords());
    }

### 3. Naming Identifiers
#### 3.1. Use English language - file besenica.cs renamed to hangman.cs, the method *IzberiRandomWord* renamed to *ChooseRandomWord*, 
#### 3.2. Choose descriptive and meaningful names of methods, following the pattern [Verb], [Verb] + [Noun] or [Verb] + [Adjective] + [Noun] - the name *NumberOccuranceOfLetter* changed to *FindNumberOfLetterOccurences*.
#### 3.3. Choose descriptive and meaningful names of variables - the char to be return by the method RevealLetter *toReturnt* renamed to *revealedLetter*.
#### 3.4. Use PascalCase for methods and fields names and camelCase for properties and variables names - method *ReSet* renamed to *ResetGame*.
#### 3.5. Consistency of methods naming 

**- StartGame(), void ResetGame(), EndWonGame(), EndLostGame() in GameEngine class** 

**- ShowScoreBoardResults(), ShowCurrentProgress(), ShowMessage() in Renderer class**


### 4. High-quality methods
#### 4.1. Assign single purpose of all methods
#### 4.2. Use methods to reduce code complexity - large methods are broken into smaller ones, so that each one solves a **specific** task:

For example, the method which controlled the main game-flow:

    static void Main()
    {
        ScoreBoard scoreBoard = new ScoreBoard();
        besenica game = new besenica();
        Console.WriteLine("Welcome to “Hangman” game. Please try to guess my secret word.");
        string command = null;
        do
        {
            Console.WriteLine();
            game.PrintCurrentProgress();
            if (game.isOver())
            {
                if (game.HelpUsed)
                {
                    Console.WriteLine("You won with {0} mistake(s) but you have cheated." +
                        " You are not allowed to enter into the scoreboard.", game.Mistackes);
                }
                else
                {
                    if (scoreBoard.GetWorstTopScore() <= game.Mistackes)
                    {
                        Console.WriteLine("You won with {0} mistake(s) but you score did not enter in the scoreboard",
                            game.Mistackes);
                    }
                    else
                    {
                        Console.Write("Please enter your name for the top scoreboard: ");
                        string name = Console.ReadLine();
                        scoreBoard.AddNewScore(name, game.Mistackes);
                        scoreBoard.Print();
                    }
                }
                game.ReSet();
            }
            else
            {
                Console.Write("Enter your guess: ");
                command = Console.ReadLine();
                command.ToLower();
                if (command.Length == 1)
                {
                    int occuranses = game.NumberOccuranceOfLetter(command[0]);
                    if (occuranses == 0)
                    {
                        Console.WriteLine("Sorry! There are no unrevealed letters “{0}”.", command[0]);
                    }
                    else
                    {
                        Console.WriteLine("Good job! You revealed {0} letter(s).", occuranses);
                    }
                }
                else
                {
                    ExecuteCommand(command, scoreBoard, game);
                }
            }
        } while (command != "exit");
    }

was separated mainly into 6 smaller methods:

- StartGame(),
- Play(),
- WaitForPlayerAction(),
- ExecutePlayerAction(string command),
- ExecuteLetterGuess(char letter),
- ExecuteCommand(ICommand command);

And two different methods for putting the end of the game, depending on the condition (winning or loosing):

- EndLostGame();
- EndWonGame();

#### 4.3. Choose descriptive name for methods to improve code readability and make the code self-documenting, e.g.

     public void ReactToPlayerAction(string command)
    {
	    if (command.Length == 1)
	    {
	    	this.ExecuteLetterGuess(command[0]);
	    }
	    else
	    {
		    ICommand currentCommand = this.CommandFactory.GetGommand(this, command);
		    this.ExecuteCommand(currentCommand);
	    }
    }

#### 4.4. Hide implementation details - Complex logic is encapsulated and hidden behind a simple interface, for example:

    Game game = new ConsoleGame();
			    game.Initialize();
			    game.Start();

behind the scenes look like this:

    public override void Initialize()
        {
            IScoreBoard scoreBoard = new ScoreBoard();
            IScoreBoardService scoreBoardService = new ScoreBoardService(scoreBoard);
            IRenderer renderer = new ConsoleRenderer(new CapitalizeFormatter());
            IInputProvider inputProvider = new ConsoleInputProvider();
            IPlayer player = new Player(false);
            IWordProvider wordProvider = new WordProvider();
            WordGenerator randomWordGenerator = new WordGenerator(wordProvider);
            ICommandFactory commandFactory = new CommandFactory();
            IEngine gameEngine = new ConsoleEngine(scoreBoardService, renderer, player, randomWordGenerator, commandFactory, inputProvider);
            DataFileManager.SingletonInstance.RestoreResults(scoreBoardService, Constants.FilePathConsoleGame);

            this.Engine = gameEngine;
        }

    public void Start()
    {
    	this.Engine.StartGame();
    }

#### 4.5. Increase the level of abstraction by addressing real-world problems.
#### 4.6. Communicational and sequential cohesion
#### 4.7. Loose coupling - methods depend mainly on their parameters, not hidden dependencies on class members or other.



### 5. Constants - remove "magic" strings and numbers and introduce constants:
**For example:**

		public const string IncorrectCommandMessage = "Incorrect guess or command!"; 
        public const int NumberOfScoresInScoreBoard = 10;
        public const char WordMaskChar = '_';

### 6. Data clumps - group some pieces of data which is hanging around together. For example:
Instead of saving users personal scores in the ScoreBoard into two Arrays:

    private string[] scoreNames = new string[NUMBER_OF_SCORES];
    private int[] mistackes = new int[NUMBER_OF_SCORES];

introduce a **new class PersonalScore**: 

      public PersonalScore(string name, int score)
        {
            this.Name = name;
            this.Score = score;
        }

        public string Name { get; private set; }

        public int Score { get; private set; }

### 7. Debugging

**The problem:** ScoreBoard was always empty after game reset

**The solution:**

     for (int i = 0; i < ScoreNames.Length; i++)
     {
	     ScoreNames[i] = null;
	    -Mistakes[i] = 0;
	    +Mistakes[i] = int.MaxValue;
     }

### 8. Design Patterns
#### 8.1. Creational Patterns

- **Simple Factory**

in the class CommandFactory:

        public ICommand GetGommand(ICommandExecutable engine, string command)
        {
            switch (command)
            {
                case "start": return new StartCommand(engine);
                case "top": return new TopCommand(engine);
                case "help": return new HelpCommand(engine);
                case "restart": return new RestartCommand(engine);
                case "exit": return new ExitCommand(engine);
                case null: return new NullCommand(engine);
                default: return new WrongCommand(engine);
            }
        }

- **Singleton** (thread-safe version) and
- **Lazy Initialization**:
 
in DataFileManager class:
    
     private static readonly Lazy<DataFileManager> SingletonDataFileManager = 
            new Lazy<DataFileManager>(() => new DataFileManager());

        private DataFileManager()
        {
        }

        public static DataFileManager SingletonInstance
        {
            get
            {
                return SingletonDataFileManager.Value;
            }
        }


#### 8.2. Structural Patterns:
- **Facade**

in Games classes:

            Game game = new ConsoleGame();
            game.Initialize();
            game.Start();

hides the complicate logic of initializing new game:

     public IEngine Engine { get; set; }

     public override void Initialize()

        {
            IScoreBoard scoreBoard = new ScoreBoard();
            IScoreBoardService scoreBoardService = new ScoreBoardService(scoreBoard);
            IRenderer renderer = new ConsoleRenderer(new CapitalizeFormatter());
            IInputProvider inputProvider = new ConsoleInputProvider();
            IPlayer player = new Player(false);
            IWordProvider wordProvider = new WordProvider();
            IWordGenerator randomWordGenerator = new WordGenerator(wordProvider);
            ICommandFactory commandFactory = new CommandFactory();
            IEngine gameEngine = new ConsoleEngine(scoreBoardService, renderer, player, randomWordGenerator, commandFactory, inputProvider);
            DataFileManager.SingletonInstance.RestoreResults(scoreBoardService, Constants.FilePathConsoleGame);

            this.Engine = gameEngine;
        }

        public void Start()
        {
            this.Engine.StartGame();
        }

- **Bridge**

The abstraction Renderer (implemented by concrete Renderers - ConsoleRenderer and WpfRenderer) works with another abstraction IFormatter (the concrete implementators are AllCapsFormatter and Capitalize Formatter):

    public abstract class Renderer : IRenderer
    {
        protected readonly IResultFormatter Formatter;

        protected Renderer(IResultFormatter formatter)
        {
            this.Formatter = formatter;
        }

    	public abstract void ShowScoreBoardResults(bool isEmptyScoreBoard, ICollection<IPersonalScore> records);

    }


    public class ConsoleRenderer : Renderer, IRenderer
    {
    	public override void ShowScoreBoardResults(bool isEmptyScoreBoard, ICollection<IPersonalScore> records)
        {
            if (isEmptyScoreBoard)
            {
                Console.WriteLine(Constants.EmptyScoreboardMessage);
            }
            else
            {
                Console.WriteLine("Scoreboard:");

                int position = 1;
                foreach (var record in records)
                {
                    Console.WriteLine(position + ". " + this.Formatter.Format(record));
                    position++;
                }
            }
        }
    }


    public class WpfRenderer : Renderer, IRenderer
    {
    	public override void ShowScoreBoardResults(bool isEmptyScoreBoard, ICollection<IPersonalScore> records)
        {
            this.MainWindow.Results.Visibility = Visibility.Visible;

            var result = new StringBuilder();

            if (isEmptyScoreBoard)
            {
                result.Append(Constants.EmptyScoreboardMessage);
            }
            else
            {
                result.AppendLine("Scoreboard:");

                int position = 1;
                foreach (var record in records)
                {
                    string recordInfo = position + ". " + this.Formatter.Format(record);
                    result.AppendLine(recordInfo);
                    position++;
                }
            }

            this.MainWindow.Results.Content = result.ToString();
        }
    }

- **Adapter**

The **ScoreBoard class** is **converted** to another class using a so-called adapter class,

The **"Target" class** (Adapter) is **IScoreBoardService**

The **"ConcreteAdapter" class** is **ScoreBoardServices**:

The client class (our Engines) wants to work with the interface IScoreBoardService:


    public interface IScoreBoardService
    {
        void AddNewScore(IPersonalScore record);

        void RemoveLastRecords(int maxNumberOfScoresinScoreBoard);

        void SortScoreBoard();

        void Reset();

        void RestoreRecords(IList<IPersonalScore> restoredResults);

        IList<IPersonalScore> GetAllRecords();

        int GetWorstScoreEntry(int position);

        bool IsFull(int numberOfScoresInScoreBoard);

        bool IsEmpty();

    }

The ScoreBoardService class wraps an instance of IScoreBoard and works with it, implementing all interface methods:

    public class ScoreBoardService : IScoreBoardService
    {
    	public ScoreBoardService(IScoreBoard scoreBoard)
	    {
	    	this.currentScoreBoard = scoreBoard;
	    }
    }


#### 8.3. Behavioral Patterns

- **Template Method**

In abstract GameEngine class we have the method Play() with two hooks - SetPlayerName() and WaitForPlayerAction(). The concrete implementators of GameEngine class override the methods.

    	private void Play()
        {
            if (this.Player.Name == string.Empty)
            {
                this.SetPlayerName();
            }

            this.Renderer.ShowCurrentProgress(this.WordToGuess.Mask);

            this.WaitForPlayerAction();
        }

        protected virtual void SetPlayerName()
        {
        }

        protected virtual void WaitForPlayerAction()
        {
        }


    public class ConsoleEngine : GameEngine
    {
        protected override void WaitForPlayerAction()
        {
            do
            {
                bool isGameOver = this.CheckGameOverCondition();
                bool isWordGuessed = this.CheckWinningCondition();

                if (isGameOver)
                {
                    this.EndLostGame();
                }

                if (isWordGuessed)
                {
                    this.EndWonGame();
                }

                this.Renderer.ShowMessage(Constants.EnterGuessMessage);
                string command = this.InputProvider.ReadCommand();
                this.ReactToPlayerAction(command);
            }
            while (true);
        }

        protected override void SetPlayerName()
        {
            this.Renderer.ShowMessage(Constants.EnterNameMessage);
            string name = this.InputProvider.ReadCommand();
            this.Player.Name = name;
        }
    }


- **Command**

**Receiver** - GameEngine
**Command** - Command classes
**Invoker** - GameEngine

The **"Command" abstract class**:

    public abstract class Command : ICommand
    {
        protected Command(ICommandExecutable engine)
        {
            this.Engine = engine;
        }

        protected ICommandExecutable Engine { get; set; }

        public abstract void Execute();
    }

The **concrete "Command" class**:

    public class StartCommand : Command, ICommand
    {
        public StartCommand(ICommandExecutable engine)
            : base(engine)
        {
        }

        public override void Execute()
        {
            this.Engine.StartGame();
        }
    }


The **"Receiver" class**:


        public void StartGame()
        {
            string word = this.WordGenerator.GetRandomWord();
            this.WordToGuess = new GuessWord(word);
            this.Renderer.ShowMessage(Constants.WelcomeMessage);
            this.Play();
        }


The **"Invoker" class**:


        public void ReactToPlayerAction(string command)
        {
            if (command.Length == 1)
            {
                this.ExecuteLetterGuess(command[0]);
            }
            else
            {
                ICommand currentCommand = this.CommandFactory.GetGommand(this, command);
                this.ExecuteCommand(currentCommand);
            }
        }

        private void ExecuteCommand(ICommand command)
        {
            command.Execute();
        }


- **Strategy**
At many places, but for example - in GameEngine constructor everything can vary:


>     protected GameEngine(
>             IScoreBoardService scoreBoardService, 
>             IRenderer renderer,
>             IPlayer player, 
>             IWordGenerator wordGenerator, 
>             ICommandFactory commandFactory)
>         {
>             this.ScoreBoardService = scoreBoardService;
>             this.Renderer = renderer;
>             this.Player = player;
>             this.WordGenerator = wordGenerator;
>             this.CommandFactory = commandFactory;
>         }