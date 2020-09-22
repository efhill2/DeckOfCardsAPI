using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DeckOfCardsAPI.Models;
using System.Net.Http;
using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace DeckOfCardsAPI.Controllers
{
    public class HomeController : Controller
    {
        //private JsonDocument jDoc;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public async Task<IActionResult> GetDeck()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://deckofcardsapi.com");
            var response = await client.GetAsync("/api/deck/new/shuffle/?deck_count=1");
            Deck deck_id = await response.Content.ReadAsAync<Deck>();

            return View(deck_id);

            //HttpClient client = new HttpClient();
            //var response = await client.GetAsync("https://deckofcardsapi.com/api/deck/new/shuffle/?deck_count=1");
            //var deck = await response.Content.ReadAsStringAsync();



            //jDoc = JsonDocument.Parse(deck);

            //jDoc.RootElement.GetProperty("deck_id").GetString();

            //var deckID = jDoc;

            //return Content(deckID);
            
        }
        //public async Task<List<HomeController>> GetCards(string deckID)
        //{
        //    List<HomeController> cardList = new List<HomeController>();
        //    Hand hand = new Hand();

        //}

        public async Task<IActionResult> Index()
        {
            //var deckID = await GetDeck();
            //HttpContext.Session.SetString("deck_id", deckID);
            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
