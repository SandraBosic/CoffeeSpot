using CoffeeSpot.Models;
using System.Collections.Generic;

namespace CoffeeSpot.Repositories.Interfaces
{
    public interface ICoffeeSpotRepository
    {
        List<CoffeeSpotModel> GetAllCofeeSpots();

        CoffeeSpotModel GetCoffeeSpot(int id);

        void SaveFeedbackForCoffeeSpot(int cofeeSpotID, FeedbackModel feedbackModel);

        void SaveCoffeeSpot(CoffeeSpotModel cofeeSpotModel);
    }
}
