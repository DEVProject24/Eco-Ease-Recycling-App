using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;


namespace Eco_Ease_Recycling.ViewModels
{
    public class TipsService
    {
        private readonly FirebaseClient firebaseClient;
        private List<string> _tips = new List<string>();

        public TipsService()
        {
            firebaseClient = new FirebaseClient("https://eco-ease-5e1f9-default-rtdb.firebaseio.com/");
        }

        // Fetch tips from Firebase
        public async Task<List<string>> FetchTipsAsync()
        {
            var tips = await firebaseClient
                .Child("Tips")
                .OnceAsync<RecyclingTip>();

            _tips = tips.Select(t => t.Object.Description).ToList();
            return _tips;
        }

        // Returns the list of tips
        public List<string> GetTips()
        {
            return _tips;
        }

        public class RecyclingTip
        {
            public string Description { get; set; }
        }
    }
}
