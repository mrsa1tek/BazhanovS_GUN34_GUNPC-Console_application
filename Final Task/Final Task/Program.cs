using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Final_Task
{
    public interface ISaveLoadService<T>
    {
        void SaveData(T data, string nameFile);
        T LoadData(string nameFile);
    }
    public class FileSystemSaveLoadService<T> : ISaveLoadService<T>
    {
        private readonly string _basePath;
        public FileSystemSaveLoadService(string basePath)
        {
            _basePath = basePath;
            if (!Directory.Exists(_basePath))
            {
                Directory.CreateDirectory(_basePath);
            }
        }
        public void SaveData(T data, string nameFile)
        {
            string filePath = Path.Combine(_basePath, $"{nameFile}.txt");
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(data, options);
            File.WriteAllText(filePath, json);
        }
        public T LoadData(string nameFile)
        {
            string filePath = Path.Combine(_basePath, $"{nameFile}.txt");
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"File {nameFile}.txt not found");
            }
            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<T>(json);
        }
    }

    public class PlayerProfiles
    {
        public string Username { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int Score { get; set; } = 100;
    }

    internal class Program
    {
        private const string ProfilesFile = "profiles.json";
        private static Dictionary<string, PlayerProfiles> _profiles = new();
        private static ISaveLoadService<Dictionary<string, PlayerProfiles>> _saveLoadService;
        private static bool _shouldExit = false;

        static async Task Main(string[] args)
        {
            _saveLoadService = new FileSystemSaveLoadService<Dictionary<string, PlayerProfiles>>(Path.Combine(Directory.GetCurrentDirectory(),"ProfilesData"));

            Console.WriteLine("Welcome to Final Task!");

            await LoadProfilesAsync();

            while (!_shouldExit)
            {
                Console.Write("Enter your name (or 'exit' to quit): ");
                var input = Console.ReadLine()?.Trim();

                if (string.IsNullOrEmpty(input))
                    continue;

                if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                    break;

                await ProccessUserAsync(input);
            }

            Console.WriteLine("Goodbye!");
        }


        private static async Task ProccessUserAsync(string username)
        {
            if (_profiles.ContainsKey(username))
            {
                ShowMessage($"Welcome back, {username}! Your score: {_profiles[username].Score}", ConsoleColor.Green);
                await ShowGameMenu(username);
                return;
            }
            ShowMessage($"User {username} not found", ConsoleColor.Red);
            await HandleNewUserAsync(username);
        }

        private static async Task ShowGameMenu(string username)
        {
            while (!_shouldExit)
            {
                Console.WriteLine("Chooose a game");
                Console.WriteLine(  "0 - Dice\n" +
                                    "1 - Blackjack\n" +
                                    "2 - Exit\n");
                Console.Write("Your choice: ");
                var input = Console.ReadLine();
                var choice = ParseGameChoice(input);

                switch (choice)
                {
                    case GameChoice.DiceGame:
                        await PlayDiceGame(username);
                        break;
                    case GameChoice.Blackjack:
                        await PlayBlackjack(username);
                        break;
                    case GameChoice.Exit:
                        _shouldExit = true;
                        await SaveProfileAsync();
                        return;
                    case GameChoice.Unknown:
                    default:
                        ShowMessage("Invalid choice. Please try again", ConsoleColor.Red);
                        break;
                }
            }
        }

        private static async Task PlayBlackjack(string username)
        {
            throw new NotImplementedException();
        }

        private static async Task PlayDiceGame(string username)
        {
            throw new NotImplementedException();
        }

        private static GameChoice ParseGameChoice(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return 0;
            }
            ;
            return input.Trim() switch
            {
                "0" => GameChoice.DiceGame,
                "1" => GameChoice.Blackjack,
                "2" => GameChoice.Exit,
                _ => GameChoice.Unknown
            };
        }

        private static async Task HandleNewUserAsync(string username)
        {
            Console.WriteLine("Do you want to create a profile?");
            Console.WriteLine(  "- Yes\n" +
                                "- Exit");
            var choise = Console.ReadLine()?.Trim().ToUpper();
            switch (choise)
            {
                case "YES":
                    var profile = new PlayerProfiles { Username = username };
                    _profiles[username] = profile;
                    await SaveProfileAsync();
                    ShowMessage($"Proile {username} created successfully!", ConsoleColor.Green);
                    break;
                case "EXIT":
                    ShowMessage("Profile creation canceled.", ConsoleColor.Cyan);
                    break;
                default:
                    ShowMessage("Invalid input. PLease try again.", ConsoleColor.Red);
                    break;
            }
        }

        static async Task LoadProfilesAsync()
        {
            try
            {
                _profiles = _saveLoadService.LoadData("profiles");
            }
            catch (FileNotFoundException)
            {
                _profiles = new Dictionary<string, PlayerProfiles>();
            }
            catch (Exception ex)
            {
                ShowMessage($"Error loading profiles: {ex.Message}", ConsoleColor.Red);
                _profiles = new Dictionary<string, PlayerProfiles>();
            }
        }

        private static async Task SaveProfileAsync()
        {
            try
            {
                _saveLoadService.SaveData(_profiles, "profiles");
            }
            catch (Exception ex)
            {
                ShowMessage($"Error saving profiles: {ex.Message}", ConsoleColor.Red);
            }

        }

        static void ShowMessage(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
