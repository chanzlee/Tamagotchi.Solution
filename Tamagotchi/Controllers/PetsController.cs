using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tamagotchi.Models;

namespace Tamagotchi.Controllers
{
  public class PetsController : Controller
  {
    [HttpGet("/pets")]
    public ActionResult Index()
    {
      List<Pet> allPets = Pet.GetAll();
      return View(allPets);
    }

    [HttpGet("/pets/new")]
    public ActionResult CreateForm()
    {
      return View();
    }
    [HttpPost("/pets")]
    public ActionResult Create()
    {
      Pet newPet = new Pet(Request.Form["petName"]);
      List<Pet> allPets = Pet.GetAll();
      return View("Index", allPets);
    }

    [HttpGet("/pets/{id}")]
    public ActionResult Details(int id)
    {
      Pet newPet = Pet.Find(id);

      return View(newPet);
    }
    [HttpPost("/pets/{id}")]
    public ActionResult Update(int id)
    {
      Pet newPet = Pet.Find(id);
      Pet.Aging(newPet);
      if (newPet.GetAttention() == 0 || newPet.GetHunger()==100 || newPet.GetSleep()==0)
      {
        newPet.SetDeath(true);
      }
      return View("Details", newPet);
    }
    [HttpPost("/place/delete")]
    public ActionResult DeleteAll()
    {
      Pet.ClearAll();
      return View();
    }
  }
}
