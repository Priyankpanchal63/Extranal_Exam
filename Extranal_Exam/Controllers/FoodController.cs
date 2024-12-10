using Extranal_Exam.Exceptions;
using Extranal_Exam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Extranal_Exam.Controllers
{
    public class FoodController : ApiController
    {
        //ExtranalEntities context = new ExtranalEntities();
        DBEEntities context =new DBEEntities();
        [HttpGet]
        [Route("GetFoods")]

        public List<TBLFood> FoodList()
        {
            return context.TBLFoods.ToList();
        }

        public object PostFood(TBLFood food)
        {
            try
            {
                if (context.TBLFoods.Any(b => b.name.ToLower() == food.name.ToLower()))
                {
                    var matchingNames = context.TBLFoods.Where(b => b.name.ToLower().StartsWith(food.name.ToLower()) && b.name.Length > food.name.Length).Select(b => b.name);

                    int highestNumber = 0;

                    foreach (var name in matchingNames)
                    {
                        string numberString = name.Substring(food.name.Length);

                        int number;
                        if (int.TryParse(numberString, out number))
                        {
                            highestNumber = Math.Max(highestNumber, number);
                        }
                    }

                    // Append the next number
                    food.name += (highestNumber + 1).ToString();
                }
                if (food.quantity <= 0 || food.quantity > 10)
                {
                    throw new QuantityZero();
                }
                context.TBLFoods.Add(food);
                context.SaveChanges();
                return new { output = true, message = "" };
            }
            catch (FoodFound ex)
            {
                return new { output = false, message = ex.Message };
            }
            catch (QuantityZero ex)
            {
                return new { output = false, message = ex.Message };
            }
        }
    }
}