using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WireAppBattleShipGameWPF.Models;
using WireAppBattleShipGameWPF.Extentions;

namespace WireAppBattleShipGameWPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private Game _game;
        private ICommand _fireShotCommand;        

        public Game Game
        {
            get => _game;
            set => Set(ref _game, value);
        }

        public RelayCommand ExecuteCommand { get; }

        public ICommand FireShotCommand
        {
            get
            {
                if (_fireShotCommand == null)
                    _fireShotCommand = new RelayCommand<Panel>(async panel =>await fireManualShot(panel));
                return _fireShotCommand;
            }
        }

        private Task fireManualShot(Panel panel)
        {
            Debug.WriteLine($"Current value: ({panel.Coordinates.X}, {panel.Coordinates.Y})");
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:1821/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            Game.ManualShotCoordinates = panel.Coordinates;
            
            var response = client.PostAsJsonAsync("api/BattleShip", Game).Result;
            if (response.IsSuccessStatusCode)
            {
                try
                {
                    Game = response.Content.ReadAsAsync<Game>().Result;
                   // Debug.WriteLine($"Result value: ({result.Panels[0].OccupationStatus}, {result.Panels[0].OccupationStatus})");
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                    Debug.WriteLine(e.StackTrace);
                }

            }
            else
            {
                MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase);
            }
            return Task.CompletedTask;
        }

        public MainViewModel()
        {
            ExecuteCommand = new RelayCommand(async () => await ExecuteAsync());
        }

        private Task ExecuteAsync()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:1821/");
            //client.DefaultRequestHeaders.Add("appkey", "myapp_key");
            client.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("api/BattleShip").Result;
            if (response.IsSuccessStatusCode)
            {
                try
                {
                    Game = response.Content.ReadAsAsync<Game>().Result;
                }catch(Exception e)
                {
                    Debug.WriteLine(e.Message);
                    Debug.WriteLine(e.StackTrace);
                }

            }
            else
            {
                MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase);
            }
            return Task.CompletedTask;
        }
    }
}
