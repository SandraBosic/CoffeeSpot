﻿using CoffeeSpot.Data;
using CoffeeSpot.Data.Entities;
using CoffeeSpot.Models;
using CoffeeSpot.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoffeeSpot.Repositories
{
    public class CoffeeSpotRepository : ICoffeeSpotRepository
    {
        ICoffeeSpotContext context;

        public CoffeeSpotRepository(ICoffeeSpotContext context)
        {
            this.context = context;
        }

        public List<CoffeeSpotModel> GetAllCofeeSpots()
        {
            List<CoffeeSpotModel> results = new List<CoffeeSpotModel>();

            var data = context.CoffeeSpots.Include("Feedbacks");

            foreach (var item in data)
            {
                var coffeeSpot = ConvertCoffeeSpotEntityToModel(item);

                results.Add(coffeeSpot);
            }

            return results;
        }

        public CoffeeSpotModel GetCoffeeSpot(int id)
        {
            var data = context.CoffeeSpots.Include("Feedbacks").SingleOrDefault(x => x.Id == id);

            if (data != null)
                return ConvertCoffeeSpotEntityToModel(data);

            return null;
        }

        public void SaveFeedbackForCoffeeSpot(int cofeeSpotID, FeedbackModel feedbackModel)
        {
            Feedback feedback = new Feedback()
            {
                Comment = feedbackModel.Comment,
                Grade = feedbackModel.Grade
            };

            var coffeeSpot = context.CoffeeSpots.Single(x => x.Id == cofeeSpotID);

            if (coffeeSpot.Feedbacks == null)
                coffeeSpot.Feedbacks = new List<Feedback>();

            coffeeSpot.Feedbacks.Add(feedback);
            context.SaveChanges();
        }

        public void SaveCoffeeSpot(CoffeeSpotModel model)
        {
            CoffeeSpot.Data.Entities.CoffeeSpot entity = new CoffeeSpot.Data.Entities.CoffeeSpot()
            {
                Name = model.Name,
                Address = model.Address,
                Description = model.Description,
                FoundationDate = model.FoundationDate
            };

            context.CoffeeSpots.Add(entity);
            context.SaveChanges();
        }

        private CoffeeSpotModel ConvertCoffeeSpotEntityToModel(CoffeeSpot.Data.Entities.CoffeeSpot entity)
        {
            List<FeedbackModel> feedbacks = new List<FeedbackModel>();

            foreach (var fb in entity.Feedbacks)
            {
                FeedbackModel feedback = new FeedbackModel()
                {
                    Id = fb.Id,
                    Comment = fb.Comment,
                    Grade = fb.Grade
                };
                feedbacks.Add(feedback);
            }

            CoffeeSpotModel coffeeSpot = new CoffeeSpotModel()
            {
                Id = entity.Id,
                Address = entity.Address,
                Description = entity.Description,
                FoundationDate = entity.FoundationDate,
                Name = entity.Name,
                WorkingHours = String.Format("{0} - {1}", entity.WorkingHoursStart, entity.WorkingHoursEnd),
                Feedbacks = feedbacks
            };

            return coffeeSpot;
        }

    }
}